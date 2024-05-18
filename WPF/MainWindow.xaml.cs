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

           // Ferry selectedFerry = FerryBLL.getFerry(1);

         

            /*
             Lav et vindue hvor jeg kan oprette en bil
            Tilføj en eksisterende passager til en bil
            Følg samme tilgang hvor jeg tilføjer en bil til en færge
            */

            FerryBLL ferryBLL = new FerryBLL();
            MyListBox.ItemsSource = (ferryBLL.getAllFerries());

            /*selectedFerry = (Ferry)MyListBox.SelectedItem;
            CarBLL carBLL = new CarBLL();
            Ferry_Cars.ItemsSource = (carBLL.getAllCars(selectedFerry.Id)); */
        } 

        private void PassengerButton_Click(object sender, RoutedEventArgs e)
        {
            if(MyListBox.SelectedItem != null)
            {

                selectedFerry = (Ferry)MyListBox.SelectedItem;
                selectedFerry = FerryBLL.getFerry(selectedFerry.Id);


                CreateGuestWindow createGuestWindow = new CreateGuestWindow(selectedFerry);

                createGuestWindow.Show();
            }
           
            
        }

        private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            selectedFerry = (Ferry)MyListBox.SelectedItem;
            CarBLL carBLL = new CarBLL();
            Ferry_Cars.ItemsSource = (carBLL.getAllCars(selectedFerry.Id));

        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            selectedFerry = (Ferry)MyListBox.SelectedItem;
            selectedFerry = FerryBLL.getFerry(selectedFerry.Id);

            CreateCarWindow createCarWindow = new CreateCarWindow(selectedFerry);
            createCarWindow.Show();
        }
    }
}
