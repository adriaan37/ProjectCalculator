using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectCalculator
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private double firstNumber;
        private string @operator;
        private bool isOperatorClicked;

        private void ButtonCommon_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if(Result.Text == "0"||isOperatorClicked)
            { 
                isOperatorClicked = false;
                Result.Text = button.Text;
                
            }
            else
            {
                
                Result.Text += button.Text;
            }           
        }

        private void ButtonOne_Clicked(object sender, EventArgs e)
        {
            Result.Text = "1";
        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            Result.Text = "0";
            isOperatorClicked = false;
            firstNumber = 0;
        }

        private void DEL_Clicked(object sender, EventArgs e)
        {
            string number = Result.Text;

            if(number !="0")
            {
                number = number.Remove(number.Length -1,1);
                if(string.IsNullOrEmpty(number))
                {
                    Result.Text = "0";

                }
                else
                {
                    Result.Text = number;
                }
            }
        }

 

        private void ButtonCommonOperator_Clicked (object sender, EventArgs e)
        {
            var button = sender as Button;
            isOperatorClicked = true;
            @operator = button.Text;
            firstNumber = Convert.ToDouble(Result.Text);
        }


        private void ButtonEquals_Clicked(object sender, EventArgs e)
        {
            try
            {
                double secondNumber = Convert.ToDouble(Result.Text);
                string finalResult = Calculate(firstNumber, secondNumber).ToString("0.##");
                Result.Text = finalResult;
            }
            catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public double Calculate(double firstNumber, double secondnumber)
        {
            double result = 0;
            if(@operator == "+")
            {
                result = firstNumber + secondnumber;
            }
            else if( @operator == "-")
            {
                result = firstNumber - secondnumber;
            }
            else if (@operator == "*")
            {
                result = firstNumber * secondnumber;
            }
            else if (@operator == "/")
            {
                result = firstNumber / secondnumber;
            }
            return result;
        }


    }

}
