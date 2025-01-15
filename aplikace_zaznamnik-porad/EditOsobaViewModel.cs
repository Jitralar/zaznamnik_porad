using aplikace_zaznamnik_porad.databaze;
using System.Windows;
using System.Windows.Input;

namespace aplikace_zaznamnik_porad
{
    public class EditOsobaViewModel : ViewModelBase
    {
        private readonly Window _window;

        public Osoba Osoba { get; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public EditOsobaViewModel(Osoba osoba, Window window)
        {
            Osoba = osoba; // Předaný objekt osoby s ID
            _window = window;

            SaveCommand = new RelayCommand(_ => Save());
            CancelCommand = new RelayCommand(_ => Cancel());
        }

        private void Save()
        {
            // Zavření okna s potvrzením
            _window.DialogResult = true;
            _window.Close();
        }

        private void Cancel()
        {
            // Zavření okna bez uložení
            _window.DialogResult = false;
            _window.Close();
        }
    }
}
