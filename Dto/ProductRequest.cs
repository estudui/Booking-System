namespace BookSystemApi.Dto
{
    public class ProductRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}