﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using PazumAnia.ViewModels;
using ZXing.Net.Mobile.Forms;
using Rg.Plugins.Popup.Services;

namespace PazumAnia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPage : Xamarin.Forms.TabbedPage
    {
        public MainTabbedPage()
        {
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            MainListView.ItemsSource = new List<string>
            {
                "Hybrydy ",
                "Flexigel",
                "Przedlu",
                "Pedicure",
                "Reg.Brwi",
                "Manicure",
            };

            //barcode
            ZXingBarcodeImageView barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView"
            };

            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode.BarcodeOptions.Width = 300;
            barcode.BarcodeOptions.Height = 300;
            barcode.BarcodeOptions.Margin = 10;
            barcode.BarcodeValue = "Paznokcie hybrydowe";

            visits.Children.Insert(1, barcode);



        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsersPage());
        }

        private void Button_ClickedGetAsync(object sender, EventArgs e)
        {
                MainViewModel mainViewModel = new MainViewModel();
                mainViewModel.InitializeDataAsync();
        }

        private async void RegisterBackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            await Navigation.PushAsync(scan);
            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    mycode.Text = result.Text;
                });
            };
        }
        private async void Popup_Clicked(object sender, EventArgs e)
        {
            Xamarin.Forms.Button button = (Xamarin.Forms.Button)sender;
            string name = button.Text;
            await PopupNavigation.Instance.PushAsync(new PopupView(name));
        }
    }
}