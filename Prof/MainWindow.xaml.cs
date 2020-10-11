using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing;

namespace Prof
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] allfiles;
        int countFiles = 0;
        DateTime dateNow;
        public MainWindow()
        {
            InitializeComponent();
            dateNow = DateTime.Now;
            label1.Content = dateNow;
            showAllNotes();
            changeBackground();
        }
        public void showAllNotes()
        {
            allfiles = Directory.GetFiles( "notes", "*.txt");
            foreach (string onlyName in allfiles)
            {
                allfiles[countFiles] = System.IO.Path.GetFileNameWithoutExtension(onlyName);
                listBox1.Items.Insert(countFiles, allfiles[countFiles]);
                countFiles++;  
            }
            countFiles = 0;
        }
      

        private void changeBackground()
        {
            Bitmap bitmap;
            if (dateNow.Month == 1 || dateNow.Month == 2 || dateNow.Month == 12 )
            {
                bitmap = Properties.Resources.winter;
                calendar.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xEE, 0xE0, 0xFF, 0xFF));

            }
            else if (dateNow.Month >= 3 && dateNow.Month <= 5 )
            {
                bitmap = Properties.Resources.spring;
                calendar.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xEE, 0xFF, 0xC0, 0xCB)); 
            }
            else if (dateNow.Month >= 6 && dateNow.Month <= 8 )
            {
                bitmap = Properties.Resources.summer;
                 calendar.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xEE, 98, 0xFB, 98));
            }
            else
            {
                bitmap = Properties.Resources.fall;
                calendar.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xEE, 0xFF, 0xD7, 00));
            }
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            imgBrush.ImageSource = image;
        }

        private void listBox1_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string data = File.ReadAllText("notes\\" + listBox1.SelectedItem.ToString() + ".txt");
                textbox1.Text = data;
            }catch
            {
                textbox1.Clear();
            }
            
        }

        private void button1_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
            
            this.Hide();
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NewNote newNote = new NewNote(this);
            newNote.Show();
        }
    }
}
