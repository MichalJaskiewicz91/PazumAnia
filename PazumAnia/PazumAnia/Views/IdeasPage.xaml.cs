using PazumAnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PazumAnia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IdeasPage : ContentPage
    {
        public IdeasPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPageTwo());
        }

        private async void GotoNewIdeaPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewIdeaPage());
        }

        private async void IdeasListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var idea = e.Item as Idea;
            await Navigation.PushAsync(new EditIdeaPage(idea));
        }

        private async void NavigateToSearchIdeas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}