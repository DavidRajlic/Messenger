using System;
using System.ComponentModel;
using Avalonia.Controls;
using Avalonia.Media.Imaging;

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
    public Bitmap ProfilePicture { get; set; }
    public string Email { get; set; }
    public DateTime LastOnline { get; set; }
    public string Location { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

     public User(string name, string status, string imagePath, string email, DateTime lastOnline, string location)
    {
        _name = name;
        _status = status;
        ProfilePicture = LoadBitmap(imagePath);
        Email = email;
        LastOnline = lastOnline;
        Location = location;
    }

    private Bitmap LoadBitmap(string path)
    {
        try
        {
            return new Bitmap(path);
        }
        catch (Exception)
        {
            return null; // Če slika ne obstaja, vrne null
        }
    }
}
