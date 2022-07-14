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
            _carRepo.AddCar(car);
            GetData();
        }
    }
}
