using System.Collections.ObjectModel;
using MauiApp1.Models;
using MauiApp1.Services;

namespace MauiApp1.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly TacheService _tacheService;

        public ObservableCollection<Tache> Taches { get; set; } = new();

        public MainPage(TacheService tacheService)
        {
            BindingContext = this;
            InitializeComponent();
            _tacheService = tacheService;
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Console.WriteLine("OnAppearing called");
            await ChargerTaches();
        }

        private async Task ChargerTaches()
        {
            var tachesDepuisBdd = await _tacheService.GetTachesAsync();

            Console.WriteLine($"Tâches récupérées : {tachesDepuisBdd.Count}");

            Taches.Clear();
            foreach (var t in tachesDepuisBdd)
            {
                Console.WriteLine($"Tâche : {t.Titre}");
                Taches.Add(t);
            }
        }

        private async void OnModifierClicked(object sender, EventArgs e)
        {
            var bouton = sender as Button;
            var tache = bouton?.CommandParameter as Tache;
            if (tache != null)
            {
                await Shell.Current.GoToAsync($"edit?tacheId={tache.Id}");
            }
        }
    }
}
