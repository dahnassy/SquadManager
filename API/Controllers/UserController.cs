using API.Validator;
using Common;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase

    {

        /// <summary>
        /// Autentica o usuario
        /// </summary>
        /// <param name="username">nome do usuario</param>
        /// <param name="password">senha do usuario</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(UserModel user) {
            if(user.Password == "123")
                return Ok(new { response = "OK"});
            else
                return Ok(new { response = "ERROR" });
        }
        
        [HttpPost("create")]
        public IActionResult Create(UserModel user) {
            
            UserValidator validator = new UserValidator();

            ValidationResult results = validator.Validate(user);

            if (results.IsValid) { 
                foreach (var failure in results.Errors) {
                    Console.WriteLine("Property "+ failure.PropertyName+ "failed validation");
                }
            }


            if(user.Password == "123")
                return Ok(new { response = "OK"});
            else
                return Ok(new { response = "ERROR" });
        }
    }
}
