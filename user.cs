using System;
using System.ComponentModel;

namespace Messenger;

public class User : INotifyPropertyChanged
{
    private string _name;
    private string _status;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public string Status
    {
        get => _status;
        set
        {
            _status = value;
            OnPropertyChanged(nameof(Status));
        }
    }
     public string ProfilePicture { get; set; }
    public string Email { get; set; }
    public DateTime LastOnline { get; set; }
    public string Location { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

     public User(string name, string status, string profilePicture, string email, DateTime lastOnline, string location)
    {
        _name = name;
        _status = status;
        ProfilePicture = profilePicture;
        Email = email;
        LastOnline = lastOnline;
        Location = location;
    }
}
