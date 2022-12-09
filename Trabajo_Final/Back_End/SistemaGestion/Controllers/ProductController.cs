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
        public ActionResult Delete([FromQuery] long id)
        {
            try
            {
                return Ok(ADO_Product.DeleteProduct(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<List<Product>>? Post([FromBody] Product product)
        {
            try
            {
                return Ok(ADO_Product.InsertProduct(product));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<List<Product>>? Put([FromBody] Product product)
        {
            try
            {
                return Ok(ADO_Product.UpdateProduct(product));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
