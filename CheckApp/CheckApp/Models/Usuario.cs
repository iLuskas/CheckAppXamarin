using CheckApp.Models;
using System;

namespace ServicoMobile
{
    public partial class Usuario : Base<Usuario>
    {
        public int Id { get; set; }      
        public string Username { get; set; }     
        public string Password { get; set; }


        public static string ObterRotaLogin() => "api/Usuario/Login";
    }
}
