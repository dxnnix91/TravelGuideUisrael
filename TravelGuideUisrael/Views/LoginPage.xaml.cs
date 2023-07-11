using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuideUisrael;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly IGoogleManager _googleManager;
        GoogleUser GoogleUser = new GoogleUser();
        public bool IsLogedIn { get; set; }

        public LoginPage()
        {
            _googleManager = DependencyService.Get<IGoogleManager>();
            CheckUserLoggedIn();
            InitializeComponent();            
        }

        private void CheckUserLoggedIn()
        {
            _googleManager.Login(OnLoginComplete);
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            _googleManager.Login(OnLoginComplete);
        }
        private void OnLoginComplete(GoogleUser googleUser, string message)
        {
            if (googleUser != null)
            {
                GoogleUser = googleUser;
                txtName.Text = "Nombre: "+GoogleUser.Name;
                txtEmail.Text = "Correo: "+GoogleUser.Email;
                imgProfile.Source = GoogleUser.Picture;
                IsLogedIn = true;
            }
            else
            {
                DisplayAlert("Message", message, "Ok");
            }
        }
        private void GoogleLogout()
        {
            _googleManager.Logout();
            IsLogedIn = false;
        }
        private void btnLogout_Clicked(object sender, EventArgs e)
        {
            _googleManager.Logout();
            
            String usuario = txtName.Text;
            String correo = txtEmail.Text;
            //Image imagen = imgProfile.Source;
            
            txtName.Text = "Name :";
            txtEmail.Text = "Email: ";
            imgProfile.Source = "";
        }

        private void btnContinuar_Clicked(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new Home());
        }
    }
}