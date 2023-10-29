using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace LocalizationInRelease
{
	public class CollectionViewViewModel : INotifyPropertyChanged
	{
        private int _selectedInt;
        public int SelectedInt { get => _selectedInt; set => SetField(ref _selectedInt, value, nameof(SelectedInt)); }
		public ObservableCollection<int> Ints { get; set; } = new();

		public CollectionViewViewModel()
		{
			Ints.Add(0);
			Increment();
		}

        // boiler-plate
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        async void Increment()
		{
			while (true)
			{
                Ints.Add(Ints.Last() + 1);
                SelectedInt = Ints.Last();
                await Task.Delay(500);
                //Ints.Remove(Ints.Last());
                //await Task.Delay(1000);
            }
        }
	}
}

