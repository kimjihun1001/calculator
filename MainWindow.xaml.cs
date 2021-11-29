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

namespace calculator
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        public static string lastNumber = null;
        public static string lastOperator = null;

        public MainWindow()
        {
            
        }
        private void NumberButton_Click(object sender, RoutedEventArgs e)  //숫자 버튼 클릭
        {
            Button button = sender as Button;
            string number = button.Content.ToString();  // 현재 입력한 버튼 숫자
                                                        //MessageBox.Show($"{button.Name} 클릭 되었습니다.");

            lastNumber += number;
            input.Text += number;

        }

        private void Operator_Click(object sender, RoutedEventArgs e)  //숫자 버튼 클릭
        {
            Button button = sender as Button;
            string number = button.Content.ToString();  // 현재 입력한 버튼 숫자

            input.Text += number;

        }

        private void plus_minus_Click(object sender, RoutedEventArgs e)  //숫자 버튼 클릭
        {
            Button button = sender as Button;
            string number = button.Content.ToString();  // 현재 입력한 버튼 숫자
                                                        //MessageBox.Show($"{button.Name} 클릭 되었습니다.");

            input.Text += number;

        }

        private void clearEntry_Click(object sender, RoutedEventArgs e)  //숫자 버튼 클릭
        {
            Button button = sender as Button;
            string number = button.Content.ToString();  // 현재 입력한 버튼 숫자

            input.Text += number;

        }

        private void clear_Click(object sender, RoutedEventArgs e)  //숫자 버튼 클릭
        {
            Button button = sender as Button;
            string number = button.Content.ToString();  // 현재 입력한 버튼 숫자

            input.Text += number;

        }

        private void delete_Click(object sender, RoutedEventArgs e)  //숫자 버튼 클릭
        {
            Button button = sender as Button;
            string number = button.Content.ToString();  // 현재 입력한 버튼 숫자

            input.Text += number;

        }

        private void delete_Click(object sender, RoutedEventArgs e)  //숫자 버튼 클릭
        {
            Button button = sender as Button;
            string number = button.Content.ToString();  // 현재 입력한 버튼 숫자

            input.Text += number;

        }
    }
}
