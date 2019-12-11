using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SistemaBebida.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : Controller
    {
        private SignInManager<ApplicationUser> _signManager;
        private UserManager<ApplicationUser> _userManager;

        public IdentityController(SignInManager<ApplicationUser> signManager, UserManager<ApplicationUser> userManager)
        {
            _signManager = signManager;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<int> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signManager.SignInAsync(user, false);
                    return 1;
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return 0;
                }
            }
            return 100;
        }

        [HttpPost("login")]
        public async Task<string> Login(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signManager.PasswordSignInAsync(model.Username,
                   model.Password, false, false);

                if (result.Succeeded)
                {
                    return model.Username;
                }
                else
                {
                    return "não deu certo, login ou senha errados";
                }
            }
            else
            {
                return "tentativa de login invalida";
            }
        }
    }
}