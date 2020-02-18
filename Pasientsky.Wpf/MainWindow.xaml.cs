using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using Pasientsky.Api.Client;

namespace Pasientsky.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _dummy;
        private Patient _selectedPatient;
        PatientClient pasientClient = new Pasientsky.Api.Client.PatientClient("http://localhost:5000", new HttpClient());
        LegekontorClient legekontorClient = new LegekontorClient("http://localhost:5000", new HttpClient());


        public MainWindow()
        {
            InitializeComponent();

            PatientList = new ObservableCollection<Patient>();
            DataContext = this;
        }

        public ObservableCollection<Patient> PatientList { get; set; }

        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set {
                _selectedPatient = value; 
                OnPropertyChanged();
            }
        }


        private async void OnClickLoad(object sender, RoutedEventArgs e)
        {

            var pasients = await pasientClient.GetAllPatientsAsync();

            foreach (var pasient in pasients)
            {
                PatientList.Add(pasient);
            }
        }






        

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
