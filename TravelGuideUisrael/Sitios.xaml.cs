using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelGuideUisrael
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sitios : ContentPage
    {
        public Sitios()
        {
            InitializeComponent();
        }

        private void btnlogin_Clicked(object sender, EventArgs e)
        {
           Navigation.PushAsync(new Login());
        }
    }
}