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
        public static string firstNumber = "0";
        public static string secondNumber = "";
        public static string answerNumber = "";
        public static string inputNumber = "";
        public static string lastOperator = "";
        public static bool isEqualPressed = false;

        public MainWindow()
        {
            
        }
        private void NumberButton_Click(object sender, RoutedEventArgs e)  //숫자 버튼 클릭
        {
            Button button = sender as Button;
            string number = button.Content.ToString();  // 현재 입력한 버튼 숫자
                                                        //MessageBox.Show($"{button.Name} 클릭 되었습니다.");

            if (inputNumber.Length == 0)
            {
                if (number == ".")
                {
                    inputNumber = "0";
                    inputNumber += number;
                    result.Text = inputNumber;
                }
                else
                {
                    inputNumber += number;
                    result.Text = inputNumber;

                }
            }
            else if (inputNumber == "0")
            {
                if (number == "0")
                {

                }
                else
                {
                    inputNumber = "";
                    inputNumber += number;
                    result.Text = inputNumber;
                }
            }
            else if (inputNumber.Length >= 16)
            {

            }
            else
            {
                inputNumber += number;
                result.Text = inputNumber;
            }

        }

        private void Operator_Click(object sender, RoutedEventArgs e)  //연산 버튼 클릭
        {
            Button button = sender as Button;
            string operator1 = button.Content.ToString();  // 현재 입력한 버튼 연산자


            if (inputNumber == "")
            {
                isEqualPressed = false;

                // 바로 연산자 누를 때
                if (lastOperator == "")
                {
                    secondNumber = firstNumber;
                    formula.Text = firstNumber + operator1;
                    result.Text = secondNumber;
                    lastOperator = operator1;
                }
                else
                {
                    secondNumber = firstNumber;
                    formula.Text = firstNumber + operator1;
                    result.Text = secondNumber;
                    lastOperator = operator1;
                }
            }
            // input 있을 때
            else
            {
                // 소수점으로 끝나는 경우. 소수점 제거
                if (inputNumber[inputNumber.Length - 1] == '.')
                { inputNumber = inputNumber.Substring(0, inputNumber.Length - 1); }

                // 숫자 입력 후, 연산자 입력
                if (lastOperator == "")
                {
                    firstNumber = inputNumber;
                    secondNumber = firstNumber;
                    formula.Text = firstNumber + operator1;
                    lastOperator = operator1;
                    result.Text = secondNumber;
                    // input 초기화시켜서 연산자 바꿔 입력하는 경우는 위에서 처리하도록
                    inputNumber = "";
                    isEqualPressed = false;

                }
                else
                {
                    if (isEqualPressed)
                    {
                        // = 한 이후에 새로운 값을 입력받는 경우
                        // 새 input은 첫번째에 넣고
                        firstNumber = inputNumber;
                        secondNumber = firstNumber;
                        formula.Text = firstNumber + operator1;
                        result.Text = secondNumber;
                        lastOperator = operator1;

                        // 초기화
                        inputNumber = "";
                        isEqualPressed = false;
                    }
                    else
                    {
                        // 아직 계산이 되지 않은 경우, 계산을 해줘야 함
                        // 새 input은 두번째에 넣고
                        secondNumber = inputNumber;

                        // 계산
                        double answer = Calculate();
                        answerNumber = answer.ToString();

                        // 계산값으로 초기화
                        firstNumber = answerNumber;
                        secondNumber = answerNumber;

                        formula.Text = firstNumber + operator1;
                        result.Text = secondNumber;
                        lastOperator = operator1;

                        inputNumber = "";
                    }
                }
            }
        }

        private void plus_minus_Click(object sender, RoutedEventArgs e)  //숫자 버튼 클릭
        {
            Button button = sender as Button;

            if (inputNumber == "")
            {
                if (lastOperator == "")
                {
                    firstNumber = Conversion(firstNumber);
                    formula.Text = firstNumber;
                    result.Text = firstNumber;

                }
                else
                {
                    if (isEqualPressed)
                    {
                        firstNumber = Conversion(answerNumber);
                        formula.Text = firstNumber;
                        result.Text = firstNumber;
                    }
                    else
                    {
                        secondNumber = Conversion(secondNumber);
                        formula.Text = firstNumber + lastOperator;
                        result.Text = secondNumber;
                    }
                }
            }
            else
            {
                if (lastOperator == "")
                {
                    inputNumber = Conversion(inputNumber);
                    result.Text = inputNumber;

                }
                else
                {
                    inputNumber = Conversion(inputNumber);
                    result.Text = inputNumber;

                }
            }
        }

        private void clearEntry_Click(object sender, RoutedEventArgs e)  //CE 버튼 클릭
        {
            Button button = sender as Button;

            if (isEqualPressed)
            {
                inputNumber = "0";
                result.Text = inputNumber;
                formula.Text = "";
            }
            else
            {
                inputNumber = "0";
                result.Text = inputNumber;
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)  //C 버튼 클릭
        {
            Button button = sender as Button;
            
            firstNumber = "0";
            secondNumber = "";
            answerNumber = "";
            inputNumber = "";
            lastOperator = "";
            isEqualPressed = false;

            formula.Text = "";
            result.Text = "0";
        }

        private void delete_Click(object sender, RoutedEventArgs e)  //숫자 버튼 클릭
        {
            Button button = sender as Button;

            if (inputNumber[0] == '-')
            {
                if (inputNumber.Length > 2)
                {
                    inputNumber = inputNumber.Substring(0, inputNumber.Length - 1);
                    result.Text = inputNumber;
                }
                else
                {
                    inputNumber = "0";
                    result.Text = inputNumber;
                }
            }
            else
            {
                if (inputNumber.Length > 1)
                {
                    inputNumber = inputNumber.Substring(0, inputNumber.Length - 1);
                    result.Text = inputNumber;
                }
                else
                {
                    inputNumber = "0";
                    result.Text = inputNumber;
                }
            }

            if (inputNumber == "")
            {
                result.Text = "0";
            }
        }

        private void equals_Click(object sender, RoutedEventArgs e)  //= 버튼 클릭
        {
            Button button = sender as Button;

            if (inputNumber == "")
            {
                // 바로 = 누를 때
                
                if (lastOperator == "")
                {
                    secondNumber = firstNumber;
                    formula.Text = firstNumber + "=";
                    result.Text = secondNumber;
                }
                // 연산자가 있을 때
                else
                {
                    // 계산
                    double answer = Calculate();
                    answerNumber = answer.ToString();

                    // 계산식 보여주기
                    formula.Text = firstNumber + lastOperator + secondNumber + "=";

                    // 첫번째 숫자만 계산값으로 초기화
                    firstNumber = answerNumber;

                    result.Text = answerNumber;

                    // = 했다는 걸 표시
                    isEqualPressed = true;
                }
            }
            // input 있을 때
            else
            {
                if (inputNumber[inputNumber.Length - 1] == '.')
                { inputNumber = inputNumber.Substring(0, inputNumber.Length - 1); }

                // 처음에 숫자 = 입력한 경우
                if (lastOperator == "")
                {
                    firstNumber = inputNumber;
                    secondNumber = firstNumber;
                    formula.Text = firstNumber + "=";
                    result.Text = secondNumber;
                    // input 초기화
                    inputNumber = "";

                }
                else
                {
                    // 계산 결과가 있는 경우
                    if (isEqualPressed)
                    {
                        // 기존 연산자와 두 번째 숫자로 계산을 해줘야 함
                        // 새 input은 첫번째에 넣고
                        firstNumber = inputNumber;

                        // 계산
                        double answer = Calculate();
                        answerNumber = answer.ToString();

                        // 계산식 보여주기
                        formula.Text = firstNumber + lastOperator + secondNumber + "=";

                        // 첫번째 숫자만 계산값으로 초기화
                        firstNumber = answerNumber;

                        result.Text = answerNumber;

                        inputNumber = "";

                        // = 했다는 걸 표시
                        isEqualPressed = true;
                    }
                    else
                    {
                        // 새 input은 두번째에 넣고
                        secondNumber = inputNumber;

                        // 계산
                        double answer = Calculate();
                        answerNumber = answer.ToString();

                        // 계산식 보여주기
                        formula.Text = firstNumber + lastOperator + secondNumber + "=";

                        // 첫번째 숫자만 계산값으로 초기화
                        firstNumber = answerNumber;

                        result.Text = answerNumber;

                        inputNumber = "";

                        // = 했다는 걸 표시
                        isEqualPressed = true;
                    }
                }
            }
        }

        private double Calculate()
        {
            switch (lastOperator)
            {
                case "+":
                    double answer = double.Parse(firstNumber) + double.Parse(secondNumber);
                    return answer;
                case "-":
                    answer = double.Parse(firstNumber) - double.Parse(secondNumber);
                    return answer;
                case "×":
                    answer = double.Parse(firstNumber) * double.Parse(secondNumber);
                    return answer;
                case "÷":
                    answer = double.Parse(firstNumber) / double.Parse(secondNumber);
                    return answer;
                default:
                    return 0;
            }
        }

        private string Conversion(string inputString)
        {
            if (inputString == "0" | inputString == "")
            {
                return inputString;
            }
            else if (inputString[0] == '-')
            {
                inputString = inputString.Substring(1);
                return inputString;

            }
            else
            {
                inputString = '-' + inputString;
                return inputString;

            }
        }
    }
}
