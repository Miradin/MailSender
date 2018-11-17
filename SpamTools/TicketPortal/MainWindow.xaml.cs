using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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


namespace TicketPortal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CinemaDBContainer Context;
        public List<Movie> MovieList;
        public Movie _CurrentMovie;

        public MainWindow()
        {
            InitializeComponent();
            Context = new CinemaDBContainer();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ReloadMovieList();
        }

        private void SellTicket(Movie currentMovie, int tickets)
        { 
            Context.Movies.AddOrUpdate(
                new Movie
                {
                    Cashbox = currentMovie.Cashbox + currentMovie.Price * tickets,
                    Id = currentMovie.Id,
                    Session = currentMovie.Session,
                    MaxSeats = currentMovie.MaxSeats - tickets,
                    Price = currentMovie.Price
                }
                );
            Context.SaveChanges();
            ReloadMovieList();
        }


        private void ReloadMovieList()
        {
            MovieList = Context.Movies.ToList();
            //push data to xaml element
            DataGrid.ItemsSource = MovieList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _CurrentMovie = (Movie) DataGrid.SelectedValue;
                int tickets = int.Parse(Tickets.Text);
                if (_CurrentMovie.MaxSeats < tickets)
                {
                    MessageBox.Show($"You can't sell {tickets} tickets", "Error!");
                }
                else
                {
                    SellTicket(_CurrentMovie, tickets);
                }
            }
            catch (Exception ex)
            {
                //just ignore
            }
        }
    }
}
