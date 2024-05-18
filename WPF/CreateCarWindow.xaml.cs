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
            //Opretter ny bil
            // Bilen skal bruge gæste id 
            string numberPlate = NumberPlate.Text;

            Car car = new Car(numberPlate);
            car.FerryID = selectedFerry.Id;
            car.GuestId = selectedGuest.GuestID;
            carBLLL.AddCar(car);

        }

        private void GuestListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedGuest = (Guest)GuestListBox.SelectedItem;

        }
    }
}
