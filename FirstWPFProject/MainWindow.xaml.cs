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
            ValidateInput(distance, distance_error, 0.0, 1000.0, "Distance");
        }

        private void TextBox_TextChanged_Tariff(object sender, TextChangedEventArgs e)
        {
            ValidateInput(tariff, tariff_error, 0.0, 100.0, "Tariff", false);
        }

        private void TextBox_TextChanged_Basic_Price(object sender, TextChangedEventArgs e)
        {
            ValidateInput(basic_price, price_error, 0.0, 100.0, "Price", false);
        }

        private void TextBox_TextChanged_Waiting_Time(object sender, TextChangedEventArgs e)
        {
            ValidateInput(waiting_time, time_error, 0.0, 600.0, "Time");
        }

        private void TextBox_TextChanged_Waiting_Tariff(object sender, TextChangedEventArgs e)
        {
            ValidateInput(waiting_tariff, waiting_tariff_error, 0.0, 100.0, "Waiting tariff", false);
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

        private void ValidateInput(TextBox textBox, TextBlock errorBlock, double min, double max, string name, bool AllowZero = true)
        {
            errorBlock.Text = "";
            try
            {
                double value = Double.Parse(textBox.Text);

                if (!AllowZero && value <= 0)
                {
                    errorBlock.Text = $"{name} must be > {min}";
                    return;
                }
                if (AllowZero && value < min)
                {
                    errorBlock.Text = $"{name} must be >= {min}";
                    return;
                }
                if (value > max)
                {
                    errorBlock.Text = $"{name} must be <= {max}";
                }
            }
            catch (FormatException)
            {
                errorBlock.Text = $"{name} can't be empty or text";
            }
        }
    }
}