namespace MoECommerce.Core.DataTransferObjects
{
    public class OrderItemDto
    {
        public string Id { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string PictureUrl { get; set; }
    }
}