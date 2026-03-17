namespace ProductWebApi.Dtos
{
    public class CreateProductDto
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int? ProductCategoryId { get; set; }
        public decimal DiscountInPct { get; set; }
    }
}
