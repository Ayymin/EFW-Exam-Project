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
using System.ComponentModel;


namespace WPF
{
    /// <summary>
    /// Interaction logic for CreateGuestWindow.xaml
    /// </summary>
    public partial class CreateGuestWindow : Window
    {
        Ferry selectedFerry;
        public CreateGuestWindow(Ferry ferry)
        {
            InitializeComponent();
            selectedFerry = ferry;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Check if all required fields are filled
            if (string.IsNullOrEmpty(GuestNameTBox.Text) ||
                string.IsNullOrEmpty(GuestAgeTBox.Text) ||
                string.IsNullOrEmpty(GuestGenderTBox.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Validate age input
            int guestAge;
            if (!int.TryParse(GuestAgeTBox.Text, out guestAge))
            {
                MessageBox.Show("Please enter a valid age.");
                return;
            }

            // Retrieve input values
            string guestName = GuestNameTBox.Text;
            string guestGender = GuestGenderTBox.Text;
            bool isDriver = TravelingWithCarRadioButton.IsChecked ?? false;


            // Create a new guest object
            Guest guest = new Guest(guestName, guestAge, guestGender, isDriver)
            {
                FerryId = selectedFerry.Id
            };

            // Add the guest using business logic layer
            GuestBLL guestBLL = new GuestBLL();
            guestBLL.AddGuest(guest);

            // Update the AmountofPassengers in the database
            selectedFerry.AmountofPassengers++;
            FerryBLL.UpdateFerryPassengerAmount(selectedFerry);

            // Show success message

            MessageBox.Show("Guest successfully registered.");
        }


    }
}