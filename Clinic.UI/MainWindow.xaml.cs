using System.Windows;

namespace Clinic.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string RegistryLogin = "Registry";
        private const string PharmacistLogin = "Pharmacist";
        private const string StorageLogin = "Storage";
        private const string LabLogin = "Lab";
        private const string ChiefLogin = "Chief";
        private const string DoctorLogin = "Doctor";


        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var loginTbText = LoginTb.Text;

            Hide();
            if (loginTbText == RegistryLogin)
            {
                new RegistryWindows.MainWindow().ShowDialog();
            }

            if (loginTbText == PharmacistLogin)
            {
                new PharmacistWindows.MainWindow().ShowDialog();
            }

            if (loginTbText == StorageLogin)
            {
                new StorageWindows.MainWindow().ShowDialog();
            }

            if (loginTbText == LabLogin)
            {
                new LabWindows.MainWindow().ShowDialog();
            }

            if (loginTbText == ChiefLogin)
            {
                new ChiefWindows.MainWindow().ShowDialog();
            }

            if (loginTbText == DoctorLogin)
            {
                new DoctorWindows.MainWindow().ShowDialog();
            }

            Show();
        }
    }
}