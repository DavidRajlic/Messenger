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
        
    }
}
