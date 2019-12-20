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
        float a, b;
        int count;
        bool znakmin = false;


        public MainPage()
        {
            this.InitializeComponent();
            sumText.Text = "0";
            numText.Text = "0";
        }
        private void CalculateSum()
        {
            switch (count)
            {
                case 1:
                    b = a + float.Parse(sumText.Text);
                    sumText.Text = b.ToString("F8");
                    break;
                case 2:
                    b = a - float.Parse(sumText.Text);
                    sumText.Text = b.ToString("F8");
                    break;
                case 3:
                    b = a * float.Parse(sumText.Text);
                    sumText.Text = b.ToString("F8");
                    break;
                case 4:
                    float divider;
                    divider = float.Parse(sumText.Text);
                    if (divider == 0.0)
                        sumText.Text ="Деление на ноль";
                    else
                    {
                        b = a / divider;
                        sumText.Text = b.ToString();
                    }
                        break;

                default:
                    break;
            }

        }
        private void Sum_Click(object sender)
        {
            numText.Text = sumText.Text + (sender as Button).Content;
            sumText.Text = "0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sumText.Text =="0")
                sumText.Text =  (sender as Button).Content.ToString();
            else
                sumText.Text += (sender as Button).Content;
        }


        private void NumComButton_Click(object sender, RoutedEventArgs e)
        {
            if (sumText.Text.IndexOf(",") == -1)
                sumText.Text += (sender as Button).Content;
            
        }

        private void NumPlusButton_Click(object sender, RoutedEventArgs e)
        {
            a = float.Parse(sumText.Text);
            count = 1;
            Sum_Click(sender);
        }

        private void NumMinusButtonmultiply_Click(object sender, RoutedEventArgs e)
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

            if (!znakmin)
            {
                sumText.Text = "-" + sumText.Text;
                znakmin = true;
            }
            else if (znakmin)
            {
                sumText.Text = sumText.Text.Replace("-", "");
                znakmin = false;
            }
        }

        private void NumEquaButton_Click(object sender, RoutedEventArgs e)
        {
            numText.Text += sumText.Text + (sender as Button).Content;
            CalculateSum();
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
            numText.Text = "0";
        }
    }
}
