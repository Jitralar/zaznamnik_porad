using aplikace_zaznamnik_porad.databaze;
using System.Windows;

namespace aplikace_zaznamnik_porad
{
    public partial class NovyBodProgramuWindow : Window
    {
        public NovyBodProgramuWindow(BodProgramu bodProgramu)
        {
            InitializeComponent();
            DataContext = new NovyBodProgramuViewModel(bodProgramu, this);
        }
    }
}
