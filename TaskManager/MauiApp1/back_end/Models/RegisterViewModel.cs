using MauiApp1.back_end.Services;
namespace MauiApp1.back_end.Models
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IUserService _userService;

        // Constructeur sans paramètre requis pour XAML
        public RegisterViewModel()
        {
            // Vous pouvez lever une exception ici si ce constructeur est utilisé par erreur
            throw new InvalidOperationException("Ce constructeur est uniquement utilisé par le XAML. Utilisez l'injection de dépendances.");
        }

        // Constructeur avec injection de dépendances
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
                await Application.Current.MainPage.DisplayAlert("Succès", "Compte créé avec succès", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Email déjà utilisé", "OK");
            }
        }
    }
}
