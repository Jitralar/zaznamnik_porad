using aplikace_zaznamnik_porad.databaze;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace aplikace_zaznamnik_porad
{
    public class ProgramViewModel : ViewModelBase
    {
        private readonly DatabaseService _databaseService;

        public ObservableCollection<ProgramPorady> SeznamPorad { get; set; }
        public ObservableCollection<Osoba> SeznamOsob { get; set; }
        public ObservableCollection<object> ZobrazenáData { get; set; }

        // Nová vlastnost ZobrazeniMoznosti
        public ObservableCollection<string> ZobrazeniMoznosti { get; set; }

        // Nová vlastnost VybraneZobrazeni
        private string _vybraneZobrazeni;
        public string VybraneZobrazeni
        {
            get => _vybraneZobrazeni;
            set
            {
                _vybraneZobrazeni = value;
                OnPropertyChanged();
                AktualizujZobrazeni();
            }
        }

        private ProgramPorady _vybranaPorada;
        public ProgramPorady VybranaPorada
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
            SeznamPorad = new ObservableCollection<ProgramPorady>(_databaseService.GetAllPrograms());
            SeznamOsob = new ObservableCollection<Osoba>(_databaseService.GetAllOsoby());
            ZobrazenáData = new ObservableCollection<object>();

            // Inicializace ZobrazeniMoznosti
            ZobrazeniMoznosti = new ObservableCollection<string>
            {
                "Osoby",
                "Přehled porad",
                "Body programu"
            };
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
                    foreach (var osoba in SeznamOsob)
                    {
                        ZobrazenáData.Add(osoba);
                    }
                    break;
                case "Přehled porad":
                    foreach (var program in SeznamPorad)
                    {
                        ZobrazenáData.Add(program);
                    }
                    break;
                case "Body programu":
                    if (VybranaPorada != null)
                    {
                        foreach (var bod in _databaseService.GetBodyProgramu(VybranaPorada.Id))
                        {
                            ZobrazenáData.Add(bod);
                        }
                    }
                    break;
            }
        }

        // Commands
        public ICommand AddCommand => new RelayCommand(AddItem);
        public ICommand EditCommand => new RelayCommand(EditItem);
        public ICommand DeleteCommand => new RelayCommand(DeleteItem);

        private void AddItem() { /* Logika pro přidání */ }
        private void EditItem() { /* Logika pro editaci */ }
        private void DeleteItem() { /* Logika pro mazání */ }
    }
}
