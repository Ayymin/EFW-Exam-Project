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
    /// Interaction logic for DeleteGuestWindow.xaml
    /// </summary>
    public partial class DeleteGuestWindow : Window
    {
        Ferry selectedFerry;
        Guest selectedGuest;
        FerryBLL ferryBLL = new FerryBLL();
        GuestBLL guestBLL = new GuestBLL();
        public DeleteGuestWindow(Ferry ferry)
        {
            InitializeComponent();
            selectedFerry = ferry;


            var allGuests = guestBLL.GetAllGuests(selectedFerry.Id);
            var filteredGuests = allGuests.Where(g => g.FerryId == selectedFerry.Id).ToList();

            GuestListBox.ItemsSource = filteredGuests;
        }

        private void DeleteGuest_Click(object sender, RoutedEventArgs e)
        {
            selectedGuest = (Guest)GuestListBox.SelectedItem;

            if (selectedGuest != null)
            {
                guestBLL.RemoveGuest(selectedGuest.GuestID);

                selectedFerry.AmountofPassengers--;
                FerryBLL.UpdateFerryPassengerAmount(selectedFerry);

                UpdateRevenue();
                

                UpdateGuestListBox();
            }
            else
            {
                MessageBox.Show("Please select a guest to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateGuestListBox()
        {
            List<Guest> guestList = guestBLL.GetAllGuests(selectedFerry.Id);

            GuestListBox.ItemsSource = guestList;
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
