using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XamlAndWpf.WindowsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IContact contact;

        public MainWindow() : this(new Contact { FirstName = "Gunjan", LastName = "Patel", Email = "gmpatel@live.com", Mobile = "0414 854 093"})
        {
        }



        public MainWindow(IContact contact)
        {
            InitializeComponent(); 
            
            this.contact = contact;
            this.DataContext = contact;

            ButtonSave.IsEnabled = false;
            ButtonSave.Content = "Save (Disabled)";

            contact.PropertyChanged += Contact_PropertyChanged;
        }

        private void Contact_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ButtonSave.IsEnabled = true;
            ButtonSave.Content = "Save";
            TextHeader.Text = "Contact (Modified)";
        }
        
        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Contact saved!");

            ButtonSave.IsEnabled = false;
            ButtonSave.Content = "Save (Disabled)";
            TextHeader.Text = "Contact";
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
