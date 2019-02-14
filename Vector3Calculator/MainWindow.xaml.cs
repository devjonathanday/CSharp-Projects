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

namespace Vector3Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FormulaSelect.SelectedItem = addition;
            ResizeMode = ResizeMode.NoResize;
        }

        private void Button_Click(object sender, RoutedEventArgs e) { runOperation(); }
        private void KeyDownHandler(object sender, KeyEventArgs e) { if (e.Key == Key.Return || e.Key == Key.Enter) runOperation(); }

        private void runOperation()
        {
            //Set values to 0 if they are blank
            float parsedValue = 0;
            if (VectorAX.Text == string.Empty || !float.TryParse(VectorAX.Text, out parsedValue)) VectorAX.Text = "0";
            if (VectorAY.Text == string.Empty || !float.TryParse(VectorAY.Text, out parsedValue)) VectorAY.Text = "0";
            if (VectorAZ.Text == string.Empty || !float.TryParse(VectorAZ.Text, out parsedValue)) VectorAZ.Text = "0";
            if (VectorBX.Text == string.Empty || !float.TryParse(VectorBX.Text, out parsedValue)) VectorBX.Text = "0";
            if (VectorBY.Text == string.Empty || !float.TryParse(VectorBY.Text, out parsedValue)) VectorBY.Text = "0";
            if (VectorBZ.Text == string.Empty || !float.TryParse(VectorBZ.Text, out parsedValue)) VectorBZ.Text = "0";
            Vector3 vecA = new Vector3(float.Parse(VectorAX.Text), float.Parse(VectorAY.Text), float.Parse(VectorAZ.Text));
            Vector3 vecB = new Vector3(float.Parse(VectorBX.Text), float.Parse(VectorBY.Text), float.Parse(VectorBZ.Text));
            if (FormulaSelect.SelectedItem == addition)
            {
                Vector3 vecC = vecA.Sum(vecB);
                Output.Text = "Output: (" + vecC.x + ", " + vecC.y + ", " + vecC.z + ")";
            }
            else if (FormulaSelect.SelectedItem == subtraction)
            {
                Vector3 vecC = vecA.Difference(vecB);
                Output.Text = "Output: (" + vecC.x + ", " + vecC.y + ", " + vecC.z + ")";
            }
            else if (FormulaSelect.SelectedItem == magnitude)
            {
                double result = vecA.magnitude;
                Output.Text = "Output: " + result;
            }
            else if (FormulaSelect.SelectedItem == normalize)
            {
                if (VectorAX.Text == "0" && VectorAY.Text == "0" && VectorAZ.Text == "0") Output.Text = "Output: Invalid, cannot normalize zero vector";
                else { Vector3 vecC = vecA.normalized; Output.Text = "Output: (" + vecC.x + ", " + vecC.y + ", " + vecC.z + ")"; }
            }
            else if (FormulaSelect.SelectedItem == dotProduct)
            {
                float dot = vecA.Dot(vecB);
                Output.Text = "Output: " + dot;
            }
        }

        private void RefreshUI(object sender, SelectionChangedEventArgs e)
        {
            if(FormulaSelect.SelectedItem == addition) { ShowSecondVector(true); OperationSymbol.Text = "+"; }
            else if (FormulaSelect.SelectedItem == subtraction) { ShowSecondVector(true); OperationSymbol.Text = "-"; }
            else if (FormulaSelect.SelectedItem == magnitude) { ShowSecondVector(false); OperationSymbol.Text = "Magnitude"; }
            else if (FormulaSelect.SelectedItem == normalize) { ShowSecondVector(false); OperationSymbol.Text = "Normalize"; }
            else if (FormulaSelect.SelectedItem == dotProduct) { ShowSecondVector(true); OperationSymbol.Text = "Dot Product"; }
        }

        private void ShowSecondVector(bool visible)
        {
            if(visible)
            {
                VectorBLabel.Visibility = Visibility.Visible;
                VectorBX.Visibility = Visibility.Visible;
                VectorBY.Visibility = Visibility.Visible;
                VectorBZ.Visibility = Visibility.Visible;
            }
            else {
                VectorBLabel.Visibility = Visibility.Hidden;
                VectorBX.Visibility = Visibility.Hidden;
                VectorBY.Visibility = Visibility.Hidden;
                VectorBZ.Visibility = Visibility.Hidden;
            }
        }
    }
}
