using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using static Clinic.UI.RegistryWindows.MainWindow;

namespace Clinic.UI.DoctorWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Card> Cards { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Cards = Enumerable.Range(1, 15)
                .Select(c => GenerateCard(c))
                .ToList();

            var i = 1;
            CatalogDataGrid.ItemsSource = Cards
                .Select(x => new
                {
                    Id = i,
                    Client = x.Client,
                    Reason = new Random().Next(100) % 2 == 0
                        ? "Первичный осмотр"
                        : "Повторное исследование",
                    Time = (8 + i++).ToString() + ":00"
                })
                .ToList();
            CardsDataGrid.ItemsSource = Cards;
        }
    }
}
