using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            allfiles = Directory.GetFiles( "notes", "*.txt");
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
            try
            {
                string data = File.ReadAllText( "notes\\" + listBox1.SelectedItem.ToString() + ".txt");
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
