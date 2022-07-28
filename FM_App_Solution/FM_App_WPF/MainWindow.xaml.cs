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
using FM_App_DAL.Interfaces;
using FM_App_DAL.Repos;
using FM_models;

namespace FM_App_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICar _carRepo = new CarRepo();
        ICarClass _carClassRepo = new CarClassRepo();
        IClass _classRepo = new ClassRepo();
        ILaptime _laptimeRepo = new LaptimeRepo();
        ITrack _trackRepo = new TrackRepo();
        IWeather _weatherRepo = new WeatherRepo();  

        Car _car = new Car();
        CarClass _carClass = new CarClass();
        Class _class = new Class();
        Laptime _laptime = new Laptime();
        Track _track = new Track();
        Weather _weather = new Weather();

        public MainWindow()
        {
            InitializeComponent();
            GetData();
            SetData();
        }

        private void GetData()
        {
            cmbTracks.ItemsSource = _trackRepo.GetAllTracksWithWeatherSetting();
            cmbTracks.SelectedValuePath = "Name";
            cmbCars.ItemsSource = _carRepo.GetAllCars();
            cmbCars.SelectedValuePath = "manufacturer";
            lstClass.ItemsSource = _classRepo.GetClasses();
            lstClass.SelectedValuePath = "name";
        }

        private void SetData()
        {
            cmbTracks.SelectedValue = _track.id;
            cmbCars.SelectedValue = _car.id;
            lstClass.SelectedValue = _class.id;
        }

        private void btnSubmitCar_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(txtPI.Text, out int pi);
            Car car = new Car(txtManufacturer.Text, txtModel.Text, txtHandling.Text, pi);
            if (car != null)
            {
                if (_carRepo.AddCar(car))
                    if (lstClass.SelectedItem is Class selectedClass)
                    {
                        if (_carClassRepo.AddCarToClass((_carRepo.GetIdFromNewestCar()), selectedClass.id))
                            MessageBox.Show("Submitting car successful!", "FM App", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else MessageBox.Show("Please select a class!", "FM App", MessageBoxButton.OK, MessageBoxImage.Error);
                else MessageBox.Show("Couldn't submit car, please check input fields!", "FM App", MessageBoxButton.OK, MessageBoxImage.Error);
                GetData();
                ClearFields();
            }
        }

        private void btnDeleteCar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCars.SelectedItem != null)
            {
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (_carRepo.DeleteCar(((Car)cmbCars.SelectedItem).id))
                    {
                        MessageBox.Show("Car deleted!", "FM App", MessageBoxButton.OK, MessageBoxImage.Information);
                        GetData();
                    }
                    else MessageBox.Show("Couldn't delete car!", "FM App", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else MessageBox.Show("Make sure you select a car!", "FM App", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ClearFields()
        {
            txtHandling.Text = "";
            txtLaptime.Text = "";
            txtManufacturer.Text = "";
            txtModel.Text = "";
            txtPI.Text = "";
            txtSearchTerm.Text = "";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            lstClass.SelectedIndex = -1;
            cmbCars.SelectedIndex = -1;
            cmbTracks.SelectedIndex = -1;
        }

        private void btnSubmitLaptime_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTracks.SelectedItem is Track track && cmbCars.SelectedItem is Car car)
            {
                if (ValidateLaptime())
                {
                }
                else MessageBox.Show("Laptime invalid, please check!", "FM App", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateLaptime()
        {
            string laptime = txtLaptime.Text;
            if (!string.IsNullOrWhiteSpace(laptime) && laptime.Length == 9)
            {
                int locatie1 = laptime.IndexOf('.', 2, 1);
                int locatie2 = laptime.IndexOf('.', 5, 1);
                int teller = 0;
                char[] indexes = laptime.ToCharArray();
                for (int i = 0; i < indexes.Length; i++)
                {
                    int number = indexes[i] - 0;
                    if (number >= 0)
                        teller++;
                }
                if (teller == 7 && locatie1 == 2 && locatie2 == 5)
                    return true;
            }
            return false;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (lstClass.SelectedIndex > -1)
            {
                if (lstClass.SelectedItem is Class @class)
                {
                    cmbCars.ItemsSource = _carRepo.GetCarsByClass(@class.id);
                }
            }
        }
    }
}
