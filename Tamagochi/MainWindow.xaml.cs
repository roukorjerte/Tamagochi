using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Diagnostics;


namespace Tamagochi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        private Animal animal;
        private DispatcherTimer timer;
        private int counter;

        public MainWindow()

        {
            InitializeComponent();
            // Комментрий Андрея
            // получаем имя зверька и можно прикрутить его в свойство TextBlock.Text  сразу после InitializeComponent();
            animal = new Animal();
            animal.Hunger = 100;
            animal.Cleanness = 100;
            animal.Happiness = 100;
            animal.Sleep = 10;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            hungerBar.Value = animal.Hunger;
            happinessBar.Value = animal.Happiness;
            sleepBar.Value = animal.Sleep;
        }

        //Stats decrease and change of image if reached 0
        private async void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            if (animal.Hunger > 0)
            {
                animal.Hunger = animal.Hunger - 1;
                hungerBar.Value = animal.Hunger;
            }
            if (animal.Hunger == 0)
            {
                await LoadImageAsyncOnStateChange(@"/Media/parrot_dead.jpg");
            }
            if (animal.Cleanness > 0)
            {
                animal.Cleanness = animal.Cleanness - 2;
            }
            if (animal.Cleanness == 0)
            {
                await LoadImageAsyncOnStateChange(@"/Media/parrot_dirty.jpg");

            }
            if (counter % 2 == 0 && animal.Happiness > 0)
            {
                animal.Happiness = animal.Happiness - 5;
                happinessBar.Value = animal.Happiness;
            }
            if (animal.Happiness ==0)
            {
                await LoadImageAsyncOnStateChange(@"/Media/parrot_bored.jpg");
            }
            if (counter % 5 == 0 && animal.Sleep > 0)
            {
                animal.Sleep = animal.Sleep - 3;
                sleepBar.Value = animal.Sleep;
            }
             Debug.WriteLine(animal.Sleep.ToString());
            if (animal.Sleep <= 0)
            {
                await LoadImageAsyncOnStateChange(@"/Media/parrot_sleepy.jpg");
                
            }
        }

    
        //method changing image uri and changing image for 1,5 seconds(used in button actions)
        private async Task LoadAImageAsyncOnAction(string imagePath)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.Relative);
            bitmap.EndInit();
            Image.Source = bitmap;

            GifImage.Visibility = Visibility.Hidden;
            Image.Visibility = Visibility.Visible;

            await Task.Delay(1500);

            Image.Visibility = Visibility.Hidden;
            GifImage.Visibility = Visibility.Visible;
        }

        //method changing image uri(Used in state changes)
        private async Task LoadImageAsyncOnStateChange(string imagePath)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.Relative);
            bitmap.EndInit();
            Image.Source = bitmap;
            GifImage.Visibility = Visibility.Hidden;
            Image.Visibility = Visibility.Visible;
        }


        //Window can be moved via mouse
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        //Window collapsed
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //Window closed
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        //Feed button
        private async void btnFeed_Click(object sender, RoutedEventArgs e)
        {
            animal.Hunger = Math.Min(animal.Hunger + 20,100);
            hungerBar.Value = animal.Hunger;

            await LoadAImageAsyncOnAction(@"/Media/parrot_eating.jpg");
        }

        //Play button
        private async void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            animal.Happiness = Math.Min(animal.Happiness + 20, 100);
            happinessBar.Value = animal.Happiness;

            await LoadAImageAsyncOnAction(@"/Media/parrot_playing.jpg");

        }

        //Sleep button
        private async void btnSleep_Click(object sender, RoutedEventArgs e)
        {
            animal.Sleep = Math.Min(animal.Sleep + 20, 200);
            sleepBar.Value = animal.Sleep;

            await LoadAImageAsyncOnAction(@"/Media/parrot_sleeping.jpg");

        }

        //Clean button
        private async void btnClean_Click(object sender, RoutedEventArgs e)
        {
            animal.Cleanness = Math.Min(animal.Cleanness + 20, 100);

            await LoadAImageAsyncOnAction(@"/Media/parrot_clean.jpg");

        }

    }
}
