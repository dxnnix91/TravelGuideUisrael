using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelGuideUisrael
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Foto : ContentPage
	{
		public Foto ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, true);
			this.Title = "Mi camara";
		}

        private async void buttonCamara_Clicked(object sender, EventArgs e)
        {
			try
			{
				var miFoto = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
				{
					DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
					Name = DateTime.Now.ToString(),
					Directory = "FotosAlmacenadas",
					SaveToAlbum = true
				});
				if (miFoto != null)
				{
					imageCamera.Source = ImageSource.FromStream(() => { return miFoto.GetStream(); });
				}
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", ex.Message.ToString(), "Ok");
			}
        }
    }
}