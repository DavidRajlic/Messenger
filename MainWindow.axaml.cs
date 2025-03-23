using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia;
namespace Messenger;

public partial class MainWindow : Window
{


    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }

     private void Exit_Click(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void AddContact(object? sender, RoutedEventArgs e)
    {
     
        if (DataContext is MainViewModel vm)
        {
            // add user
            vm.Users.Add(new User("Denis", "Offline", "slike/default.jpg", "novuporabnik@email.com", DateTime.Now, "Slovenija"));
        }
    }

    private async void OnItemDoubleTapped(object sender, RoutedEventArgs e)
    {
     
    if (sender is TextBlock textBlock)
    {
        // SelectedContactTextBox.Text = textBlock.Text; 
        await MessageBoxManager
            .GetMessageBoxStandard("Izbran stik", $"Izbral si: {textBlock.Text}")
            .ShowAsync();
    }
    }

    private void SendMessageButton_Click(object sender, RoutedEventArgs e)
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        string message = MessageInputTextBox.Text.Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        if (!string.IsNullOrEmpty(message))
    {
        ChatListBox.Items.Add(new ListBoxItem { Content = "Ti: " + message });
        MessageInputTextBox.Clear(); // Po pošiljanju izbriše vnosno polje
    }
}

private void Emoji_Click(object? sender, RoutedEventArgs e)
{
    if (sender is MenuItem menuItem)
    {
        string emoji = menuItem.Header.ToString();
        MessageInputTextBox.Text += emoji; // Dodaj emoji v vnosno polje
    }
}





  

}   