using MauiApp1.back_end.Models;
using MauiApp1.back_end.Services;

public class LoginViewModel : BaseViewModel
{
    private readonly IUserService _userService;

    public LoginViewModel(IUserService userService)
    {
        _userService = userService;
    }

    public string Email { get; set; }
    public string Password { get; set; }

    public Command LoginCommand => new Command(async () => await LoginAsync());

    private async Task LoginAsync()
    {
        if (await _userService.LoginAsync(Email, Password))
        {
            await Application.Current.MainPage.DisplayAlert("Succès", "Connexion réussie", "OK");
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Erreur", "Email ou mot de passe incorrect", "OK");
        }
    }
}
