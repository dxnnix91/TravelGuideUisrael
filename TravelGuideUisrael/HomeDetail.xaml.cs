using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TravelGuideUisrael
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeDetail : ContentPage
    {

        public HomeDetail()
        {
           
            InitializeComponent();
            
            mymap.MoveToRegion (MapSpan.FromCenterAndRadius(
                new Position(-0.3387534, -78.5369914),
                Distance.FromKilometers(30)));

            
            
        }
    }
}