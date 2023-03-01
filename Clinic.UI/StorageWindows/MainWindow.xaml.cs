using System;
using System.Linq;
using System.Windows;
using static Clinic.UI.PharmacistWindows.MainWindow;

namespace Clinic.UI.StorageWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var i = 1;
            var meds = PharmacistWindows.MainWindow.MedNames.Select(x => new
                {
                    Id = i++,
                    Name = x,
                    Compound = (new Random().Next(50) + 1).ToString() + " мг активного вщ-ва",
                    Count = new Random().Next(100) + 1 + " уп.",
                    Country = i % 2 == 0 ? "Бельгия" : "Германия"
                })
                .ToList();

            CatalogDataGrid.ItemsSource = meds;

            i = 1;

            РаспределениеDataGrid.ItemsSource = meds
                .Select(c => new
                {
                    Med = c.Name,
                    Count =
                        int.Parse(c.Count.Split(" ").First()) - int.Parse(c.Count.Split(" ").First()) / 2 + " уп.",
                    Unit = "Кардиологическое отделение",
                    Id = i++
                })
                .ToList();

            i = 1;
            OrdersDataGrid.ItemsSource = MedNames
                .Select(x => new
                {
                    Id = i++,
                    Date = DateTime.Now.AddDays(-new Random().Next(10)).ToString("d"),
                    Status = i + new Random().Next(1) % 2 == 0
                        ? "В обработке"
                        : "Груз в пути",
                    Reason = MedNames[new Random().Next(MedNames.Length)] + " " + (new Random().Next(100) + 1).ToString() + " шт."
                })
                .ToList();
        }
    }
}
