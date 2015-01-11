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
                csCalculator.add(Convert.ToDouble(AddText.Text));
                updateOutput();
            }
        }

        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            csCalculator.subtract(Convert.ToDouble(SubtractText.Text));
            updateOutput();
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            csCalculator.multiply(Convert.ToDouble(MultiplyText.Text));
            updateOutput();
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            // Check for divide by 0 done within Cs method
            csCalculator.divide(Convert.ToDouble(DivideText.Text));
            updateOutput();
        }

        private void updateOutput()
        {
            OutputText.Text = csCalculator.OutputValue.ToString();
        }
    }
}
