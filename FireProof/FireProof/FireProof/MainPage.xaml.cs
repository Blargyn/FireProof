using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FireProof
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        async void viewClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new viewAndManagePage());
        }

        async void infoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new infoPage());
        }

        async void faqClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new faqPage());
        }
    }
}
