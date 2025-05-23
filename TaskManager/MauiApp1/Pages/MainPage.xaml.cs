﻿using System.Collections.ObjectModel;
using MauiApp1.Models;
using MauiApp1.Services;

namespace MauiApp1.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly TacheService _tacheService;

        // Remplacer ObservableCollection par une List pour tester
        public List<Tache> Taches { get; set; } = new List<Tache>();


        public MainPage(TacheService tacheService)
        {
            BindingContext = this;
            System.Diagnostics.Debug.WriteLine("=== Étape 4 atteinte ===");

            InitializeComponent();
            _tacheService = tacheService;

            System.Diagnostics.Debug.WriteLine("=== Étape 5 atteinte ===");


        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Console.WriteLine("OnAppearing called");

            // Vérification du BindingContext
            Console.WriteLine($"BindingContext: {BindingContext}");

            await ChargerTaches();
        }


        private async Task ChargerTaches()
        {
            var tachesDepuisBdd = await _tacheService.GetTachesAsync();
            Console.WriteLine($"Tâches récupérées : {tachesDepuisBdd.Count}");

            // Assure-toi que la modification de la collection se fait sur le thread principal
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Taches.Clear();  // Remplacer Clear() pour List
                foreach (var t in tachesDepuisBdd)
                {
                    Console.WriteLine($"Tâche : {t.Titre}");
                    Taches.Add(t);  // Remplacer Add() pour List
                }

                // Forcer un rafraîchissement de la CollectionView
                TacheCollectionView.ItemsSource = null;
                TacheCollectionView.ItemsSource = Taches;
            });
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

        private async void OnSupprimerClicked(object sender, EventArgs e)
        {
            var bouton = sender as Button;
            var tache = bouton?.CommandParameter as Tache;
            if (tache != null)
            {
                var result = await DisplayAlert("Confirmation", "Voulez-vous vraiment supprimer cette tâche ?", "Oui", "Non");
                if (result)
                {
                    // Appeler la méthode de suppression ici
                    // await _tacheService.DeleteTacheAsync(tache.Id);
                    await ChargerTaches();
                }
            }
        }

        private async void OnDeconnexionClicked(object sender, EventArgs e) 
        {
            var result = await DisplayAlert("Confirmation", "Voulez-vous vraiment vous déconnecter ?", "Oui", "Non");
            if (result)
            {
                // Logique de déconnexion ici
                await Shell.Current.GoToAsync("//login");
            }
        }

        private async void OnAjouterClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("add");
        }
    }
}
