using aplikace_zaznamnik_porad.databaze;
using System.Collections.ObjectModel;

namespace aplikace_zaznamnik_porad
{
    public class ProgramViewModel : ViewModelBase
    {
        private readonly DatabaseService _databaseService;

        public ObservableCollection<Osoba> SeznamOsob { get; set; }
        public ObservableCollection<ProgramPorady> SeznamPorad { get; set; }
        public ObservableCollection<object> ZobrazenáData { get; set; }
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

        public ProgramViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            SeznamOsob = new ObservableCollection<Osoba>(_databaseService.GetAllOsoby());
            SeznamPorad = new ObservableCollection<ProgramPorady>(_databaseService.GetAllPrograms());
            ZobrazeniMoznosti = new ObservableCollection<string> { "Osoby", "Přehled porad" };
            ZobrazenáData = new ObservableCollection<object>();
        }

        private void AktualizujZobrazeni()
        {
            ZobrazenáData.Clear();
            switch (VybraneZobrazeni)
            {
                case "Osoby":
                    foreach (var osoba in SeznamOsob)
                        ZobrazenáData.Add(osoba);
                    break;
                case "Přehled porad":
                    foreach (var porada in SeznamPorad)
                        ZobrazenáData.Add(porada);
                    break;
            }
        }
    }
}
