using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia.Interactivity;

namespace Messenger;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

    private User? _selectedUser;
    public User? SelectedUser
    {
        get => _selectedUser;
        set => SetProperty(ref _selectedUser, value);
    }

    public ICommand RemoveUserCommand { get; }
    public ICommand EditUserCommand { get; }
    public ICommand ToggleStatusCommand { get; }

    public MainViewModel()
    {
        RemoveUserCommand = new RelayCommand(_ => RemoveSelectedUser(), _ => SelectedUser != null);
        EditUserCommand = new RelayCommand(param =>
        {
            bool state = bool.TryParse(param?.ToString(), out var result) && result;
            EditSelectedUser(state);
        }, _ => SelectedUser != null);

        ToggleStatusCommand = new RelayCommand(param =>
        {
            bool state = bool.TryParse(param?.ToString(), out var result) && result;
            EditSelectedUser(state);
        }, _ => SelectedUser != null);

        Users.Add(new User("David", "Prisoten", "Assets/avatar.jpeg", "novuporabnik@email.com", DateTime.Now, "Slovenija"));
        Users.Add(new User("Luka", "Odsoten", "Assets/profile2.jpg", "novuporabnik@email.com", DateTime.Now, "Slovenija"));
        Users.Add(new User("Ana", "Odsotna", "Assets/profile3.jpg", "novuporabnik@email.com", DateTime.Now, "Slovenija"));

         if (Users.Count > 0)
    {
        SelectedUser = Users[0];
    }
    }

    private void RemoveSelectedUser()
    {
        if (SelectedUser != null)
        {
            Users.Remove(SelectedUser);
            SelectedUser = null; 
            OnPropertyChanged(nameof(SelectedUser)); 
        }
    }

public Action? OpenEditWindowAction { get; set; }

private void EditSelectedUser(bool state)
{
    if (SelectedUser != null)
    {
        
      //  SelectedUser.Name = "Leon";
        SelectedUser.Status = "Offline";
        
        if(state) {
            OpenEditWindowAction?.Invoke();
        }
        
    }
}




    private void ToggleStatus()
    {
        if (SelectedUser != null)
        {
            SelectedUser.Status = SelectedUser.Status == "Prisoten" ? "Odsoten" : "Prisoten";
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
