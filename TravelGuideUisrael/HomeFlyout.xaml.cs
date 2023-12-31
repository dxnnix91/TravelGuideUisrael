﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SampleApp.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelGuideUisrael
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeFlyout : ContentPage
    {
        public ListView ListView;

        public HomeFlyout()
        {
            InitializeComponent();

            BindingContext = new HomeFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class HomeFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<HomeFlyoutMenuItem> MenuItems { get; set; }
            
            public HomeFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<HomeFlyoutMenuItem>(new[]
                {
                    new HomeFlyoutMenuItem { Id = 0, Title = "Mi cuenta", TargetType=typeof(ActualizarUser) },
                    new HomeFlyoutMenuItem { Id = 1, Title = "Postear",TargetType=typeof(Posteo)  },
                    new HomeFlyoutMenuItem { Id = 2, Title = "Mis Posts",TargetType=typeof(mispost) },
                    new HomeFlyoutMenuItem { Id = 3, Title = "Mapa",TargetType=typeof(HomeDetail) },
                    new HomeFlyoutMenuItem { Id = 4, Title = "Salir",TargetType=typeof(LoginPage) },
                    

                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}