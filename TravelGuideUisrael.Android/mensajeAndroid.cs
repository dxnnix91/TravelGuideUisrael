using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelGuideUisrael.Droid;

[assembly:Xamarin.Forms.Dependency(typeof(mensajeAndroid))]

namespace TravelGuideUisrael.Droid
{
    public class mensajeAndroid : Mensaje
    {
        public void longAlert(string mensaje)
        {
            Toast.MakeText(Application.Context,mensaje,ToastLength.Long).Show();
        }

        public void shortAlert(string mensaje)
        {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Short).Show();
        }
    }
}