using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUIBMICalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ChangeWeight();
        }

        // Slider function
        private void SlWeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ChangeWeight();
        }

        void ChangeWeight()
        {

        }
        // The majority of the logic lies within the button event
        // Once it is clicked, it checks both textboxes for the correct characters
        // and perofrms the calculations
        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double _feetVal = 0;
            double _inchesVal = 0;
            double _heightVal = 0;
            double _weightVal = slWeight.Value;
            double _bmiVal = 0;

            if (!double.TryParse(txtFeet.Text, out _feetVal) || _feetVal < 0)
            {
                txtFeet.Background = Brushes.Red;
                return;
            }
            else
            {
                txtFeet.Background = Brushes.White;
            }

            if (!double.TryParse(txtInches.Text, out _inchesVal) || _inchesVal < 0)
            {
                txtInches.Background = Brushes.Red;
                return;
            }
            else
            {
                txtInches.Background = Brushes.White;
            }

            if (_inchesVal == 0 && _feetVal == 0)
            {
                txtFeet.Background = Brushes.Red;
                txtInches.Background = Brushes.Red;
                return;
            }
            else
            {
                txtFeet.Background = Brushes.White;
                txtInches.Background = Brushes.White;
            }
            _heightVal = (_feetVal * 12) + _inchesVal;
            _bmiVal = (_weightVal / (_heightVal * _heightVal) * 703);

            // All pictures except the corresponding picture collapse
            if (_bmiVal >= 30) // OBESE
            {
                unknown.Visibility = Visibility.Collapsed;
                obese.Visibility = Visibility.Visible; // ENABLED
                overweight.Visibility = Visibility.Collapsed;
                healthy.Visibility = Visibility.Collapsed;
                underweight.Visibility = Visibility.Collapsed;
            }
            else if (_bmiVal >= 25) // OVERWEIGHT
            {
                unknown.Visibility = Visibility.Collapsed;
                obese.Visibility = Visibility.Collapsed;
                overweight.Visibility = Visibility.Visible; // ENABLED
                healthy.Visibility = Visibility.Collapsed;
                underweight.Visibility = Visibility.Collapsed;
            }
            else if (_bmiVal >= 18.5) // HEALTHY
            {
                unknown.Visibility = Visibility.Collapsed;
                obese.Visibility = Visibility.Collapsed;
                overweight.Visibility = Visibility.Collapsed;
                healthy.Visibility = Visibility.Visible; // ENABLED
                underweight.Visibility = Visibility.Collapsed;
            }
            else // UNDERWEIGHT
            {
                unknown.Visibility = Visibility.Collapsed;
                obese.Visibility = Visibility.Collapsed;
                overweight.Visibility = Visibility.Collapsed;
                healthy.Visibility = Visibility.Collapsed;
                underweight.Visibility = Visibility.Visible; // ENABLED
            }
            // Rounds the BMI value to two decimal places
            lblBmiDisplay.Content = Math.Round(_bmiVal, 2);
        }
    }
}
