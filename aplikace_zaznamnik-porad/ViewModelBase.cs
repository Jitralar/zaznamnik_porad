using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace aplikace_zaznamnik_porad
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Metoda pro vyvolání události změny vlastnosti.
        /// </summary>
        /// <param name="propertyName">Název vlastnosti, která se změnila.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Nastaví hodnotu vlastnosti a vyvolá událost změny vlastnosti.
        /// </summary>
        /// <typeparam name="T">Typ vlastnosti.</typeparam>
        /// <param name="field">Referenční proměnná vlastnosti.</param>
        /// <param name="value">Nová hodnota vlastnosti.</param>
        /// <param name="propertyName">Název vlastnosti.</param>
        /// <returns>True, pokud byla hodnota změněna, jinak False.</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
