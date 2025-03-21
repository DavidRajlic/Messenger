using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Messenger;

public class MainViewModel
{
    public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
    public User? SelectedUser { get; set; } // Trenutno izbran stik

    // ICommand za odstranjevanje stika
    public ICommand RemoveUserCommand { get; }
    public ICommand EditUserCommand { get; }

    public MainViewModel()
    {
        // Inicializacija ukaza in povezava z metodo RemoveSelectedUser
        RemoveUserCommand = new RelayCommand(_ => RemoveSelectedUser(), _ => SelectedUser != null);
        EditUserCommand = new RelayCommand(_ => EditSelectedUser(), _ => SelectedUser != null);
        // Dodamo testne uporabnike
        Users.Add(new User("David", "Prisoten","Assets/avatar.jpeg", "novuporabnik@email.com", DateTime.Now, "Slovenija"));
        Users.Add(new User("Luka", "Odsoten", "Assets/profile2.jpg", "novuporabnik@email.com", DateTime.Now, "Slovenija"));
         Users.Add(new User("Ana", "Odsotna", "Assets/profile3.jpg", "novuporabnik@email.com", DateTime.Now, "Slovenija"));
    }

    private void RemoveSelectedUser()
    {
        if (SelectedUser != null)
        {
            Users.Remove(SelectedUser);
            SelectedUser = null; // Po odstranitvi resetiramo izbiro
        }
    }

     private void EditSelectedUser()
    {
        Console.WriteLine("Im in");
        
        if (SelectedUser != null)
        {
            Console.WriteLine("Kull");
            SelectedUser.Name = "Leon";
            SelectedUser.Status = "Offline";
        }
    }
}
