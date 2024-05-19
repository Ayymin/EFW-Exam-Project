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
        public Car selectedCar { get; set; }

        FerryBLL ferryBLL;
        CarBLL carBLL;

        public MainWindow()
        {
            InitializeComponent();
            ferryBLL = new FerryBLL();
            carBLL = new CarBLL();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyListBox.Items.Clear();
            MyListBox.ItemsSource = ferryBLL.GetAllFerries();
        }

        private void PassengerButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyListBox.SelectedItem != null)
            {
                selectedFerry = (Ferry)MyListBox.SelectedItem;
                selectedFerry = ferryBLL.GetFerry(selectedFerry.Id);
                CreateGuestWindow createGuestWindow = new CreateGuestWindow(selectedFerry);
                createGuestWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select a ferry first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedFerry = (Ferry)MyListBox.SelectedItem;
            if (selectedFerry != null)
            {
                Ferry_Cars.ItemsSource = carBLL.GetAllCars(selectedFerry.Id);
                FerryRevenueTBox.Text = ferryBLL.CalculateFerryPrice(selectedFerry).ToString();
            }
        }

        private void Ferry_Cars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCar = (Car)Ferry_Cars.SelectedItem;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MyListBox.SelectedItem != null)
            {
                selectedFerry = (Ferry)MyListBox.SelectedItem;
                selectedFerry = ferryBLL.GetFerry(selectedFerry.Id);
                CreateCarWindow createCarWindow = new CreateCarWindow(selectedFerry);
                createCarWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select a ferry first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeletePassngerWindow(object sender, RoutedEventArgs e)
        {
            if (MyListBox.SelectedItem != null)
            {
                selectedFerry = (Ferry)MyListBox.SelectedItem;
                selectedFerry = ferryBLL.GetFerry(selectedFerry.Id);
                DeleteGuestWindow deleteGuestWindow = new DeleteGuestWindow(selectedFerry);
                deleteGuestWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select a ferry first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteCarWindowOpener_Click(object sender, RoutedEventArgs e)
        {
            if (MyListBox.SelectedItem != null)
            {
                selectedFerry = (Ferry)MyListBox.SelectedItem;
                selectedFerry = ferryBLL.GetFerry(selectedFerry.Id);
                DeleteCarWindow deleteCarWindow = new DeleteCarWindow(selectedFerry);
                deleteCarWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select a ferry first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditFerryWindowOpen(object sender, RoutedEventArgs e)
        {
            if (MyListBox.SelectedItem != null)
            {
                selectedFerry = (Ferry)MyListBox.SelectedItem;
                selectedFerry = ferryBLL.GetFerry(selectedFerry.Id);
                EditFerryWindow editFerryWindow = new EditFerryWindow(selectedFerry);
                editFerryWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select a ferry first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditCarWindowOpen(object sender, RoutedEventArgs e)
        {
            if (Ferry_Cars.SelectedItem != null)
            {
                selectedCar = (Car)Ferry_Cars.SelectedItem;
                selectedCar = carBLL.Getcar(selectedCar.CarID);
                EditCarWindow editCarWindow = new EditCarWindow(selectedCar);
                editCarWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select a car first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }




}

