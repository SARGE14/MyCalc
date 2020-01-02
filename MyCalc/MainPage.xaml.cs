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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace MyCalc
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        float a;
        int count = 0;
        bool znak = false;
        string numberKey;

        public MainPage()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.SetPreferredMinSize(new Size(345, 400));
            sumText.Text = "0";
            numText.Text = "";
        }
        private void CalculateSum()
        {
            switch (count)
            {
                case 1:
                    a += float.Parse(sumText.Text);
                    sumText.Text = a.ToString("F8");
                    break;
                case 2:
                    a -= float.Parse(sumText.Text);
                    sumText.Text = a.ToString("F8");
                    break;
                case 3:
                    a *= float.Parse(sumText.Text);
                    sumText.Text = a.ToString("F8");
                    break;
                case 4:
                    float divider;
                    divider = float.Parse(sumText.Text);
                    if (divider == 0.0)
                        numText.Text = "Деление на ноль";
                    else
                    {
                        a /= divider;
                        sumText.Text = a.ToString("F8");
                    }
                    break;

                default:
                    break;
            }
            int lenght = sumText.Text.Length - 1;
            string text = sumText.Text;
            //  sumText.Text = "";
            for (int i = lenght; i > 0; --i)
            {
                if (text[i].ToString() == ",")
                {
                    sumText.Text = sumText.Text.Remove(i, 1);
                    break;
                }
                else if (text[i].ToString() == "0")
                        sumText.Text = sumText.Text.Remove(i, 1);
                    else
                        break;
            }
        }

        private void Sum_Click(object sender)
        {
            znak = true;
            int lenght = numText.Text.Length - 1;
            string text = numText.Text;
            if (numText.Text.IndexOf((sender as Button).Content.ToString()) == -1)
            {
                numText.Text = sumText.Text + (sender as Button).Content;
            }
            else
            {
                numText.Text = "";
                for (int i = 0; i < lenght; i++)
                {
                    numText.Text += text[i];
                }
                numText.Text = a.ToString() + (sender as Button).Content;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sumText.Text == "0" || numText.Text == "Деление на ноль" || znak)
            {
                sumText.Text = (sender as Button).Content.ToString();
                znak = false;
            }
            else
                sumText.Text += (sender as Button).Content;

            if (numText.Text == "Деление на ноль")
                numText.Text = "";
        }


        private void NumComButton_Click(object sender, RoutedEventArgs e)
        {
            if (sumText.Text.IndexOf(",") == -1)
                sumText.Text += (sender as Button).Content;

        }

        private void NumAddButton_Click(object sender, RoutedEventArgs e)
        {
            a = float.Parse(sumText.Text);
            count = 1;
            Sum_Click(sender);
        }

        private void NumSubtractButton_Click(object sender, RoutedEventArgs e)
        {
            a = float.Parse(sumText.Text);
            count = 2;
            Sum_Click(sender);
        }

        private void NumMultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            a = float.Parse(sumText.Text);
            count = 3;
            Sum_Click(sender);
        }

        private void NumDivideButton_Click(object sender, RoutedEventArgs e)
        {
            a = float.Parse(sumText.Text);
            count = 4;
            Sum_Click(sender);
        }

        private void ZnakMinusButton_Click_(object sender, RoutedEventArgs e)
        {
            if (sumText.Text != "0")
                if (sumText.Text[0] == '-')
                    sumText.Text = sumText.Text.Remove(0, 1);
                else
                    sumText.Text = "-" + sumText.Text;
        }

        private void NumEnterButton_Click(object sender, RoutedEventArgs e)
        {

            if (numText.Text.IndexOf("=") == -1)
                numText.Text += sumText.Text + (sender as Button).Content;
            CalculateSum();
            znak = true;
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            int lenght = sumText.Text.Length - 1;
            string text = sumText.Text;
            sumText.Text = "";
            for (int i = 0; i < lenght; i++)
            {
                sumText.Text += text[i];
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            sumText.Text = "0";
            numText.Text = "";
            a = 0;
        }

        private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            numberKey = e.Key.ToString();
            switch (numberKey)
            {
                case "Number0":
                case "NumberPad0":
                    sender = Num0Button;
                    Button_Click(sender, e);
                    break;
                case "Number1":
                case "NumberPad1":
                    sender = Num1Button;
                    Button_Click(sender, e);
                    break;
                case "Number2":
                case "NumberPad2":
                    sender = Num2Button;
                    Button_Click(sender, e);
                    break;
                case "Number3":
                case "NumberPad3":
                    sender = Num3Button;
                    Button_Click(sender, e);
                    break;
                case "Number4":
                case "NumberPad4":
                    sender = Num4Button;
                    Button_Click(sender, e);
                    break;
                case "Number5":
                case "NumberPad5":
                    sender = Num5Button;
                    Button_Click(sender, e);
                    break;
                case "Number6":
                case "NumberPad6":
                    sender = Num6Button;
                    Button_Click(sender, e);
                    break;
                case "Number7":
                case "NumberPad7":
                    sender = Num7Button;
                    Button_Click(sender, e);
                    break;
                case "Number8":
                case "NumberPad8":
                    sender = Num8Button;
                    Button_Click(sender, e);
                    break;
                case "Number9":
                case "NumberPad9":
                    sender = Num9Button;
                    Button_Click(sender, e);
                    break;
                case "Back":
                    DelButton_Click(sender, e);
                    break;
                case "Decimal":
                    sender = NumComButton;
                    NumComButton_Click(sender, e);
                    break;
                case "Add":
                    sender = NumAddButton;
                    NumAddButton_Click(sender, e);
                    break;
                case "Subtract":
                    sender = NumSubtractButton;
                    NumSubtractButton_Click(sender, e);
                    break;
                case "Multiply":
                    sender = NumMultiplyButton;
                    NumMultiplyButton_Click(sender, e);
                    break;
                case "Divide":
                    sender = NumDivideButton;
                    //NumDivideButton.
                    NumDivideButton_Click(sender, e);
                    break;
                case "Enter":
                    sender = NumEnterButton;
                    NumEnterButton_Click(sender, e);
                    break;

            }
        }



      
    }
}
