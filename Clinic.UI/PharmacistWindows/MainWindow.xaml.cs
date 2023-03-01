using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Clinic.UI.PharmacistWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string[] MedNames = { "АнвиМакс®", "Супрастин®", "Mucosa compositum®", "АЗИТРОМИЦИН ФОРТЕ-АЛИУМ" };

        public class Med
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Country { get; set; }

            public int Count { get; set; }

            public int Price { get; set; }

            public string Compound { get; set; }
        }

        public List<Med> Meds { get; set; }

        public MainWindow()
        {
            int i = 1;
            Meds = MedNames.Select(x => new Med
                {
                    Id = i++,
                    Name = x,
                    Compound = (new Random().Next(50) + 1).ToString() + " мг активного вщ-ва",
                    Price = new Random().Next(100) + 1,
                    Count = new Random().Next(100) + 1,
                    Country = i % 2 == 0 ? "Бельгия" : "Германия"
                })
                .ToList();

            InitializeComponent();

            CatalogDataGrid.ItemsSource = Meds;
            i = 1;
            RecipieDataGrid.ItemsSource = Meds
                .Select(x => new
                {
                    Id = i++,
                    Name = x.Name,
                    Count = x.Count / 2,
                    Price = x.Count / 2 * x.Price
                })
                .ToList();
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            new CreateMedOrderWindow().ShowDialog();
        }
    }
}
