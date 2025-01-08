using System.Windows;

namespace aplikace_zaznamnik_porad
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var databaseService = new DatabaseService();
            databaseService.InitializeDatabase(); // Inicializace databáze
            DataContext = new ProgramViewModel(databaseService);
        }

    }
}
