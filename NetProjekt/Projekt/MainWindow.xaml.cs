using System;
using System.Collections.ObjectModel;
using System.Windows;
namespace Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Order> OrderList { get; set; }
        public int numberOfOrders = 0;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            
            OrderList = new ObservableCollection<Order>();


            this.MiesoComboBox.ItemsSource = Enum.GetValues(typeof(Food.Miesne));
            this.MiesoComboBox.SelectedIndex = 0;

            this.RybaComboBox.ItemsSource = Enum.GetValues(typeof(Food.Ryby));
            this.RybaComboBox.SelectedIndex = 0;

            this.DodatkiComboBox.ItemsSource = Enum.GetValues(typeof(Food.Dodatki));
            this.DodatkiComboBox.SelectedIndex = 0;


        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            Order order;
            bool bonus;
            if (RadioBonusButton.IsChecked == true)
                bonus = true;
            else
                bonus = false;

            Food.Dodatki dod = (Food.Dodatki)Enum.Parse(typeof(Food.Dodatki), this.DodatkiComboBox.Text);
            Food.Miesne mies = (Food.Miesne)Enum.Parse(typeof(Food.Miesne), this.MiesoComboBox.Text);
            Food.Ryby ryb = (Food.Ryby)Enum.Parse(typeof(Food.Ryby), this.RybaComboBox.Text);

            Client client = new Client(ImieTextBox.Text, NazwiskoTextBox.Text, numberOfOrders++);
            Employee employee = new Employee("Jan", "Kowalski", rnd.Next(0, 100));
            order = new Order(client, employee, numberOfOrders - 1, dod, mies , ryb  , bonus);

            try
            {

                if(client.name == "" || client.surname == "" || (dod == Food.Dodatki.brak) && (mies == Food.Miesne.brak) && (ryb == Food.Ryby.brak) )
                {
                    GiveNullError();
                }

                OrderList.Add(order);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wypelnij pola imienia i nazwiska oraz uzupelnij zamowienie");
            }
            
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                this.DodatkiComboBox.SelectedIndex = 0;
                this.MiesoComboBox.SelectedIndex = 0;
                this.RybaComboBox.SelectedIndex = 0;

                if (this.ImieTextBox.Text != "" && this.NazwiskoTextBox.Text != "")
                {
                    this.ImieTextBox.Text = "";
                    this.NazwiskoTextBox.Text = "";
                }
                else
                    GiveNullError();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie można wyczyscic pustych pól");
            }
            
        }


        static void GiveNullError()
        {
            throw new System.NullReferenceException("Null");
        }
    }
}
