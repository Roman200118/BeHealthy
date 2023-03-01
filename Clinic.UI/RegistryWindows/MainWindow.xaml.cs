using Clinic.UI.ClientsWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Clinic.UI.RegistryWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Referral
        {
            public int Id { get; set; }
            public int DoctorId { get; set; }

            public int ClientId { get; set; }

            public int Hour { get; set; }

            public int Minutes { get; set; }

            public DateTime Date { get; set; }

            public override string ToString()
            {
                var minutesEnds = Minutes < 10
                    ? "0"
                    : "";
                var hourEnds = Hour < 10
                    ? "0"
                    : "";
                return hourEnds + Hour + ":" + minutesEnds +  Minutes;
            }
        }

        private static int dayOffsett = 1;

        private static List<Referral> Refferals = new()
        {
            new Referral
            {
                Id = 1,
                DoctorId = 1,
                ClientId = 1,
                Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + dayOffsett, 10, 30, 0),
                Hour = 10,
                Minutes = 30,
            },
            new Referral
            {
                Id = 2,
                DoctorId = 2,
                ClientId = 2,
                Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + dayOffsett, 10, 30, 0),
                Hour = 11,
                Minutes = 00,
            },
            new Referral
            {
                Id = 3,
                DoctorId = 1,
                ClientId = 3,
                Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + dayOffsett, 10, 30, 0),
                Hour = 11,
                Minutes = 30,
            },
            new Referral
            {
                Id = 4,
                DoctorId = 3,
                ClientId = 4,
                Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + dayOffsett, 10, 30, 0),
                Hour = 12,
                Minutes = 00,
            },
            new Referral
            {
                Id = 5,
                DoctorId = 2,
                ClientId = 5,
                Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + dayOffsett, 10, 30, 0),
                Hour = 14,
                Minutes = 00,
            },
            new Referral
            {
                Id = 6,
                DoctorId = 1,
                ClientId = 6,
                Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + dayOffsett, 10, 30, 0),
                Hour = 15,
                Minutes = 00,
            }
        };

        public class Doctor
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Department { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public static List<Doctor> Doctors = new()
        {
            new Doctor
            {
                Id = 1,
                Name = "Петров Пётр",
                Department = "Диагностическое отделение"
            },
            new Doctor
            {
                Id = 2,
                Name = "Иванов Иван",
                Department = "Терапевтическое отделение"
            },
            new Doctor
            {
                Id = 3,
                Name = "Сергеев Сергей",
                Department = "Диагностическое отделение"
            },
            new Doctor
            {
                Id = 4,
                Name = "Романов Роман",
                Department = "Диагностическое отделение"
            },
            new Doctor
            {
                Id = 5,
                Name = "Владимиров Владимир",
                Department = "Терапевтическое отделение"
            },
            new Doctor
            {
                Id = 6,
                Name = "Трушин Олег",
                Department = "Диагностическое отделение"
            },
            new Doctor
            {
                Id = 7,
                Name = "Кузнецов Кирилл",
                Department = "Терапевтическое отделение"
            }
        };

        public class Card
        {
            public int Id { get; set; }

            public Client Client { get; set; }

            public string UpdatedAt { get; set; }

            public Doctor Doctor { get; set; }

            public List<string> CardRecords { get; set; } = new()
            {
                "12.10.2022: Жалобы: на разрушение коронки",
                "12.10.2022: Анамез: зуб постепенно разрушался. Ранее лечен по поводу кариеса. Пломба выпала (частично).",
                "12.10.2022: Диагноз: Хронический периодонтит зуба. МКБ K04.5"
            };
        }

        public class Client
        {
            public int Id { get; set; }

            public string ClientName { get; set; }

            public string Address { get; set; }

            public string Phone { get; set; }

            public string BirthDate { get; set; }

            public override string ToString()
            {
                return ClientName + " (" + Address + ")";
            }
        }

        public List<Card> Cards { get; set; }
        public List<Client> Clients { get; set; }

        private const string RussianNames = "Памфил, Памфилий, Панкрат, Парфений, Парфентий, Патрикей, Патрикий, Радий, Радим, Радислав, Радован, Ратибор, Ратмир, Рафаил, Рем, Роберт, Родион, Роман, Ростислав, Савватей, Савватий, Савёл, Савелий, Саверий, Савин, Савиниан, Сакердон, Салтам, Самойла, Самсон, Самсоний, Самуил, Светозар";
        private const string RussianLastNames = "Кузнецов, Иванов, Шляпов, Метов";
        private const string Addresses = "Дворникова, Советская";

        public static Card GenerateCard(int id)
        {
            var lastNames = RussianLastNames.Split(", ");
            var lastNamesOuterRange = lastNames.Length;

            var rnd = new Random();
            var lastName = lastNames[rnd.Next(lastNamesOuterRange)];

            var firstNames = RussianNames.Split(", ");
            var firstNameOuterRange = firstNames.Length;

            var firstName = firstNames[rnd.Next(firstNameOuterRange)];

            return new Card
            {
                Client = new Client
                {
                    ClientName = lastName + " " + firstName,
                    Address = Addresses.Split(", ")[rnd.Next(2)] + " " + rnd.Next(100),
                    BirthDate = DateTime.Now.AddYears(-new Random().Next(18, 30)).ToString("d"),
                    Id = id,
                    Phone = (rnd.Next(9) + 1) * 10 + "-" + (rnd.Next(9) + 1) * 10 + "-" + (rnd.Next(9) + 1) * 10,
                },
                Doctor = Doctors[new Random().Next(0, Doctors.Capacity - 2)],
                UpdatedAt = DateTime.Now.AddDays(-rnd.Next(5)).ToString("d"),
                Id = id
            };
        }

        public MainWindow()
        {
            Cards = Enumerable.Range(1, 10)
                .Select(GenerateCard)
                .ToList();
            Clients = Cards.Select(x => x.Client).ToList();
            var otherClients = GenerateCard(Cards.Max(x => x.Id) + 1).Client;
            Clients.Add(otherClients);

            var deps = new List<string>
            {
                "(все)"
            };
            deps.AddRange(Doctors.Select(x => x.Department).Distinct());
            InitializeComponent();
            RefferalDatePicker.SelectedDate = DateTime.Now;
            DepartmamentCb.ItemsSource = deps;
            DepartmamentCb.SelectedItem = deps.First();
            CardsDataGrid.ItemsSource = Cards;
            ClientsDataGrid.ItemsSource = Clients;
            DoctorComboBox.ItemsSource = Doctors;
            DoctorComboBox.SelectedItem = Doctors.First();
        }

        private void SearchCardTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchNameCardTb.Text;
            var addressText = SearchAddressCardTb.Text;
            if (string.IsNullOrEmpty(searchText.Trim()) || string.IsNullOrEmpty(addressText))
            {
                CardsDataGrid.ItemsSource = null;
                CardsDataGrid.ItemsSource = Cards;
            }

            CardsDataGrid.ItemsSource = null;
            CardsDataGrid.ItemsSource = Cards
                .Where(c => c.Client.ClientName.StartsWith(searchText) && c.Client.Address.StartsWith(addressText))
                .ToList();
        }

        private void CreateCardBtn_Click(object sender, RoutedEventArgs e)
        {
            var clientsToShow = Clients
                .Where(x => Cards.All(z => z.Client.Id != x.Id))
                .ToList();
            var window = new CreateCardWindow(Doctors, clientsToShow);
            if (window.ShowDialog() == true)
            {
                var cardToAdd = new Card
                {
                    UpdatedAt = DateTime.Now.ToString("d"),
                    Client = window.Result.client,
                    Doctor = window.Result.doc,
                    Id = Cards.Max(x => x.Id) + 1
                };
                Cards.Add(cardToAdd);

                CardsDataGrid.ItemsSource = null;
                CardsDataGrid.ItemsSource = Cards;
                CardsDataGrid.SelectedItem = cardToAdd;
                MessageBox.Show("Карточка успешно создана");
            }
        }

        private void CardRecordsBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedCard = CardsDataGrid.SelectedItem as Card;
            if (selectedCard is null)
            {
                return;
            }
            new CardRecordsWindow(selectedCard.CardRecords).ShowDialog();
        }

        private void SearchClientTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchClientTb.Text;
            if (string.IsNullOrEmpty(searchText?.Trim()))
            {
                ClientsDataGrid.ItemsSource = null;
                ClientsDataGrid.ItemsSource = Clients;
            }

            ClientsDataGrid.ItemsSource = null;
            ClientsDataGrid.ItemsSource = Clients
                .Where(c => c.ClientName.StartsWith(searchText))
                .ToList();
        }

        private void CreateClientBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new InputClientWindow();
            if (window.ShowDialog() == true)
            {
                window.Result.Id = Clients.Max(x => x.Id) + 1;
                Clients.Add(window.Result);
                ClientsDataGrid.ItemsSource = null;
                ClientsDataGrid.ItemsSource = Clients;
                ClientsDataGrid.SelectedItem = window.Result;
                MessageBox.Show("Успешно добавлено");
            }
        }

        private void EditClientBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new InputClientWindow(ClientsDataGrid.SelectedItem as Client);
            if (window.ShowDialog() == true)
            {
                var resultCollection = Clients
                    .Where(x => x.Id != window.Result.Id).ToList();
                resultCollection.Add(window.Result);
                resultCollection = resultCollection.OrderBy(x => x.Id).ToList();
                var cardToReplace = Cards.FirstOrDefault(x => x.Client?.Id == window.Result.Id);
                if (cardToReplace is not null)
                {
                    cardToReplace.Client = window.Result;
                }
                ClientsDataGrid.ItemsSource = null;
                ClientsDataGrid.ItemsSource = resultCollection;
                ClientsDataGrid.SelectedItem = window.Result;
                CardsDataGrid.ItemsSource = null;
                CardsDataGrid.ItemsSource = Cards;
                MessageBox.Show("Успешно измененено");
            }
        }

        private void CreateReferralCardBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new CreateReferralWindow(Doctors, (CardsDataGrid.SelectedItem as Card)!.Client, Refferals);
            var dialogResult = window.ShowDialog();
            if (dialogResult == true)
            {
                MessageBox.Show("Запись успешно добавлена");
                window.Result.Id = Refferals.Max(x => x.Id) + 1;
                Refferals.Add(window.Result);
            }
        }

        private class ReferralEntry
        {
            public int Id { get; set; }

            public int ClientId { get; set; }

            public int DoctorId { get; set; }

            public string ClientName { get; set; }

            public string Date { get; set; }
        }

        private void ConfirmDoctorBtn_Click(object sender, RoutedEventArgs e)
        {
            var doctor = DoctorComboBox.SelectedItem as Doctor;
            var selected = RefferalDatePicker.SelectedDate;
            if (selected == null)
            {
                MessageBox.Show("Выберите дату");
                return;
            }

            var curDate = selected.Value;
            var todayActivities = Refferals
                .Where(x => x.DoctorId == doctor!.Id
                            && x.Date.Year == curDate.Year
                            && x.Date.Month == curDate.Month
                            && x.Date.Day == curDate.Day)
                .Select(x =>
                {
                    var client = Clients.First(z => z.Id == x.ClientId);

                    return new ReferralEntry
                    {
                        Id = x.Id,
                        ClientName = client.ClientName,
                        Date = x.Date.ToString("d") + " " + x,
                        ClientId = x.ClientId,
                        DoctorId = x.DoctorId
                    };
                })
                .ToList();

            RecordsDataGrid.ItemsSource = todayActivities;
        }

        private void CardsDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CardsDataGrid.SelectedItem is Card)
            {
                CreateReferralCardBtn.IsEnabled = true;
                CardRecordsBtn.IsEnabled = true;
            }
            else
            {
                CreateReferralCardBtn.IsEnabled = false;
                CardRecordsBtn.IsEnabled = false;
            }
        }

        private void ClientsDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientsDataGrid.SelectedItem is Client)
            {
                EditClientBtn.IsEnabled = true;
            }
            else
            {
                EditClientBtn.IsEnabled = false;
            }
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DepartmamentCb.SelectedItem is string str)
            {
                if (str == "(все)")
                {
                    DoctorComboBox.ItemsSource = null;
                    DoctorComboBox.ItemsSource = Doctors;
                    DoctorComboBox.SelectedItem = Doctors.First();
                }
                else
                {
                    var res = Doctors
                        .Where(x => x.Department == str)
                        .ToList();
                    DoctorComboBox.ItemsSource = null;
                    DoctorComboBox.ItemsSource = res;
                    DoctorComboBox.SelectedItem = res.First();
                }
            }
        }

        private void RemoveRefferalBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem is ReferralEntry entry)
            {
                var dialogResult = MessageBox.Show(this, "Вы действительно хотите удалить запись?", "Удаление",
                    MessageBoxButton.YesNo);

                if (dialogResult == MessageBoxResult.Yes)
                {
                    Refferals = Refferals.Where(x => x.Id != entry.Id).ToList();
                    ConfirmDoctorBtn_Click(default, default);
                }
            }
        }

        private void RecordsDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem is ReferralEntry)
            {
                RemoveRefferalBtn.IsEnabled = true;
            }
            else
            {
                RemoveRefferalBtn.IsEnabled = false;
            }
        }
    }
}