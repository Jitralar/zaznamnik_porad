using aplikace_zaznamnik_porad.databaze;
using System.Windows;
using System.Windows.Input;

namespace aplikace_zaznamnik_porad
{
    public class NovyBodProgramuViewModel : ViewModelBase
    {
        private readonly Window _window;

        public string Nazev { get; set; }
        public string Text { get; set; } // Volitelné pole

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public NovyBodProgramuViewModel(BodProgramu bodProgramu, Window window)
        {
            Nazev = bodProgramu.Nazev;
            Text = bodProgramu.Text;
            _window = window;

            SaveCommand = new RelayCommand(_ => Save(bodProgramu));
            CancelCommand = new RelayCommand(_ => Cancel());
        }

        private void Save(BodProgramu bodProgramu)
        {
            bodProgramu.Nazev = Nazev;
            bodProgramu.Text = Text;
            _window.DialogResult = true;
            _window.Close();
        }

        private void Cancel()
        {
            _window.DialogResult = false;
            _window.Close();
        }
    }
}
