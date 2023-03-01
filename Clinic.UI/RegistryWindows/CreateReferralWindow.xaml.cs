using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Clinic.UI.RegistryWindows
{
    /// <summary>
    /// Interaction logic for CreateReferralWindow.xaml
    /// </summary>
    public partial class CreateReferralWindow : Window
    {
        private readonly List<MainWindow.Doctor> Doctors;
        private readonly List<MainWindow.Referral> Referrals;
        private readonly MainWindow.Client Client;

        public MainWindow.Referral Result { get; set; }

        public CreateReferralWindow(List<MainWindow.Doctor> doctors, MainWindow.Client client, List<MainWindow.Referral> referrals)
        {
            Client = client;
            Doctors = doctors;
            Referrals = referrals;
            InitializeComponent();

            ClientComboBox.Text = client.ClientName;
            DoctorComboBox.SelectionChanged += (_, _) =>
            {
                if (DoctorComboBox.SelectedItem is not MainWindow.Doctor doc)
                {
                    RecordsListBox.ItemsSource = null;
                }
                else
                {
                    var date = RecordDatePicker.SelectedDate;
                    if (date is not null)
                    {
                        var records = Referrals
                            .Where(x => x.DoctorId == doc.Id
                                        && x.Date.Day == date.Value.Day
                                        && x.Date.Month == date.Value.Month
                                        && x.Date.Year == date.Value.Year)
                            .OrderBy(x => x.Hour)
                            .ThenBy(x => x.Minutes)
                            .ToList();

                        RecordsListBox.ItemsSource = records;
                    }
                }
            };
            RecordDatePicker.SelectedDateChanged += (_, _) =>
            {
                var date = RecordDatePicker.SelectedDate;
                if (date is null)
                {
                    RecordsListBox.ItemsSource = null;
                }
                else
                {
                    if (DoctorComboBox.SelectedItem is MainWindow.Doctor doc)
                    {
                        var records = Referrals
                            .Where(x => x.DoctorId == doc.Id
                                        && x.Date.Day == date.Value.Day
                                        && x.Date.Month == date.Value.Month
                                        && x.Date.Year == date.Value.Year)
                            .OrderBy(x => x.Hour)
                            .ThenBy(x => x.Minutes)
                            .ToList();

                        RecordsListBox.ItemsSource = records;
                    }
                }
            };
            DepartmentComboBox.ItemsSource = doctors.Select(x => x.Department).Distinct().ToList();
            DepartmentComboBox.SelectionChanged += (_, _) =>
            {
                if (DepartmentComboBox.SelectedItem is string dep)
                {
                    var docs = Doctors.Where(x => x.Department == dep).ToList();
                    DoctorComboBox.Text = "";
                    DoctorComboBox.ItemsSource = docs;
                }
                else
                {
                    DoctorComboBox.Text = "";
                    DoctorComboBox.ItemsSource = null;
                }
            };
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var time = ReferralTimePicker.Text;
            if (string.IsNullOrEmpty(time))
            {
                MessageBox.Show("Время должно быть выбрано");
                return;
            }

            var splattedTime = time.Split(":").Select(int.Parse).ToList();
            if (splattedTime[0] > 20 || splattedTime[0] < 8)
            {
                MessageBox.Show("Время должно быть в рамках 8-20");
                return;
            }

            if (DoctorComboBox.SelectedItem is not MainWindow.Doctor doc)
            {
                MessageBox.Show("Выберите врача");
                return;
            }

            var date = RecordDatePicker.SelectedDate;
            if (date is null)
            {
                MessageBox.Show("Выберите дату");
                return;
            }

            var now = DateTime.Now;
            var cur = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, splattedTime[0], splattedTime[1],
                0);
            if (now > cur)
            {
                MessageBox.Show("Нельзя выбрать прошлую дату");
                return;
            }

            var refferalDates = Referrals.Where(x => x.Date.Year == date.Value.Year
                                                     && x.Date.Month == date.Value.Month
                                                     && x.Date.Day == date.Value.Day && doc.Id == x.DoctorId)
                .ToList();
            var curValue = splattedTime[0] * 60 + splattedTime[1];
            if (refferalDates.Any(x =>
                {
                    var xValue = x.Hour * 60 + x.Minutes;

                    var result = xValue - curValue;
                    if (result < 0)
                    {
                        result *= -1;
                    }

                    return result < 30;
                }))
            {
                MessageBox.Show("Между записями должно быть 30 минут");
                return;
            }

            Result = new MainWindow.Referral
            {
                Date = date.Value,
                ClientId = Client.Id,
                DoctorId = doc.Id,
                Hour = splattedTime[0],
                Minutes = splattedTime[1]
            };
            DialogResult = true;
        }
    }
}