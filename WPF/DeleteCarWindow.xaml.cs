using BusinessLogic.BLL;
using DTO.Model;
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
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for DeleteCarWindow.xaml
    /// </summary>
    public partial class DeleteCarWindow : Window
    {
        Ferry selectedFerry;
        Car selectedCar;

        FerryBLL ferryBLL = new FerryBLL();
        CarBLL carBLL = new CarBLL();
        public DeleteCarWindow(Ferry ferry)
        {
            InitializeComponent();

            selectedFerry = ferry;

            var allCars = carBLL.GetAllCars(selectedFerry.Id);
            var filteredCars = allCars.Where(c => c.FerryID == selectedFerry.Id).ToList();

            CarListBox.ItemsSource = filteredCars;
        }

        private void DeleteCarSelectedButton(object sender, RoutedEventArgs e)
        {
            selectedCar = (Car)CarListBox.SelectedItem;

            if (selectedCar != null)
            {
                carBLL.RemoveCar(selectedCar.CarID);

                selectedFerry.AmountofCars--;
                selectedFerry.AmountofPassengers -= selectedCar.AmountOfPassengers - 1;
                FerryBLL.UpdateFerryCarAmount(selectedFerry);


                UpdateRevenue();


                UpdateCarListBox();
            }
            else
            {
                MessageBox.Show("Please select a car to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateCarListBox()
       {
            List<Car> carList = carBLL.GetAllCars(selectedFerry.Id);

            CarListBox.ItemsSource = carList;
            
        }

        private void UpdateRevenue()
        {
            double updatedRevenue = ferryBLL.CalculateFerryPrice(selectedFerry);

            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
            {
                mainWindow.FerryRevenueTBox.Text = updatedRevenue.ToString();
            }
        }
    }
}
