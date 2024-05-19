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
        FerryBLL ferryBLL;
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

            string guestName = GuestNameTBox.Text;
            string guestGender = GuestGenderTBox.Text;
            bool isDriver = TravelingWithCarRadioButton.IsChecked ?? false;


            Guest guest = new Guest(guestName, guestAge, guestGender, isDriver)
            {
                FerryId = selectedFerry.Id
            };

            GuestBLL guestBLL = new GuestBLL();
            guestBLL.AddGuest(guest);

            selectedFerry.AmountofPassengers++;
            ferryBLL.UpdateFerryPassengerAmount(selectedFerry);
            UpdateRevenue();


            MessageBox.Show("Guest successfully registered.");
        }

        private void UpdateRevenue()
        {
            double updatedRevenue = new FerryBLL().CalculateFerryPrice(selectedFerry);

            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
            {
                mainWindow.FerryRevenueTBox.Text = updatedRevenue.ToString();
            }
        }




    }


}