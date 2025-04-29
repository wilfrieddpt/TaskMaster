using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.back_end.Models;


namespace MauiApp1.Pages
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage(RegisterViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///login");
        }

        private async void GoToLoginCommand(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.GoToAsync("///login");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur de navigation : {ex.Message}");
            }
        }
    }
}

