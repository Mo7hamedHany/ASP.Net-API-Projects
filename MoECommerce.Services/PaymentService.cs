using AutoMapper;
using Microsoft.Extensions.Configuration;
using MoECommerce.Core.DataTransferObjects;
using MoECommerce.Core.Interfaces.Repositories;
using MoECommerce.Core.Interfaces.Services;
using MoECommerce.Core.Models.Order;
using Product = MoECommerce.Core.Models.Product.Product;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoECommerce.Repository.Specifications;


namespace MoECommerce.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IBasketService _basketService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public PaymentService(IBasketService basketService, IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            _basketService = basketService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _config = config;
        }

        public async Task<CustomerBasketDto> CreateOrUpdatePaymentIntentForExistingOrder(CustomerBasketDto basket)
        {
            foreach (var item in basket.BasketItems)
            {
                var product = await _unitOfWork.Repository<Product, int>().GetAsync(item.ProductId);
                if (product?.Price != item.Price)
                    item.Price = product.Price;
            }
            var total = basket.BasketItems.Sum(x => x.Price + x.Quantity);

            if (!basket.DeliveryMethodId.HasValue) throw new Exception("no delivery Method found for this basket");
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethods,int>().GetAsync(basket.DeliveryMethodId.Value);
            var shippingPrice = deliveryMethod.Price;

            long amount = (long)(100*(shippingPrice + total));

            var service = new PaymentIntentService();
            PaymentIntent paymentIntent;
            if (string.IsNullOrWhiteSpace(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = amount,
                    Currency = "USD",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                paymentIntent = await service.CreateAsync(options);
                basket.PaymentIntentId = paymentIntent.Id;
                basket.ClientSecret = paymentIntent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = amount,
                };
                await service.UpdateAsync(basket.PaymentIntentId,options);
            }
            await _basketService.UpdateBasketAsync(basket);

            return basket;
        }

        public async Task<CustomerBasketDto> CreateOrUpdatePaymentIntentForNewOrder(string? basketId)
        {
            StripeConfiguration.ApiKey = _config["Stripe:SecretKey"];
            var basket = await _basketService.GetBasketAsync(basketId);

            foreach (var item in basket.BasketItems)
            {
                var product = await _unitOfWork.Repository<Product, int>().GetAsync(item.ProductId);
                if (product?.Price != item.Price)
                    item.Price = product.Price;
            }
            var total = basket.BasketItems.Sum(x => x.Price + x.Quantity);

            if (!basket.DeliveryMethodId.HasValue) throw new Exception("no delivery Method found for this basket");
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethods, int>().GetAsync(basket.DeliveryMethodId.Value);
            var shippingPrice = deliveryMethod.Price;

            long amount = (long)(100 * (shippingPrice + total));

            var service = new PaymentIntentService();
            PaymentIntent paymentIntent;
            if (string.IsNullOrWhiteSpace(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = amount,
                    Currency = "USD",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                paymentIntent = await service.CreateAsync(options);
                basket.PaymentIntentId = paymentIntent.Id;
                basket.ClientSecret = paymentIntent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = amount,
                };
                await service.UpdateAsync(basket.PaymentIntentId, options);
            }
            await _basketService.UpdateBasketAsync(basket);

            return basket;
        }

        public async Task<OrderResultDto> UpdatePaymentStatusFailed(string paymentIntentId)
        {
            var spec = new OrderWithPaymentIntentIdSpecification(paymentIntentId);
            var order = await _unitOfWork.Repository<Order,Guid>().GetWithSpecsAsync(spec);

            order.paymentStatus = PaymentStatus.Failed;
             _unitOfWork.Repository<Order,Guid>().Update(order);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<OrderResultDto>(order);
        }

        public async Task<OrderResultDto> UpdatePaymentStatusSuceeded(string paymentIntentId)
        {
            var spec = new OrderWithPaymentIntentIdSpecification(paymentIntentId);
            var order = await _unitOfWork.Repository<Order, Guid>().GetWithSpecsAsync(spec);

            order.paymentStatus = PaymentStatus.Received;
            _unitOfWork.Repository<Order, Guid>().Update(order);

            await _unitOfWork.CompleteAsync();

            await _basketService.DeleteBasketAsync(order.BasketId);

            return _mapper.Map<OrderResultDto>(order);
        }
    }
}
