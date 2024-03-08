using Microsoft.Maui.Controls;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        string currentNumber = "0";
        string selectedOperator;
        double result = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        void OnClear(object sender, EventArgs e)
        {
            result = 0;
            currentNumber = "0";
            resultText.Text = currentNumber;
        }

        void OnDelete(object sender, EventArgs e)
        {
            if (currentNumber.Length > 1)
            {
                currentNumber = currentNumber.Remove(currentNumber.Length - 1);
            }
            else
            {
                currentNumber = "0";
            }
            resultText.Text = currentNumber;
        }

        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;
            
            if (pressed == "." && currentNumber.Contains("."))
            {
                return;
            }

            if (currentNumber == "0")
            {
                currentNumber = pressed;
            }
            else
            {
                currentNumber += pressed;
            }
            resultText.Text = currentNumber;
        }


        void OnSelectOperator(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            selectedOperator = button.Text;

            if (double.TryParse(currentNumber, out double parsedNumber))
            {
                result = parsedNumber;
                currentNumber = "0";
                resultText.Text = currentNumber;
            }
        }

        void OnCalculate(object sender, EventArgs e)
        {
            if (double.TryParse(currentNumber, out double parsedNumber))
            {
                switch (selectedOperator)
                {
                    case "+":
                        result += parsedNumber;
                        break;
                    case "-":
                        result -= parsedNumber;
                        break;
                    case "×":
                        result *= parsedNumber;
                        break;
                    case "/":
                        if (parsedNumber != 0)
                        {
                            result /= parsedNumber;
                        }
                        else
                        {
                            resultText.Text = "Error";
                            return;
                        }
                        break;
                }
                currentNumber = result.ToString();
                resultText.Text = currentNumber;
            }
        }
        
        private void Button_Pressed(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundColor = Colors.DimGray;
        }

        private void Button_Released1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundColor = Colors.Gray;
        }
        
        private void Button_Released2(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundColor = Colors.Orange;
        }
    }
}
