using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using aplikace_zaznamnik_porad.databaze;

namespace aplikace_zaznamnik_porad
{
    public class HlasovaniViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Osoba> Ucastnici { get; set; }
        public BodProgramu BodProgramu { get; set; }

        // Command to save vote
        public ICommand SaveVoteCommand { get; }

        public HlasovaniViewModel()
        {
            SaveVoteCommand = new RelayCommand(SaveVote);
        }

        private void SaveVote() { /* Logic to save votes */ }
    }

}
