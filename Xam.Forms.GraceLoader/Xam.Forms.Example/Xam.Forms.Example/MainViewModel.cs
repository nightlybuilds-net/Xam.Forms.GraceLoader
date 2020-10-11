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

        public string[] Types => new[] {"Square", "Square Image", "Circle", "Circle Image"};
        public int SelectedTypeIndex { get; set; }
        
        public ICommand LoadCommand { get; set; }
        public MainViewModel()
        {
            this.LoadCommand = new Command(async () => await this.InnerLoad());
        }

        private async Task InnerLoad()
        {
            try
            {
                switch (this.SelectedTypeIndex)
                {
                    case 0:
                        IsSquareVisible = true;
                        IsSquareImageVisible = false;
                        IsCircleVisible = false;
                        IsCircleImageVisible = false;
                        break;
                    case 1:
                        IsSquareVisible = false;
                        IsSquareImageVisible = true;
                        IsCircleVisible = false;
                        IsCircleImageVisible = false;
                        break;
                    case 2:
                        IsSquareVisible = false;
                        IsSquareImageVisible = false;
                        IsCircleVisible = true;
                        IsCircleImageVisible = false;
                        break;
                    case 3:
                        IsSquareVisible = false;
                        IsSquareImageVisible = false;
                        IsCircleVisible = false;
                        IsCircleImageVisible = true;
                        break;
                }
                
                await Task.Delay(2000); //simulate long async operation
            }
            catch (Exception e)
            {
                Console.WriteLine(e); //manage exceptions
            }
            finally
            {
                IsSquareVisible = false;
                IsSquareImageVisible = false;
                IsCircleVisible = false;
                IsCircleImageVisible = false;
            }
        }

        private bool _isSquareVisible;
        public bool IsSquareVisible
        {
            get => _isSquareVisible;
            set
            {
                if (this._isSquareVisible == value) return;
                this._isSquareVisible = value;
                this.OnPropertyChanged();
            }
        }
        
        private bool _isCircleVisible;
        public bool IsCircleVisible
        {
            get => _isCircleVisible;
            set
            {
                if (this._isCircleVisible == value) return;
                this._isCircleVisible = value;
                this.OnPropertyChanged();
            }
        }

        private bool _isCircleImageVisible;
        public bool IsCircleImageVisible
        {
            get => _isCircleImageVisible;
            set
            {
                if (this._isCircleImageVisible == value) return;
                this._isCircleImageVisible = value;
                this.OnPropertyChanged();
            }
        }
        
        private bool _isSquareImageVisible;
        public bool IsSquareImageVisible
        {
            get => _isSquareImageVisible;
            set
            {
                if (this._isSquareImageVisible == value) return;
                this._isSquareImageVisible = value;
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