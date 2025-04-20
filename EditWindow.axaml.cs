using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia;

namespace Messenger
{
    public partial class EditWindow : Window
    {
        public EditWindow(MainViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void OnCloseClick(object? sender, RoutedEventArgs e)
        {
            this.Close(); 
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
