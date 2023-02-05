using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using jwtapp.front.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;

namespace jwtapp.front.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpclientfactory;

        public AccountController(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }

        public IActionResult Login()
        {
            return View(new UserLoginModel());
        }
        [HttpPost]
          public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpclientfactory.CreateClient();

                var content = new StringContent(JsonSerializer.Serialize(model),Encoding.UTF8,"application/json");

                var response = await client.PostAsync("https://localhost:7021/api/Auth/Login",content);
                if (response.IsSuccessStatusCode)
                {
                    var jsondata = await response.Content.ReadAsStringAsync();
                    var tokenmodel = JsonSerializer.Deserialize<JwtTokenResponseModel>(jsondata, new JsonSerializerOptions{
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        
                    });

                    if (tokenmodel != null)
                    {
                        JwtSecurityTokenHandler handler = new();
                        var token = handler.ReadJwtToken(tokenmodel.Token);
                        
                    var claimsIdentity = new ClaimsIdentity(
                        token.Claims,JwtBearerDefaults.AuthenticationScheme);

                    var authProps = new AuthenticationProperties
                    {
                        ExpiresUtc  = tokenmodel.ExpireDate,
                        IsPersistent = true
                    };
                    await HttpContext.SignInAsync(
                        JwtBearerDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProps);
                        return RedirectToAction("Index","Home");
                    }

                }
                else
                {
                    ModelState.AddModelError("","Kullanıcı adı veya şifre hatalı");
                }
                return View();    
            }
            return View(model);
            
        }

        
    }
}