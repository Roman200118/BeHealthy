using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Clinic.UI.ChiefWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] servicesNames = { "Узи", "Массаж", "Забор крови", "Функциональная диагностика", "Перевязка", "Снятие гипса" };

        public MainWindow()
        {
            var i = 1;

            InitializeComponent();

            CatalogDataGrid.ItemsSource = servicesNames
                .Select(x => new
                {
                    Id = i++,
                    Name = x,
                    Price = new Random().Next(0, 100),
                    ShortDescription = "Высокопрофессиональный" + " " + x.ToLower()
                })
                .ToList();

            EmployeesDataGrid.ItemsSource = new List<object>
            {
                new
                {
                    Employee = "Иванов Артем",
                    EmployeeRank = "Лаборант",
                    WorkedHours = "168",
                    WorkingDays = "21",
                    WorkedWeekDays = "ПН, ВТ, СР, ПТ, СБ"
                },
                new
                {
                    Employee = "Кузнецов Сергей",
                    EmployeeRank = "Лаборант",
                    WorkedHours = "160",
                    WorkingDays = "20",
                    WorkedWeekDays = "ПН, ВТ, СР, ПТ, СБ"
                },
                new
                {
                    Employee = "Антанович Кирилл",
                    EmployeeRank = "Хирург",
                    WorkedHours = "64",
                    WorkingDays = "8",
                    WorkedWeekDays = "ПН, ВТ"
                }
            };
        }
    }
}
