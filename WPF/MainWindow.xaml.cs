using BusinessLogic.BLL;
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
using DTO.Model;



namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Ferry selectedFerry { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            FerryBLL ferryBLL = new FerryBLL();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyListBox.Items.Clear();
            FerryBLL ferryBLL = new FerryBLL();
            MyListBox.ItemsSource = (ferryBLL.GetAllFerries());
        } 

        private void PassengerButton_Click(object sender, RoutedEventArgs e)
        {
            if(MyListBox.SelectedItem != null)
            {

                selectedFerry = (Ferry)MyListBox.SelectedItem;
                selectedFerry = FerryBLL.GetFerry(selectedFerry.Id);
                CreateGuestWindow createGuestWindow = new CreateGuestWindow(selectedFerry);

                createGuestWindow.Show();
            }
        }

        private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedFerry = (Ferry)MyListBox.SelectedItem;
            CarBLL carBLL = new CarBLL();
            Ferry_Cars.ItemsSource = (carBLL.GetAllCars(selectedFerry.Id));
            FerryBLL ferryBLL = new FerryBLL();
            
            FerryRevenueTBox.Text = ferryBLL.CalculateFerryPrice(selectedFerry).ToString();
        }     

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            selectedFerry = (Ferry)MyListBox.SelectedItem;
            selectedFerry = FerryBLL.GetFerry(selectedFerry.Id);

            CreateCarWindow createCarWindow = new CreateCarWindow(selectedFerry);
            createCarWindow.Show();
        }

        private void DeletePassngerWindow(object sender, RoutedEventArgs e)
        {
            selectedFerry = (Ferry)MyListBox.SelectedItem;
            selectedFerry = FerryBLL.GetFerry(selectedFerry.Id);

            DeleteGuestWindow deleteGuestWindow = new DeleteGuestWindow(selectedFerry);
            deleteGuestWindow.Show();

        }

        private void DeleteCarWindowOpener_Click(object sender, RoutedEventArgs e)
        {
            selectedFerry = (Ferry)MyListBox.SelectedItem;
            selectedFerry = FerryBLL.GetFerry(selectedFerry.Id);

            DeleteCarWindow deleteCarWindow = new DeleteCarWindow(selectedFerry);
            deleteCarWindow.Show();

        }

        private void FerryRevenueTBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
