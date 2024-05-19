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
    /// Interaction logic for EditCarWindow.xaml
    /// </summary>
    /// 
    public partial class EditCarWindow : Window
    {
        private Car selectedCar;
        private CarBLL carBLL;
        private FerryBLL ferryBLL;

        public EditCarWindow(Car car)
        {
            InitializeComponent();

            selectedCar = car;
            NumberPlateTBox.Text = selectedCar.NumberPlate;
            PassengerAmountTBox.Text = selectedCar.AmountOfPassengers.ToString();

            // Initialize ferryBLL
            ferryBLL = new FerryBLL();
            carBLL = new CarBLL();

        }


        private void EditCarButton(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the original passenger count of the selected car
                int originalPassengerCount = selectedCar.AmountOfPassengers;

                // Update the car's number plate and passenger count
                selectedCar.NumberPlate = NumberPlateTBox.Text;
                selectedCar.AmountOfPassengers = int.Parse(PassengerAmountTBox.Text);

                // Calculate the difference in passenger count
                int passengerCountDifference = selectedCar.AmountOfPassengers - originalPassengerCount;

                // Update the car in the database
                carBLL.EditCar(selectedCar);

                // Retrieve the associated ferry using the car's FerryId
                Ferry associatedFerry = ferryBLL.GetFerry(selectedCar.FerryID);

                // Update the passenger count on the associated ferry
                associatedFerry.AmountofPassengers += passengerCountDifference;
                ferryBLL.UpdateFerryPassengerAmount(associatedFerry);

                // Update the revenue calculation for the ferry
      

                MessageBox.Show("Changes saved successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving changes: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }






    }

}
