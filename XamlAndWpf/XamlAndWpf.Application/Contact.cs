using System.ComponentModel;
using System.Windows.Input;

namespace XamlAndWpf.WindowsApp
{
    public class Contact : IContact
    {
        private string firstName;
        private string lastName;
        private string email;
        private string mobile;
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (!value.Equals(firstName))
                {
                    firstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (!value.Equals(lastName))
                {
                    lastName = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (!value.Equals(email))
                {
                    email = value;
                    NotifyPropertyChanged("Email");
                }
            }
        }

        public string Mobile
        {
            get { return mobile; }
            set
            {
                if (!value.Equals(mobile))
                {
                    mobile = value;
                    NotifyPropertyChanged("Mobile");
                }
            }
        }
    }
}