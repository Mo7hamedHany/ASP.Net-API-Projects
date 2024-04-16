using AutoMapper;
using MoECommerce.Core.DataTransferObjects;
using MoECommerce.Core.Interfaces.Repositories;
using MoECommerce.Core.Interfaces.Services;
using MoECommerce.Core.Models.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _repository;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteBasketAsync(string id) => await _repository.DeleteCustomerBasketAsync(id);

        public async Task<CustomerBasketDto?> GetBasketAsync(string id)
        {
            var basket = await _repository.GetCustomerBasketAsync(id);
            var mappedBasket = _mapper.Map<CustomerBasketDto>(basket);

            return basket is null ? null : mappedBasket;
        }

        public async Task<CustomerBasketDto?> UpdateBasketAsync(CustomerBasketDto basket)
        {
            var mappedBasket = _mapper.Map<CustomerBasket>(basket);

            var updatedBasket = await _repository.UpdateCustomerBasketAsync(mappedBasket);

            return mappedBasket is null ? null : _mapper.Map<CustomerBasketDto>(updatedBasket);
        }
    }
}
