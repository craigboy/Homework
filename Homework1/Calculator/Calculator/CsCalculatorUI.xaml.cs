using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Calculator
{
    public sealed partial class CsCalculatorUI : UserControl
    {
        CsCalculator csCalculator;
        
        public CsCalculatorUI()
        {
            this.InitializeComponent();
            this.csCalculator = new CsCalculator();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            double value = 0;
            if (double.TryParse(AddText.Text, out value))
            {
                csCalculator.add(value);
                updateOutput();
                ErrorText.Text = "";
            }
            else
            {
                ErrorText.Text = "Invalid Input";
            }
        }

        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            double value = 0;
            if (double.TryParse(SubtractText.Text, out value))
            {
                csCalculator.subtract(value);
                updateOutput();
                ErrorText.Text = "";
            }
            else
            {
                ErrorText.Text = "Invalid Input";
            }
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            double value = 0;
            if (double.TryParse(MultiplyText.Text, out value))
            {
                csCalculator.multiply(value);
                updateOutput();
                ErrorText.Text = "";
            }
            else
            {
                ErrorText.Text = "Invalid Input";
            }
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            double value = 0;
            if (double.TryParse(DivideText.Text, out value) && value != 0)
            {
                csCalculator.divide(value);
                updateOutput();
                ErrorText.Text = "";
            }
            else
            {
                ErrorText.Text = "Invalid Input";
            }
        }

        private void updateOutput()
        {
            OutputText.Text = csCalculator.OutputValue.ToString();
        }
    }
}
