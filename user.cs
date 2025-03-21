using System;

namespace Messenger;
public class User
{
    public string Name { get; set; }
    public string Status { get; set; }
    public string ProfilePicture { get; set; }
    public string Email { get; set; }
    public DateTime LastOnline { get; set; }
    public string Location { get; set; }

    public User(string name, string status, string profilePicture, string email, DateTime lastOnline, string location)
    {
        Name = name;
        Status = status;
        ProfilePicture = profilePicture;
        Email = email;
        LastOnline = lastOnline;
        Location = location;
    }
}
