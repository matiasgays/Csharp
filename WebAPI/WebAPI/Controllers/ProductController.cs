using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        [HttpGet("{userId}")]
        public ActionResult<List<Product>>? Get(long userId)
        {
            try
            {
                return Ok(ADO_Product.SelectProduct(userId));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Product>>? Get()
        {
            try
            {
                return Ok(ADO_Product.SelectProducts());
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] long id)
        {
            try
            {
                int rowsAffected = ADO_Product.DeleteProduct(id);
                if (rowsAffected > 0)
                    return Ok($"Rows affected: {rowsAffected}");
                return NotFound("Id not found");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            try
            {
                int rowsAffected = ADO_Product.InsertProduct(product);
                if (rowsAffected > 0)
                    return Ok($"Rows affected: {rowsAffected}");
                return NotFound("Id not found");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] Product product)
        {
            try
            {
                int rowsAffected = ADO_Product.UpdateProduct(product);
                if (rowsAffected > 0)
                    return Ok($"Rows affected: {rowsAffected}");
                return NotFound("Id not found");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
