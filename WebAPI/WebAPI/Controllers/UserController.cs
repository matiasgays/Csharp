using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet("LogIn")]
        public ActionResult<User>? Get([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                return Ok(ADO_User.LogIn(username, password));
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message} User and password not found.");
            }
        }

        [HttpGet("{username}")]
        public ActionResult<User>? GetUserName(string username)
        {
            try
            {
                return Ok(ADO_User.SelectUsername(username));
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message} User and password not found.");
            }
        }

        /*[HttpGet("{id}")]
        public ActionResult<User>? GetId(long id)
        {
            try
            {
                return Ok(ADO_User.SelectUser(id));
            }
            catch (Exception ex) {
                return Problem(ex.Message);
            }  
        }*/

        [HttpGet]
        public ActionResult<List<User>>? Get()
        {
            try
            {
                return Ok(ADO_User.SelectUsers());
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
                int rowsAffected = ADO_User.DeleteUser(id);
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
        public ActionResult Post([FromBody] User user)
        {
            try
            {
                int rowsAffected = ADO_User.InsertUser(user);
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
        public ActionResult Put([FromBody] User user)
        {
            try
            {
                int rowsAffected = ADO_User.UpdateUser(user);
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
