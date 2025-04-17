using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia;

namespace Messenger
{
    public partial class ContactsWindow : Window
    {
        public ContactsWindow(MainViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void OnCloseClick(object? sender, RoutedEventArgs e)
        {
            this.Close(); 
        }


        private async void AddContact(object? sender, RoutedEventArgs e)
        {

            if (DataContext is MainViewModel vm)
            {
                string username = MessageInputTextBox.Text;
                if (string.IsNullOrEmpty(username))
                {
                    // Pokaži opozorilo
                    await MessageBoxManager
                        .GetMessageBoxStandard("Napaka", "Vnesi uporabniško ime!")
                        .ShowAsync();
                }
                else {
                    // add user
                    vm.Users.Add(new User(username, "Offline", "slike/default.jpg", "novuporabnik@email.com", DateTime.Now, "Slovenija"));
                    this.Close(); 
                }
               
            }
        }


        
    }
}
