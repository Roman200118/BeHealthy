using System;
using System.Linq;
using System.Windows;

namespace Clinic.UI.ClientsWindow
{
    /// <summary>
    /// Interaction logic for InputClientWindow.xaml
    /// </summary>
    public partial class InputClientWindow : Window
    {
        public RegistryWindows.MainWindow.Client Result { get; set; }
        private int ClientId { get; set; }

        public InputClientWindow(RegistryWindows.MainWindow.Client client = null)
        {
            InitializeComponent();

            if (client is not null)
            {
                ClientId = client.Id;

                BirthDatePicker.SelectedDate = DateTime.Parse(client.BirthDate);
                PhoneTextBox.Text = client.Phone;
                AddressTextBox.Text = client.Address;
                NameTextBox.Text = client.ClientName.Split().Last();
                SurnameTextBox.Text = client.ClientName.Split().First();
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var birthDate = BirthDatePicker.SelectedDate;
            if (birthDate == null)
            {
                MessageBox.Show("Выберите дату");
                return;
            }

            var phone = PhoneTextBox.Text;
            if (phone.Length == 0)
            {
                MessageBox.Show("Введите телефон");
                return;
            }

            var name = NameTextBox.Text;
            if (name.Length == 0)
            {
                MessageBox.Show("Введите имя");
                return;
            }

            var surname = SurnameTextBox.Text;
            if (surname.Length == 0)
            {
                MessageBox.Show("Введите фамилию");
                return;
            }

            var address = AddressTextBox.Text;
            if (address.Length == 0)
            {
                MessageBox.Show("Выберите адрес");
                return;
            }

            var client = new RegistryWindows.MainWindow.Client
            {
                BirthDate = birthDate.Value.ToString("d"),
                Address = address,
                ClientName = surname + " " + name,
                Id = ClientId,
                Phone = phone
            };

            Result = client;
            DialogResult = true;
        }
    }
}