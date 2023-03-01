using System;
using System.Collections.Generic;
using System.Windows;

namespace Clinic.UI.RegistryWindows
{
    /// <summary>
    /// Interaction logic for CardRecordsWindow.xaml
    /// </summary>
    public partial class CardRecordsWindow : Window
    {
        private List<string> Records { get; set; }

        public CardRecordsWindow(List<string> records)
        {
            Records = records;
            InitializeComponent();
            CardRecordsListBox.ItemsSource = Records;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var text = TextTextBox.Text;
            if (text.Trim().Length < 5)
            {
                MessageBox.Show("Введено меньше 5ти символов");
            }

            Records.Add(DateTime.Now.ToString("d") + ":" + " " + text);
            CardRecordsListBox.ItemsSource = null;
            CardRecordsListBox.ItemsSource = Records;

            MessageBox.Show("Успешно добавлено");
        }
    }
}