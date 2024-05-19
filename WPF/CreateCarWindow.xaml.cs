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
using DTO.Model;
using BusinessLogic.BLL;

namespace WPF
{
    /// <summary>
    /// Interaction logic for CreateCarWindow.xaml
    /// </summary>
    public partial class CreateCarWindow : Window
    {
        Ferry selectedFerry;
        Guest selectedGuest;
        FerryBLL ferryBLL = new FerryBLL();
        GuestBLL guestBLL = new GuestBLL();
        CarBLL carBLLL = new CarBLL();

        public CreateCarWindow(Ferry ferry)
        {
            InitializeComponent();
            selectedFerry = ferry;

            var allGuests = guestBLL.GetAllGuests(selectedFerry.Id);
            var filteredGuests = allGuests.Where(g => g.FerryId == selectedFerry.Id).ToList();

            GuestListBox.ItemsSource = filteredGuests;


        }
        private void AddToCar(object sender, RoutedEventArgs e)
        {
            selectedGuest = (Guest)GuestListBox.SelectedItem;

            if (selectedGuest == null)
            {
                MessageBox.Show("Please select a guest before adding to car.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(NumberPlate.Text))
            {
                MessageBox.Show("Please enter a number plate before adding to car.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string numberPlate = NumberPlate.Text;
            ComboBoxItem selectedItem = PassengerAmountBox.SelectedItem as ComboBoxItem;

            if (int.TryParse(selectedItem?.Content.ToString(), out int passengerAmount))
            {
                Car car = new Car(numberPlate, passengerAmount)
                {
                    FerryID = selectedFerry.Id,
                    GuestId = selectedGuest.GuestID
                };

                selectedFerry.AmountofCars++;
                

                if (passengerAmount <= 1)
                {
                    carBLLL.AddCar(car);

                } else
                {
                    carBLLL.AddCar(car);
                    selectedFerry.AmountofPassengers += passengerAmount-1;
                }

                ferryBLL.UpdateFerryPassengerAmount(selectedFerry);

                MessageBox.Show("Car successfully added.");
                this.Close(); // Close the window after adding the car
            }
            else
            {
                MessageBox.Show("Invalid passenger amount selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void PassengerAmountBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
