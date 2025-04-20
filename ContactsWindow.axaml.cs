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
            string username = UsernameInputTextBox.Text;
            string mail = MailInputTextBox.Text;
            string country = CountryInputTextBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(country))
            {
                await MessageBoxManager
                    .GetMessageBoxStandard("Napaka", "Nisi vnesel vseh podatkov!")
                    .ShowAsync();
            }
            else if (!mail.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                await MessageBoxManager
                    .GetMessageBoxStandard("Napaka", "E-poštni naslov mora biti v obliki @gmail.com!")
                    .ShowAsync();
            }
            else
            {
                // Dodaj uporabnika
                vm.Users.Add(new User(username, "Offline", "Assets/q.jpg", mail, DateTime.Now, country));
                this.Close();
            }
        }

        }

        private async void Image_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                AllowMultiple = false,
                Filters = new List<FileDialogFilter>
                {
                    new FileDialogFilter { Name = "Slike", Extensions = { "jpg", "jpeg", "png" } }
                }
            };

            var result = await dialog.ShowAsync(this);

            if (result != null && result.Length > 0)
            {
                string selectedImagePath = result[0];

                if (DataContext is MainViewModel vm && vm.SelectedUser != null)
                {
                    vm.SelectedUser.ProfilePicturePath = selectedImagePath;
                }
            }
        }




        
    }
}
