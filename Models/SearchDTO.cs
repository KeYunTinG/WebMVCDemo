namespace WebMVCTakahiro.Models
{
    public class searchDTO
    {
        public string? keyword { get; set; }
        public int categoryId { get; set; } = 0;
        public string? sortBy { get; set; }
        public string? sortType { get; set; } = "asc";
        public int? page { get; set; } = 1;
        public int? pageSize { get; set; } = 9;

    }
}
