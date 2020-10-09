using System;
using Xamarin.Forms;

namespace Xam.Forms.GraceLoader
{
    public partial class GraceLoaderView
    {
        public GraceLoaderView()
        {
            InitializeComponent();

            this.PropertyChanged += async (sender, args) =>
            {
                if (args.PropertyName == "IsVisible")
                {
                    var isVisible = ((GraceLoaderView) sender).IsVisible;
                    if (isVisible)
                        await this.Container.FadeTo(1,2000);
                }
            };
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
        
        private Color _activityIndicatorColor;
        public Color ActivityIndicatorColor
        {
            get => this._activityIndicatorColor;
            set
            {
                if (value == this._activityIndicatorColor) return;
                this._activityIndicatorColor = value;
                this.Indicator.Color = this.ActivityIndicatorColor;
            }
        } 
        
        private Color _containerColor;
        public Color ContainerColor
        {
            get => this._containerColor;
            set
            {
                if (value == this._containerColor) return;
                this._containerColor = value;
                this.Container.BackgroundColor = this.ContainerColor;
            }
        }
        
        private double _containerHeight;
        public double ContainerHeight
        {
            get => this._containerHeight;
            set
            {
                if (value == this._containerHeight) return;
                this._containerHeight = value;
                this.Container.HeightRequest = this.ContainerHeight;
            }
        }
        
        private double _containerWidth;
        public double ContainerWidth
        {
            get => this._containerWidth;
            set
            {
                if (value == this._containerWidth) return;
                this._containerWidth = value;
                this.Container.WidthRequest = this.ContainerWidth;
            }
        }        
        
        private string _imageUri;
        public string ImageUri
        {
            get => this._imageUri;
            set
            {
                if (value == this._imageUri) return;
                this._imageUri = value;
                this.Image.Source = this.ImageUri;
            }
        }
        
        private ContainerType _containerType;
        public ContainerType ContainerType
        {
            get => this._containerType;
            set
            {
                if (value == this._containerType) return;
                this._containerType = value;
                this.SetBorderRadiusBasedOnType(this.ContainerType);
            }
        }

        private void SetBorderRadiusBasedOnType(ContainerType type)
        {
            this.Container.CornerRadius = type switch
            {
                ContainerType.Square => (float) this.Container.WidthRequest / 10,
                ContainerType.Circle => (float) this.Container.WidthRequest / 2,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }

    public enum ContainerType
    {
        Square = 1,
        Circle = 2
    }
}