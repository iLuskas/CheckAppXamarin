using CheckApp.Util;
using Newtonsoft.Json;
using ServicoMobile;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CheckApp.API
{
    public static class ApiServicoMobile
    {
        public const string url = "https://localhost:5001";

        public static async Task<List<Usuario>> LoginUser(string username, string password)
        {
            var usuario = new Usuario()
            {
                Username = username,
                Password = password
            }; 

            var uri = string.Format("{0}/{1}", url, Usuario.ObterRotaLogin());
            var response = Utilidades.RequestByPost(uri, usuario.ToJson());

            return Usuario.FromJsonList(response.ToString());
        }
    }
}
