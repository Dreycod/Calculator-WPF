using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Suzuki_André_Calculatrice
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

        // Variables
        double num_1 = 0;
        double num_2 = 0;
        double result;
        const double pi = 3.1416;
        char operation='0';
        // Fonctions
        public void AppendText(string Texte)
        {
            TB_Display.Text += Texte;
        }
        public void ClearText()
        {
            TB_Display.Text = "";
        }

        public Boolean IsTextaNumber()
        {
            try
            {
                Double.Parse(TB_Display.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean IsResult()
        {
            if (IsTextaNumber())
            {
                return Double.Parse(TB_Display.Text) == result;
            }
            else
                return false;
        }

        public void Afficher(double num, Button BTN)
        {

            if (TB_Display.Text == "0" | IsTextaNumber()!=true | (TB_Display.Text != "" && IsResult()==true))
            {
                if (BTN != null)
                {
                   TB_Display.Text = BTN.Content.ToString();
                }
                else
                {
                   TB_Display.Text = num.ToString();
                }
                return;
            }
            else
            {
                if (BTN != null)
                {
                    AppendText(BTN.Content.ToString());
                }
                else
                {
                    AppendText(num.ToString());
                }
            }
        }

        public void Save_operation(char x)
        {
            if (TB_Display.Text == "ERROR" | TB_Display.Text == "" && operation == '0')
            {
                return;
            }

            if (operation == '0')
            {
                num_1 = Double.Parse(TB_Display.Text);
                ClearText();
                operation = x;
            }
            else if (operation != '0' && TB_Display.Text == "")
            {
                operation = x;
            }
            else
            {
                Equal();
            }
        }

        public void Equal()
        {

            if (TB_Display.Text == "ERROR")
            {
                TB_Display.Text = TB_Display.Text;
                return;
            }

            num_2 = Double.Parse(TB_Display.Text);

            ClearText();

            if (operation == '+')
            {
                result = num_1+num_2;
            }
            else if (operation == '-')
            {
                result=num_1-num_2; 
            }
            else if (operation == '*')
            {
                result = num_1*num_2;
            }
            else if (operation == '/')
            {
                if (num_2 == 0 | num_1 == 0)
                {
                    Clear();
                    TB_Display.Text = "ERROR";
                }
                else
                {
                    result = num_1 / num_2;
                }
            }
            else if (operation == '^')
            {
               
                result = Math.Pow(num_1, num_2);
            }

            operation = '0';

            if (num_2 != 0)
            {
                TB_Display.Text = result.ToString();
                num_1 = 0;
                num_2 = 0;
            }
           }


        public void Clear()
        {
            ClearText();
            num_1 = 0;
            num_2 = 0;
            operation = '0';
        }

        private Boolean HasVirgule()
        {
            char[] Chaine = TB_Display.Text.ToCharArray();
            foreach (char Character in Chaine)
            {
                if (Character == ',')
                {
                    return true;
                }
            }
            return false;
        }

        // Events Numéro
        private void BTN_Num_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Afficher(1,btn);
        }

        // Events Clear et Equal
        private void BTN_Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void BTN_Equal_Click(object sender, RoutedEventArgs e)
        {
            Equal();
        }
        // Events Operation 
        private void BTN_Operation_Click(object sender, RoutedEventArgs e)
        {
            Button Btn = sender as Button;
            char operation_ = char.Parse(Btn.Content.ToString());
            Save_operation(operation_);
        }

        private void BTN_Pi_Click(object sender, RoutedEventArgs e)
        {
            ClearText();
            Afficher(pi,null);
        }

        private void BTN_Sqrt_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text != "")
            {
                TB_Display.Text = Math.Sqrt(Double.Parse(TB_Display.Text)).ToString();
                num_1 = Double.Parse(TB_Display.Text);
            }
        }

        private void BTN_Log_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text != "")
            {
                TB_Display.Text = Math.Log10(Double.Parse(TB_Display.Text)).ToString();
                num_1 = Double.Parse(TB_Display.Text);
            }
        }

        private void BTN_Sin_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text != "")
            {
                TB_Display.Text = Math.Sin(Double.Parse(TB_Display.Text)).ToString();
                num_1 = Double.Parse(TB_Display.Text);
            }
        }

        private void BTN_Cos_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text != "")
            {
                TB_Display.Text = Math.Cos(Double.Parse(TB_Display.Text)).ToString();
                num_1 = Double.Parse(TB_Display.Text);
            }
        }

        private void BTN_Tan_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text != "")
            {
                TB_Display.Text = Math.Tan(Double.Parse(TB_Display.Text)).ToString();
                num_1 = Double.Parse(TB_Display.Text);
            }
        }

        private void BTN_Effacer_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text != "")
            {
                char[] Chaine = TB_Display.Text.ToCharArray();
                TB_Display.Text = new string(Chaine, 0, Chaine.Length - 1);
            }
        }

        private void BTN_Virgule_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text != "")
            {
                if (HasVirgule()!=true)
                {
                    AppendText(",");
                }
            }
        }
    }
}
