using aplikace_zaznamnik_porad.databaze;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace aplikace_zaznamnik_porad
{
    public class HlasovaniViewModel : ViewModelBase
    {
        private readonly Window _window;
        private readonly DatabaseService _databaseService; // Přidání _databaseService

        public ObservableCollection<BodProgramu> BodyProgramu { get; }
        public ObservableCollection<Osoba> PritomneOsoby { get; }
        public ObservableCollection<string> MoznostiHlasovani { get; }

        public BodProgramu? VybranyBodProgramu { get; set; }
        public Osoba? VybranaOsoba { get; set; }
        public string? VybraneHlasovani { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public HlasovaniViewModel(DatabaseService databaseService, ObservableCollection<BodProgramu> bodyProgramu, ObservableCollection<Osoba> pritomneOsoby, Window window)
        {
            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService)); // Ověření nulové hodnoty
            BodyProgramu = bodyProgramu;
            PritomneOsoby = pritomneOsoby;
            MoznostiHlasovani = new ObservableCollection<string> { "Pro", "Proti", "Zdržel se" };
            _window = window;

            SaveCommand = new RelayCommand(_ => Save());
            CancelCommand = new RelayCommand(_ => Cancel());
        }




        private void Save()
        {
            try
            {
                // Debug: Kontrola, zda všechny hodnoty jsou nastaveny
                if (VybranyBodProgramu == null)
                {
                    MessageBox.Show("Vyberte bod programu.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (VybranaOsoba == null)
                {
                    MessageBox.Show("Vyberte hlasující osobu.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(VybraneHlasovani))
                {
                    MessageBox.Show("Vyberte typ hlasování (Pro, Proti, Zdržel se).", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Debug: Výpis hodnot před uložením
                MessageBox.Show($"DEBUG: BodProgramuId={VybranyBodProgramu.Id}, OsobaId={VybranaOsoba.Id}, Hlasoval={VybraneHlasovani}, DatabaseServiceIsNull={_databaseService == null}");

                // Zápis do databáze
                _databaseService.AddHlasovani(new Hlasovani
                {
                    BodProgramuId = VybranyBodProgramu.Id,
                    OsobaId = VybranaOsoba.Id,
                    DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Hlasoval = VybraneHlasovani
                });

                MessageBox.Show($"Hlasování úspěšně zapsáno: {VybranaOsoba.Jmeno} hlasoval/a '{VybraneHlasovani}' pro bod '{VybranyBodProgramu.Nazev}'.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                // Debug: Výpis chyby
                MessageBox.Show($"Chyba při ukládání hlasování: {ex.Message}\n{ex.StackTrace}", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }









        private void Cancel()
        {
            
        }
    }
}
