using CheckApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CheckApp.Models
{
    public class MenuItemPage
    {
        private static ObservableCollection<MasterPageItem> ListaMenu { get; set; }

        public static ObservableCollection<MasterPageItem> GetMasterPageItems()
        {
            ListaMenu = new ObservableCollection<MasterPageItem>() 
            {
              new MasterPageItem(){ Title = "Home", Icone = "Home.png", TargetType = typeof(HomePage)},
              new MasterPageItem(){ Title = "Perfil", Icone = "Perfil.png", TargetType = typeof(PerfilPage)},
              new MasterPageItem(){ Title = "Empresas", Icone = "Empresas.png", TargetType = typeof(EmpresaPage)},
              new MasterPageItem(){ Title = "Equipamento", Icone = "Equipamentos.png", TargetType = typeof(EquipamentoPage)},
              new MasterPageItem(){ Title = "Manutenções", Icone = "Manutencao.png", TargetType = typeof(ManutencaoPage)},
              new MasterPageItem(){ Title = "Relatórios", Icone = "Relatorios.png", TargetType = typeof(RelatorioPage)}
            };

            return ListaMenu;
        }

    }
}
