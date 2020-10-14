# Xam.Forms.GraceLoader
## What is it

Grace Loader is a simple view that enables you to rendering nice and easy loaders. It is 100% Xaml and C# Shared coded, so that you can install the package only in your shared Xamarin.Forms project.

Platform/Feature               | Package name                              | Last version      | Status 
-----------------------|-------------------------------------------|-----------------------------|------------------------
XAML             | `Xam.Forms.GraceLoader` | [![Nuget](https://img.shields.io/nuget/v/Xam.Forms.GraceLoader)](https://www.nuget.org/packages/Xam.Forms.GraceLoader/) | ![.NET Core](https://github.com/nightlybuilds-net/Xam.Forms.GraceLoader/workflows/.NET%20Core/badge.svg)


The package is compliant with [Semantic Versioning](https://semver.org/)

## Samples

Here are two video showing sample projects for on IPhone and Android Phone.

//todo add samples video

## How it works
You simply had to bind GraceLoader **IsVisible** to a bool property which you set before and after a time consuming blocking event, such as http call or some complex task operations. By setting **Type** property you can choose the loader style and even define a custom one. Below there's an example of a Square GraceLoader without image. To set an image just set **ImageUri** property, as shown in the [example projects](https://github.com/nightlybuilds-net/Xam.Forms.GraceLoader/tree/develop/Xam.Forms.GraceLoader/Xam.Forms.Example).

    <graceLoader:GraceLoaderView  
	    Grid.Row="0"  
	    Grid.RowSpan="2"  
	    LoadingText="Loading"  
	    IsVisible="{Binding IsSquareVisible}"  
	    LoadingTextColor="Black"  
	    ActivityIndicatorColor="DarkBlue"  
	    ContainerColor="Aquamarine"  
	    ContainerType="Square"/>

Thank you and have fun!
