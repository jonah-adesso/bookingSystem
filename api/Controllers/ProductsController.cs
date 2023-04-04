
using api.Data;
using api.Entities;
using api.Extensions;
using api.RequestHelpers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<Product>>> GetProducts([FromQuery] ProductParams productParams)
        {

            var query = _context.Products
            .Where(p => (productParams.CategoryIds == null || productParams.CategoryIds.Contains(p.CategoryId)) && (productParams.BrandIds == null || productParams.BrandIds.Contains(p.BrandId)))
            .Sort(productParams.OrderBy)
            .Search(productParams.SearchTerm).AsQueryable();

            var products = await PagedList<Product>.ToPagedList(query, productParams.PageNumber, productParams.PageSize);

            Response.AddPaginationHeader(products.MetaData);

            return products;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null) return NotFound();

            return product;
        }
    }
}