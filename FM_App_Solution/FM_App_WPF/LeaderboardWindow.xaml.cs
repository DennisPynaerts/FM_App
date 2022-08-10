using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FM_models;
using FM_App_DAL.Interfaces;
using FM_App_DAL.Repos;

namespace FM_App_WPF
{
    /// <summary>
    /// Interaction logic for LeaderboardWindow.xaml
    /// </summary>
    public partial class LeaderboardWindow : Window
    {
        private Track _track;
        private ILaptime _laptime = new LaptimeRepo();
        public LeaderboardWindow(Track track)
        {
            InitializeComponent();
            _track = track;
            lblTrack.Content = _track.ToString();
            datagridLeaderboard.ItemsSource = _laptime.GetAllLaptimesByTrackId(_track.id);
        }
    }
}
