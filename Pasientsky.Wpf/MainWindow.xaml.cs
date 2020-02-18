using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Pasientsky.WebApi.Controllers;

namespace Pasientsky.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _dummy;
        private Patient _selectedPatient;

        public MainWindow()
        {
            InitializeComponent();

            PatientList = new ObservableCollection<Patient>()
            {
                new Patient(){Id = 1, FirstName = "Ola", LastName = "Normann"},
                new Patient(){Id = 2, FirstName = "Kari", LastName = "Knutsdottir"},
            };
            DataContext = this;
        }

        public ObservableCollection<Patient> PatientList { get; set; }

        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set { _selectedPatient = value; OnPropertyChanged();}
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
