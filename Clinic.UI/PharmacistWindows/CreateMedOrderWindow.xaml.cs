using System.Windows;

namespace Clinic.UI.PharmacistWindows
{
    /// <summary>
    /// Interaction logic for CreateMedOrderWindow.xaml
    /// </summary>
    public partial class CreateMedOrderWindow : Window
    {
        public CreateMedOrderWindow()
        {
            InitializeComponent();

            MedCb.ItemsSource = MainWindow.MedNames;
        }
    }
}
