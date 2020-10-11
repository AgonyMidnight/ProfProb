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
using System.IO;


namespace Prof
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] allfiles;
        int countFiles = 0;
        public MainWindow()
        {
            InitializeComponent();
            label1.Content = DateTime.Now;
            showAllNotes();
        }
        public void showAllNotes()
        {
            allfiles = Directory.GetFiles(Environment.CurrentDirectory + "\\notes", "*.txt");
            foreach (string onlyName in allfiles)
            {
                allfiles[countFiles] = System.IO.Path.GetFileNameWithoutExtension(onlyName);
                listBox1.Items.Insert(countFiles, allfiles[countFiles]);
                countFiles++;  
            }
            countFiles = 0;
        }

        private void listBox1_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string data = File.ReadAllText(Environment.CurrentDirectory + 
                "\\notes\\" + listBox1.SelectedItem.ToString() + ".txt");
            textbox1.Text = data;
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
