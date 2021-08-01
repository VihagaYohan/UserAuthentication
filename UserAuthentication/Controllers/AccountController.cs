using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAuthentication.ViewModel;

namespace UserAuthentication.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly SignInManager<IdentityUser> signInManger;

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManger)
		{
			this.userManager = userManager;
			this.signInManger = signInManger;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterVM model)
		{
			var user = new IdentityUser { UserName = model.Email, Email = model.Email };
			var result = await userManager.CreateAsync(user, model.Password);
			Console.WriteLine(result);

			await signInManger.SignInAsync(user, isPersistent: false);
			return Ok(result);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginVM model)
		{
			var result = await signInManger.PasswordSignInAsync(model.Email, model.Password,
				model.RembmerMe, false);

			if (result.Succeeded)
			{
				return Ok(result);
			}
			else
			{ 
				return BadRequest(result);
			}

		}
	}
}
