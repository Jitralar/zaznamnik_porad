using aplikace_zaznamnik_porad.databaze;
using System.Windows;

namespace aplikace_zaznamnik_porad
{
    public partial class EditOsobaWindow : Window
    {
        public EditOsobaWindow(Osoba osoba)
        {
            InitializeComponent();
            DataContext = new EditOsobaViewModel(osoba, this);
        }
    }
}
