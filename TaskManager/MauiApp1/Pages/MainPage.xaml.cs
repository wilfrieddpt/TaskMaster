using System.Collections.ObjectModel;

namespace MauiApp1.Pages
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Tache> Taches { get; set; } = new();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ChargerTaches();
        }

        private async Task ChargerTaches()
        {
            //var service = new TacheService();
            //var tachesDepuisBdd = await service.GetTachesAsync();

            Taches.Clear();
            /*foreach (var t in tachesDepuisBdd)
                Taches.Add(t);*/
        }

        private async void OnModifierClicked(object sender, EventArgs e)
        {
            var bouton = sender as Button;
            var tache = bouton?.CommandParameter as Tache;
            if (tache != null)
            {
                // Navigue vers la page d'édition en passant la tâche (selon ton système de routing ou binding context)
                await Shell.Current.GoToAsync($"edit?tacheId={tache.Id}");
            }
        }
    }
}
