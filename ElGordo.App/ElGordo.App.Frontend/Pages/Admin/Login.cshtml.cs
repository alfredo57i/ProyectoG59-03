using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ElGordo.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using ElGordo.App.Dominio;
using System.ComponentModel.DataAnnotations;

namespace ElGrodo.App.Frontend.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IRepositorioUsuario _repUsuario;

        public LoginModel()
        {
            this._repUsuario = new RepositorioUsuario(new ElGordo.App.Persistencia.AppContext());
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string usuario,string password)
        {
            //Valida si los campos introducidos son correctos
            if(!ModelState.IsValid) return Page();
            var login = _repUsuario.Login(usuario,password);
            if(login!=null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, "admin")
                };
                //Crea una cookie para mantener la sesión
                var identity = new ClaimsIdentity(claims, "CookieAdmin");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("CookieAdmin",claimsPrincipal).ConfigureAwait(false);
                return RedirectToPage("/Admin/Index");
            }
            //Devuelve el mensaje de error
            ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Danger, "<span class='small'>Usuario o Contraseña incorrectos</span>");
            return Page();
        }
    }
}
