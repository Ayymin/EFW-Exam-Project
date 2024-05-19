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
    /// Interaction logic for EditFerryWindow.xaml
    /// </summary>
    public partial class EditFerryWindow : Window
    {
        private Ferry selectedFerry;
        private CarBLL carBLL;
        private FerryBLL ferryBLL;

        public EditFerryWindow(Ferry ferry)
        {
            InitializeComponent();

            selectedFerry = ferry;

            carBLL = new CarBLL();
            ferryBLL = new FerryBLL();

            var allCars = carBLL.GetAllCars(selectedFerry.Id);
            var filteredCars = allCars.Where(c => c.FerryID == selectedFerry.Id).ToList();


            CarsOnBoardFerry.ItemsSource = filteredCars;

            FerryNameTBox.Text = selectedFerry.FerryName;
            GuestPriceTBox.Text = selectedFerry.GuestPrice.ToString();
            CarPriceTbox.Text = selectedFerry.CarPrice.ToString();
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedFerry.FerryName = FerryNameTBox.Text;
                selectedFerry.GuestPrice = int.Parse(GuestPriceTBox.Text);
                selectedFerry.CarPrice = int.Parse(CarPriceTbox.Text);


                ferryBLL.UpdateFerryObject(selectedFerry);

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
