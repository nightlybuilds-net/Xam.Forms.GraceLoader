using Xamarin.Forms;

namespace Xam.Forms.GraceLoader
{
    public partial class GraceLoaderView
    {
        public GraceLoaderView()
        {
            InitializeComponent();
        }
        
        public static readonly BindableProperty LoadingTextProperty =
            BindableProperty.Create ("LoadingText",
                typeof(string),
                typeof(GraceLoaderView),
                string.Empty,
                propertyChanged: (bindable, value, newValue) =>
                {
                    var loaderView = (GraceLoaderView) bindable;
                    loaderView.LoadingText = newValue.ToString();
                });

        private string _loadingText;
        public string LoadingText
        {
            get => this._loadingText;
            set
            {
                if (value == this._loadingText) return;
                this._loadingText = value;
                this.LoadingLabel.Text = this._loadingText;
            }
        }
        
        private Color _loadingTextColor;
        public Color LoadingTextColor
        {
            get => this._loadingTextColor;
            set
            {
                if (value == this._loadingTextColor) return;
                this._loadingTextColor = value;
                this.LoadingLabel.TextColor = this.LoadingTextColor;
            }
        }
    }
}