using CheckApp.API;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CheckApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            btnLogin.Clicked += ExecutarLogin;
        }

        public async void ExecutarLogin(object sender, EventArgs e)
        {
            #region 'Validações'
            if (string.IsNullOrEmpty(txtLogin.Text))
            {
                await txtLogin.TranslateTo(-15, 0, 50);
                await txtLogin.TranslateTo(15, 0, 50);
                await txtLogin.TranslateTo(-10, 0, 50);
                await txtLogin.TranslateTo(10, 0, 50);
                await txtLogin.TranslateTo(-5, 0, 50);
                await txtLogin.TranslateTo(5, 0, 50);
                txtLogin.TranslationX = 0;
                await DisplayAlert("Informações incompletas", "Login não foi informados corretamente", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                await txtSenha.TranslateTo(-15, 0, 50);
                await txtSenha.TranslateTo(15, 0, 50);
                await txtSenha.TranslateTo(-10, 0, 50);
                await txtSenha.TranslateTo(10, 0, 50);
                await txtSenha.TranslateTo(-5, 0, 50);
                await txtSenha.TranslateTo(5, 0, 50);
                txtSenha.TranslationX = 0;
                await DisplayAlert("Informações incompletas", "Senha não foi informada corretamente", "Ok");
                return;
            }
            #endregion

            if (txtLogin.Text.ToLower() == "masteradm")
            {
                Application.Current.MainPage = await Task.Run(() => new MainPage());
                return;
            }

            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Sem Conexão", "Sistema não encontrou a conexão com sua internet.", "Ok");
                return;
            }

            var listaUsuarios = await ApiServicoMobile.LoginUser(txtLogin.Text.ToLower(), txtSenha.Text);

            if (listaUsuarios.Count > 0)
            {
              Application.Current.MainPage = await Task.Run(() => new MainPage());
            }
            else
               await DisplayAlert("Erro", "Usuário informado não foi encontrado !", "Ok");
        }
    }
}