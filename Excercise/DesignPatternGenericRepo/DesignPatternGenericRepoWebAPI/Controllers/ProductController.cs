using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIGenericRepoDP.Entity;
using WebAPIGenericRepoDP.Model;
using WebAPIGenericRepoDP.Repository;

namespace WebAPIGenericRepoDP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Products> _prodrepository;

        public ProductController(IRepository<Products> Prodrepository)
        {
            _prodrepository = Prodrepository;
        }        
        [HttpGet]
        [ActionName("GetAllCustomers")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _prodrepository.GetAllAsync();
            return Ok(products);
        }        
        [HttpGet("{id}")]
        [ActionName("GetCustomerByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            var product = await _prodrepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }        
        [HttpPost]
        [ActionName("AddNewCustomer")]
        public async Task<IActionResult> Post([FromBody] ProductRequest product)
        {
            var prodEntity = new Products()
            {
                //ProdId = product.Id,
                ProdName = product.ProdName,
                ProdDescription = product.ProdDescription,
                ProdPrice = product.ProdPrice,
                ProdMFG = product.ProdMFG,
                ProdEXP = product.ProdEXP,
            };
            var createdProductResp = await _prodrepository.AddAsync(prodEntity);
            return CreatedAtAction(nameof(GetByID), new { id = createdProductResp.ProdId }, createdProductResp);
        }        
        [HttpPut("{id}")]
        [ActionName("UpdateCustomerById")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductRequest product)
        {
            var prodEntity = await _prodrepository.GetByIdAsync(id);
            if (prodEntity == null)
                return NotFound();
            prodEntity.ProdName = product.ProdName;
            prodEntity.ProdDescription = product.ProdDescription;
            prodEntity.ProdPrice = product.ProdPrice;
            prodEntity.ProdMFG = product.ProdMFG;
            prodEntity.ProdEXP = product.ProdEXP;
            await _prodrepository.UpdateAsync(prodEntity);
            return NoContent();
        }        
        [HttpDelete("{id}")]
        [ActionName("DeleteCustomer")]
        public async Task<IActionResult> Delete(int id)
        {
            var prodEntry = await _prodrepository.GetByIdAsync(id);
            if(prodEntry == null)
                return NotFound();
            await _prodrepository.DeleteAsync(prodEntry);
            return NoContent();
        }
    }
}
