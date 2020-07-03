using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrimerParcialEjemplo.BLL;
using PrimerParcialEjemplo.DAL;
using PrimerParcialEjemplo.Models;

namespace PrimerParcialEjemplo.Pages.Login
{
    public class LoginModel : PageModel
    {
        ToastService ToastService = new ToastService();
        public string ReturnUrl { get; set; }
        Usuario Usuarios = new Usuario();
        Contexto contexto = new Contexto();
        List<Usuario> ListaUsuarios = new List<Usuario>();


        public async Task<ActionResult> OnGetAsync(string paramUsername, string paramPassword)
        {
            string ReturnUrl = Url.Content("~/");
            bool paso = false;
            try
            {

                await HttpContext
                    .SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }

            catch
            { }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, paramUsername),
                new Claim(ClaimTypes.Role, UsuarioBLL.NivelUsuario(paramUsername)),

            };
            if (paramUsername == null || paramPassword == null)
            {
                return LocalRedirect(ReturnUrl);
            }

            string User = paramUsername;
            string Pass = paramPassword;

            paso = UsuarioBLL.VerificarExistenciaYClaveDelUsuario(User, Pass);

            if (!paso)
            {
                return LocalRedirect(ReturnUrl);

            }


            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = this.Request.Host.Value
            };
            try
            {
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return LocalRedirect(ReturnUrl);
        }
    }
}