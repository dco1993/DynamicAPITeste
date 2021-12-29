using DynamicAPI.Model;
using DynamicAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DynamicAPI.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        [Route("api/[controller]/login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]UserModel model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return new { user = user, token = token };
        }

        [HttpGet]
        [Route("api/[controller]/authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);
    }
}
