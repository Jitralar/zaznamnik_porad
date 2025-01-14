using System.Collections.ObjectModel;
using System.Windows.Input;
using aplikace_zaznamnik_porad.databaze;

namespace aplikace_zaznamnik_porad
{
    public class ProgramViewModel : ViewModelBase
    {
        private readonly DatabaseService _databaseService;

        public ObservableCollection<ProgramPorady> SeznamPorad { get; set; }
        public ObservableCollection<Osoba> SeznamOsob { get; set; }
        public ObservableCollection<object> ZobrazenáData { get; set; }

        public ObservableCollection<JmenoBool> JmenaBool { get; set; } // Kolekce pro ListBox

        public ObservableCollection<string> ZobrazeniMoznosti { get; set; }


        private string? _vybraneZobrazeni;
        public string? VybraneZobrazeni
        {
            get => _vybraneZobrazeni;
            set
            {
                _vybraneZobrazeni = value;
                OnPropertyChanged();
                AktualizujZobrazeni();
            }
        }


        private ProgramPorady? _vybranaPorada = null;
        public ProgramPorady? VybranaPorada
        {
            get => _vybranaPorada;
            set
            {
                _vybranaPorada = value;
                OnPropertyChanged();
                NactiBodyProgramu();
            }
        }



        public ProgramViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            _databaseService.InitializeDatabase();

            SeznamOsob = new ObservableCollection<Osoba>(_databaseService.GetAllOsoby());
            Console.WriteLine($"Počet načtených osob: {SeznamOsob.Count}"); // Debugging

            SeznamPorad = new ObservableCollection<ProgramPorady>(_databaseService.GetAllPrograms());
            //SeznamOsob = new ObservableCollection<Osoba>(_databaseService.GetAllOsoby());
            ZobrazenáData = new ObservableCollection<object>();

            ZobrazeniMoznosti = new ObservableCollection<string>
            {
                "Osoby",
                "Přehled porad",
                "Body programu"
            };

            // Inicializace JmenaBool
            JmenaBool = new ObservableCollection<JmenoBool>();
            foreach (var osoba in SeznamOsob)
            {
                JmenaBool.Add(new JmenoBool
                {
                    Jmeno = $"{osoba.Jmeno} {osoba.Prijmeni}",
                    Check = false // Výchozí hodnota
                });
            }
        }

        private void NactiBodyProgramu()
        {
            if (VybranaPorada != null)
            {
                ZobrazenáData.Clear();
                foreach (var bod in _databaseService.GetBodyProgramu(VybranaPorada.Id))
                {
                    ZobrazenáData.Add(bod);
                }
            }
        }

        private void AktualizujZobrazeni()
        {
            ZobrazenáData.Clear();

            switch (VybraneZobrazeni)
            {
                case "Osoby":
                    Console.WriteLine("Zobrazení: Osoby");
                    foreach (var osoba in SeznamOsob)
                    {
                        ZobrazenáData.Add(osoba);
                    }
                    break;

                case "Přehled porad":
                    Console.WriteLine("Zobrazení: Přehled porad");
                    foreach (var program in SeznamPorad)
                    {
                        ZobrazenáData.Add(program);
                    }
                    break;

                case "Body programu":
                    Console.WriteLine("Zobrazení: Body programu");
                    if (VybranaPorada != null)
                    {
                        foreach (var bod in _databaseService.GetBodyProgramu(VybranaPorada.Id))
                        {
                            ZobrazenáData.Add(bod);
                        }
                    }
                    break;
            }

            Console.WriteLine($"Počet zobrazených dat: {ZobrazenáData.Count}");
        }


        public ICommand AddCommand => new RelayCommand(_ => AddItem());
        public ICommand EditCommand => new RelayCommand(_ => EditItem());
        public ICommand DeleteCommand => new RelayCommand(_ => DeleteItem());

        private void AddItem() { /* Logika pro přidání */ }
        private void EditItem() { /* Logika pro editaci */ }
        private void DeleteItem() { /* Logika pro mazání */ }

    }
}
