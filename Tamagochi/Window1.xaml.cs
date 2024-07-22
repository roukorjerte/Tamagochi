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

        private void First_Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void petName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox petNameTextBox = sender as TextBox;
            if (petNameTextBox != null)
            {
                animal.Name = petNameTextBox.Text;
            }

        }
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
