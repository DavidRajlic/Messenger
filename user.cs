using System;
using System.ComponentModel;
using System.IO;
using Avalonia.Media.Imaging;

namespace Messenger;

public class User : INotifyPropertyChanged
{
    private string _name;
    private string _status;
    private string _profilePicturePath;
    private Bitmap? _profilePicture;

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

    public string ProfilePicturePath
    {
        get => _profilePicturePath;
        set
        {
            _profilePicturePath = value;
            OnPropertyChanged(nameof(ProfilePicturePath));
            LoadBitmapFromPath(value); // on every path change
        }
    }

    public Bitmap? ProfilePicture
    {
        get => _profilePicture;
        private set
        {
            _profilePicture = value;
            OnPropertyChanged(nameof(ProfilePicture));
        }
    }

    public string Email { get; set; }
    public DateTime LastOnline { get; set; }
    public string Location { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public User(string name, string status, string imagePath, string email, DateTime lastOnline, string location)
    {
        _name = name;
        _status = status;
        Email = email;
        LastOnline = lastOnline;
        Location = location;
        ProfilePicturePath = imagePath; 
    }

    private void LoadBitmapFromPath(string path)
    {
        try
        {
            if (File.Exists(path))
                ProfilePicture = new Bitmap(path);
            else
                ProfilePicture = null;
        }
        catch
        {
            ProfilePicture = null;
        }
    }
}
