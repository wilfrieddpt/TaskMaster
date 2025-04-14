using MauiApp1.back_end.Services;
namespace MauiApp1.back_end.Models
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IUserService _userService;

        // Constructeur sans param�tre requis pour XAML
        public RegisterViewModel()
        {
            // Vous pouvez lever une exception ici si ce constructeur est utilis� par erreur
            throw new InvalidOperationException("Ce constructeur est uniquement utilis� par le XAML. Utilisez l'injection de d�pendances.");
        }

        // Constructeur avec injection de d�pendances
        public RegisterViewModel(IUserService userService)
        {
            _userService = userService;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public Command RegisterCommand => new Command(async () => await RegisterAsync());

        private async Task RegisterAsync()
        {
            if (await _userService.RegisterAsync(Email, Password, Nom, Prenom))
            {
                await Application.Current.MainPage.DisplayAlert("Succ�s", "Compte cr�� avec succ�s", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Email d�j� utilis�", "OK");
            }
        }
    }
}
