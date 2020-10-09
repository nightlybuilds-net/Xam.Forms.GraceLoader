namespace Xam.Forms.Example
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }
    }
}