using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xam.Forms.Example.Annotations;
using Xamarin.Forms;

namespace Xam.Forms.Example
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public ICommand LoadCommand { get; set; }
        public MainViewModel()
        {
            this.LoadCommand = new Command(async () => await this.InnerLoad());
        }

        private async Task InnerLoad()
        {
            try
            {
                this.IsBusy = true;
                await Task.Delay(2000); //simulate long async operation
            }
            catch (Exception e)
            {
                Console.WriteLine(e); //manage exceptions
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (this._isBusy == value) return;
                this._isBusy = value;
                this.OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}