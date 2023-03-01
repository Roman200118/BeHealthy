using System.Collections.Generic;
using System.Windows;

namespace Clinic.UI.RegistryWindows
{
    /// <summary>
    /// Interaction logic for CreateCardWindow.xaml
    /// </summary>
    public partial class CreateCardWindow : Window
    {
        public (MainWindow.Doctor doc, MainWindow.Client client) Result;

        public CreateCardWindow(List<MainWindow.Doctor> doctors, List<MainWindow.Client> clients)
        {
            InitializeComponent();

            clientComboBox.ItemsSource = clients;
            doctorComboBox.ItemsSource = doctors;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (clientComboBox.SelectedItem is not MainWindow.Client client)
            {
                MessageBox.Show("Клиент должен быть выбран");
                return;
            }

            if (doctorComboBox.SelectedItem is not MainWindow.Doctor doctor)
            {
                MessageBox.Show("Ответственный врач должен быть выбран");
                return;
            }

            Result = (doctor, client);
            DialogResult = true;
        }
    }
}