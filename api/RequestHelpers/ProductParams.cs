
namespace api.RequestHelpers
{
    public class ProductParams : PaginationParams
    {
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public int[] CategoryIds { get; set; }
        public int[] BrandIds { get; set; }
    }
}