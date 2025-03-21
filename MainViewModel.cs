using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Messenger
{
    public class MainViewModel
    {
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();


         public User? SelectedUser { get; set; } 

        public MainViewModel()
        {

        

            // Testni uporabniki
            Users.Add(new User("David", "Prisoten", "slike/david.jpg", "david@email.com", DateTime.Now, "Slovenija"));
            Users.Add(new User("Luka", "Odsoten", "slike/luka.jpg", "luka@email.com", DateTime.Now.AddHours(-2), "Nemčija"));
            Users.Add(new User("Ana", "Zaseden", "slike/ana.jpg", "ana@email.com", DateTime.Now.AddHours(-5), "Francija"));
        }

           public void RemoveSelectedUser()
    {
        if (SelectedUser != null)
        {
            Users.Remove(SelectedUser);
            SelectedUser = null; // Po odstranitvi resetiramo izbiro
        }
    }

        private void AddUser()
        {
            Users.Add(new User("Denis", "Prisoten", "slike/default.jpg", "novuporabnik@email.com", DateTime.Now, "Slovenija"));
        }

        

        private void RemoveUser(User user)
        {
            Users.Remove(user);
        }

    }
    
}
