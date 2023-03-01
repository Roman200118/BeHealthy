using System;
using System.Linq;
using System.Windows;

namespace Clinic.UI.LabWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CatalogDataGrid.ItemsSource = Enumerable
                .Range(1, 10)
                .Select(x => new
                {
                    Id = x,
                    Client = (x + new Random().Next(0, 100)) % 2 == 0
                        ? "Иванов Иван"
                        : "Сергеев Сергей",
                    Status = "Активный",
                    StartDate = DateTime.Now.AddDays(-new Random().Next(0, x)).ToString("d"),
                    EndDate = ""
                })
                .ToList();
        }
    }
}
