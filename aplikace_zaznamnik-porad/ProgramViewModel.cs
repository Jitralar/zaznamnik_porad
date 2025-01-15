using aplikace_zaznamnik_porad.databaze;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace aplikace_zaznamnik_porad
{
    public class ProgramViewModel : ViewModelBase
    {
        private readonly DatabaseService _databaseService;

        public ObservableCollection<Osoba> SeznamOsob { get; set; }
        public ObservableCollection<object> ZobrazenáData { get; set; }
        public ObservableCollection<ProgramPorady> SeznamPorad { get; set; }



        private Osoba? _vybranaOsoba;
        public Osoba? VybranaOsoba
        {
            get => _vybranaOsoba;
            set
            {
                _vybranaOsoba = value;
                OnPropertyChanged();
            }
        }

        public ProgramViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;

            // Load data
            SeznamOsob = new ObservableCollection<Osoba>(_databaseService.GetAllOsoby());
            ZobrazenáData = new ObservableCollection<object>(SeznamOsob);
            SeznamPorad = new ObservableCollection<ProgramPorady>(_databaseService.GetAllPrograms());

        }

        // ADD Command
        public ICommand AddCommand => new RelayCommand(_ =>
        {
            var novaOsoba = new Osoba { Jmeno = "Nové", Prijmeni = "Jméno" };
            _databaseService.AddOsoba(novaOsoba.Jmeno, novaOsoba.Prijmeni);
            SeznamOsob.Add(novaOsoba);
            AktualizujZobrazeni();
        });

        // EDIT Command
        public ICommand EditCommand => new RelayCommand(_ =>
        {
            if (VybranaOsoba != null)
            {
                // Vytvoření kopie vybrané osoby pro úpravu
                var osobaKEditaci = new Osoba
                {
                    Id = VybranaOsoba.Id,
                    Jmeno = VybranaOsoba.Jmeno,
                    Prijmeni = VybranaOsoba.Prijmeni
                };

                // Otevření editačního okna
                var editWindow = new EditOsobaWindow(osobaKEditaci);
                if (editWindow.ShowDialog() == true) // Pokud uživatel potvrdí změny
                {
                    // Uložení změn do databáze
                    _databaseService.UpdateOsoba(osobaKEditaci.Id, osobaKEditaci.Jmeno, osobaKEditaci.Prijmeni);

                    // Aktualizace původní osoby v seznamu
                    VybranaOsoba.Jmeno = osobaKEditaci.Jmeno;
                    VybranaOsoba.Prijmeni = osobaKEditaci.Prijmeni;
                    OnPropertyChanged(nameof(SeznamOsob)); // Aktualizace UI
                    AktualizujZobrazeni();
                }
            }
            else
            {
                MessageBox.Show("Vyberte osobu k úpravě.");
            }
        });



        // DELETE Command
        public ICommand DeleteCommand => new RelayCommand(_ =>
        {
            if (VybranaOsoba != null)
            {
                _databaseService.DeleteOsoba(VybranaOsoba.Id);
                SeznamOsob.Remove(VybranaOsoba);
                AktualizujZobrazeni();
            }
            else
            {
                MessageBox.Show("Vyberte osobu k odstranění.");
            }
        });

        private void AktualizujZobrazeni()
        {
            ZobrazenáData.Clear();
            foreach (var osoba in SeznamOsob)
                ZobrazenáData.Add(osoba);
        }

        public ICommand NovaPoradaCommand => new RelayCommand(_ =>
        {
            // Vytvoření nového záznamu ProgramPorady
            var novaPorada = new ProgramPorady
            {
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), // Časové razítko
                Lokace = "nespecifikováno" // Výchozí místo porady
            };

            // Uložení do databáze
            _databaseService.AddProgram(novaPorada.Date, novaPorada.Lokace);

            // Přidání do kolekce SeznamPorad
            SeznamPorad.Add(novaPorada);

            // Obnovíme ComboBox (není nutné, pokud je binding nastaven správně)
            OnPropertyChanged(nameof(SeznamPorad));
        });



    }
}
