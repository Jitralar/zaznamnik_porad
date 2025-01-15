using System.Windows;

namespace aplikace_zaznamnik_porad
{
    public partial class HlasovaniWindow : Window
    {
        public HlasovaniWindow(HlasovaniViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
