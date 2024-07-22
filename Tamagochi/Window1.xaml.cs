using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tamagochi
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Animal animal;

        public Window1()
        {
            InitializeComponent();
            animal = new Animal();

        }

        //allows to move screen with a mouse
        private void First_Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        
        //when user clicks continue button, it closes the current window and opens mMinWindow
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            string petNameText = petName.Text;
            animal.Name = petNameText;
            string petType = animal.AnimalType;

            MainWindow mainWindow = new MainWindow(petNameText, petType);
            mainWindow.Show();
            this.Close();
        }

        //Window closed
        private void btnClose3_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Window collapsed
        private void btnMinimize2_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void parrotButton_Click(object sender, RoutedEventArgs e)
        {
            parrotButton.BorderThickness = new Thickness(4);
            catButton.BorderThickness = new Thickness(1);
            DogButton.BorderThickness = new Thickness(1);
            hamsterButton.BorderThickness = new Thickness(1);
            animal.AnimalType = "parrot";

        }

        private void catButton_Click(object sender, RoutedEventArgs e)
        {
            parrotButton.BorderThickness = new Thickness(1);
            catButton.BorderThickness = new Thickness(4);
            DogButton.BorderThickness = new Thickness(1);
            hamsterButton.BorderThickness = new Thickness(1);
            animal.AnimalType = "cat";

        }

        private void DogButton_Click(object sender, RoutedEventArgs e)
        {
            parrotButton.BorderThickness = new Thickness(1);
            catButton.BorderThickness = new Thickness(1);
            DogButton.BorderThickness = new Thickness(4);
            hamsterButton.BorderThickness = new Thickness(1);
            animal.AnimalType = "dog";

        }

        private void hamsterButton_Click(object sender, RoutedEventArgs e)
        {
            parrotButton.BorderThickness = new Thickness(1);
            catButton.BorderThickness = new Thickness(1);
            DogButton.BorderThickness = new Thickness(1);
            hamsterButton.BorderThickness = new Thickness(4);
            animal.AnimalType = "hamster";

        }
    }
}
