using System.ComponentModel;

namespace XamlAndWpf.WindowsApp
{
    public interface IContact : INotifyPropertyChanged
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Mobile { get; set; }
    }
}