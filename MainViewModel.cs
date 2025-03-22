using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

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

    public MainViewModel()
    {
        RemoveUserCommand = new RelayCommand(_ => RemoveSelectedUser(), _ => SelectedUser != null);
        EditUserCommand = new RelayCommand(_ => EditSelectedUser(), _ => SelectedUser != null);

        Users.Add(new User("David", "Prisoten", "Assets/avatar.jpeg", "novuporabnik@email.com", DateTime.Now, "Slovenija"));
        Users.Add(new User("Luka", "Odsoten", "Assets/profile2.jpg", "novuporabnik@email.com", DateTime.Now, "Slovenija"));
        Users.Add(new User("Ana", "Odsotna", "Assets/profile3.jpg", "novuporabnik@email.com", DateTime.Now, "Slovenija"));
    }

    private void RemoveSelectedUser()
    {
        if (SelectedUser != null)
        {
            Users.Remove(SelectedUser);
            SelectedUser = null; // Reset izbire
            OnPropertyChanged(nameof(SelectedUser)); // UI osveži izbranega uporabnika
        }
    }

    private void EditSelectedUser()
    {
        if (SelectedUser != null)
        {
            SelectedUser.Name = "Leon";
            SelectedUser.Status = "Offline";
            OnPropertyChanged(nameof(SelectedUser)); // UI osveži podatke o uporabniku
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
