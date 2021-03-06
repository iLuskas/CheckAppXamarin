﻿using CheckApp.API;
using ServicoMobile;
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
    public partial class EmpresaPage : ContentPage
    {
        public EmpresaPage()
        {
            InitializeComponent();

            MontaListViewEmpresas();
        }

        private async void MontaListViewEmpresas()
        {

            var listaUsuarios = await ApiServicoMobile.GetUsuario();
            ListViewEmpresas.ItemsSource = listaUsuarios.ToList();
        }

        private async void OnImgAddClicked1(object sender, EventArgs e)
        {
            await((Image)sender).ScaleTo(0, 50, Easing.Linear);
            await Task.Delay(100);
            await((Image)sender).ScaleTo(1, 50, Easing.Linear);

            if (FloatMenuItem1.IsVisible == false)
                ExibirMenuFlutuante();
            else
                OcultarMenuFlutuante();
        }

        private async void ExibirMenuFlutuante()
        {
            FloatMenuItem1.IsVisible = true;
            await FloatMenuItem1.TranslateTo(0, 0, 100, Easing.SinIn);
            await FloatMenuItem1.TranslateTo(0, -20, 100, Easing.SinIn);
            await FloatMenuItem1.TranslateTo(0, 0, 200, Easing.SinIn);

            FloatMenuItem2.IsVisible = true;
            await FloatMenuItem2.TranslateTo(0, 0, 100);
            await FloatMenuItem2.TranslateTo(0, -20, 100);
            await FloatMenuItem2.TranslateTo(0, 0, 200);

            FloatMenuItem3.IsVisible = true;
            await FloatMenuItem3.TranslateTo(0, 0, 100);
            await FloatMenuItem3.TranslateTo(0, -20, 100);
            await FloatMenuItem3.TranslateTo(0, 0, 200);
        }

        private async void OcultarMenuFlutuante()
        {
            await FloatMenuItem1.TranslateTo(0, 0, 100);
            await FloatMenuItem1.TranslateTo(0, -20, 100);
            await FloatMenuItem1.TranslateTo(0, 0, 200);
            FloatMenuItem1.IsVisible = false;
            
            await FloatMenuItem2.TranslateTo(0, 0, 100);
            await FloatMenuItem2.TranslateTo(0, -20, 100);
            await FloatMenuItem2.TranslateTo(0, 0, 200);
            FloatMenuItem2.IsVisible = false;

            await FloatMenuItem3.TranslateTo(0, 0, 100);
            await FloatMenuItem3.TranslateTo(0, -20, 100);
            await FloatMenuItem3.TranslateTo(0, 0, 200);
            FloatMenuItem3.IsVisible = false;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await ((StackLayout)sender).ScaleTo(0, 50, Easing.Linear);
            await Task.Delay(100);
            await ((StackLayout)sender).ScaleTo(1, 50, Easing.Linear);
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await ((StackLayout)sender).ScaleTo(0, 50, Easing.Linear);
            await Task.Delay(100);
            await ((StackLayout)sender).ScaleTo(1, 50, Easing.Linear);
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            await ((StackLayout)sender).ScaleTo(0, 50, Easing.Linear);
            await Task.Delay(100);
            await ((StackLayout)sender).ScaleTo(1, 50, Easing.Linear);
        }
    }
}