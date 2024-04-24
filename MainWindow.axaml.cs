using System.IO;
using System.Net;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaAppBegining;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Clear_OnClick(object? sender, RoutedEventArgs e)
    {
        Clear();
        StatusBar.Text = "Cleared";
    }   

    private void Clear()
    {
        InputFirstName.Clear();
        InputLastName.Clear();
    }

    private void Save_OnClick(object? sender, RoutedEventArgs e)
    {
        string? first = InputFirstName.Text ?? "";
        string? last = InputLastName.Text ?? ""; 
        if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(last))
        {
            StatusBar.Text = "One of the fields is empty";
            return;
        } 

        using var file = new StreamWriter(path: "output.dat", append: true);
        file.WriteLine($"{last} {first}");
        StatusBar.Text = "Saved";
        Clear();
    }   
    
}