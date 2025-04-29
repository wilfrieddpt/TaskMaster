namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Enregistrement de la route "edit"
            Routing.RegisterRoute("edit", typeof(Pages.EditTaskPage)); // Remplace EditPage par le nom réel de ta page d'édition
        }
    }
}
