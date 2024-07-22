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

        //when text in textbox changes, this text is assigned to animal Name
        private void petName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox petNameTextBox = sender as TextBox;
            if (petNameTextBox != null)
            {
                animal.Name = petNameTextBox.Text;
            }

        }
        //when user clicks continue button, it closes the current window and opens mMinWindow
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
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
    }
}
