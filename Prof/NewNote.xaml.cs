using System;
using System.Collections.Generic;
using System.IO;
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

namespace Prof
{
    /// <summary>
    /// Логика взаимодействия для NewNote.xaml
    /// </summary>
    public partial class NewNote : Window
    {
        MainWindow mainWindow;
        public NewNote(MainWindow lastWindow)
        {
            mainWindow = lastWindow;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text.Length > 0 && TextBox2.Text.Length > 0)
            {
          
                if (File.Exists("notes\\" + textBox1.Text + ".txt")) 
                    File.Create("notes\\" + textBox1.Text + ".txt").Close();
                File.WriteAllText( "notes\\" + textBox1.Text + ".txt", TextBox2.Text);
                mainWindow.listBox1.Items.Clear();
                mainWindow.showAllNotes();
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы не указали одно или несколько из полей!\n Заполните все поля");
            }
        }
       
    }
}
