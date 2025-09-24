using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirstWPFProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged_Distance(object sender, TextChangedEventArgs e)
        {
            distance_error.Text = "";
            try
            {
                double distance_value = Double.Parse(distance.Text);
                if (distance_value <= 0) {
                    distance_error.Text = "Distance must be > 0";
                }
                if (distance_value > 1000)
                {
                    distance_error.Text = "Distance must be <= 1000";
                }
            }
            catch (FormatException ex)
            {
                distance_error.Text = "Distance can't be empty or text";
            }
        }

        private void TextBox_TextChanged_Tariff(object sender, TextChangedEventArgs e)
        {
            tariff_error.Text = "";
            try
            {
                double tariff_value = Double.Parse(tariff.Text);
                if (tariff_value < 0)
                {
                    tariff_error.Text = "Tariff must be >= 0";
                }
                if (tariff_value > 100)
                {
                    tariff_error.Text = "Distance must be <= 100";
                }
            }
            catch (FormatException ex)
            {
                tariff_error.Text = "Tariff can't be empty or text";
            }
        }

        private void TextBox_TextChanged_Basic_Price(object sender, TextChangedEventArgs e)
        {
            price_error.Text = "";
            try
            {
                double price_value = Double.Parse(basic_price.Text);
                if (price_value < 0)
                {
                    price_error.Text = "Price must be >= 0";
                }
                if (price_value > 100)
                {
                    price_error.Text = "Price must be <= 100";
                }
            }
            catch (FormatException ex)
            {
                price_error.Text = "Price can't be empty or text";
            }
        }

        private void TextBox_TextChanged_Waiting_Time(object sender, TextChangedEventArgs e)
        {
            time_error.Text = "";
            try
            {
                double time_value = Double.Parse(waiting_time.Text);
                if (time_value <= 0)
                {
                    time_error.Text = "Time must be > 0";
                }
                if (time_value > 600)
                {
                    time_error.Text = "Time must be <= 600";
                }
            }
            catch (FormatException ex)
            {
                time_error.Text = "Time can't be empty or text";
            }
        }

        private void TextBox_TextChanged_Waiting_Tariff(object sender, TextChangedEventArgs e)
        {
            waiting_tariff_error.Text = "";
            try
            {
                double waiting_tariff_value = Double.Parse(waiting_tariff.Text);
                if (waiting_tariff_value < 0)
                {
                    waiting_tariff_error.Text = "Waiting tariff must be >= 0";
                }
                if (waiting_tariff_value > 100)
                {
                    waiting_tariff_error.Text = "Waiting must be <= 100";
                }
            }
            catch (FormatException ex)
            {
                waiting_tariff_error.Text = "Waiting tariff can't be empty or text";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (distance_error.Text != "" || tariff_error.Text != "" || price_error.Text != "" || time_error.Text != "" || waiting_tariff_error.Text != "")
            {
                form_error.Text = "Please enter correct values!";
            }
            else
            {
                form_error.Text = "";
                double distance_value = Double.Parse(distance.Text);
                double tariff_value = Double.Parse(tariff.Text);
                double price_value = Double.Parse(basic_price.Text);
                double time_value = Double.Parse(waiting_time.Text);
                double waiting_tariff_value = Double.Parse(waiting_tariff.Text);
                double final_price_value = price_value + distance_value * tariff_value + time_value * waiting_tariff_value;
                final_price.Text = final_price_value.ToString("0.00");

            }
        }

        private void TextBox_TextChanged_Final_Price(object sender, TextChangedEventArgs e)
        {

        }
    }
}