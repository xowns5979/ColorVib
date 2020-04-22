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
using System.IO.Ports;
using System.Threading;
using System.ComponentModel;

namespace WristSymbol
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker worker;
        System.IO.Ports.SerialPort serialPort1 = new SerialPort();

        int duration = 500;
        int modulateOnTime = 40;
        int modulateOffTime = 20;
        public void workBackground(String text)
        {
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync(argument: text);
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            String text = (String)e.Argument;
            patternGenerate(text);
        }

        public void patternGenerate(String text)
        {
            int n = text.Length;
            int i;
            for (i = 0; i < n; i++)
            {
                stimulation(Convert.ToInt32(text[i].ToString()));
            }
        }
        
        public void stimulation(int tactorNum)
        {
            serialPort1.WriteLine(tactorNum.ToString() + "v");
            Thread.Sleep(duration);
            serialPort1.WriteLine(tactorNum.ToString() + "s");
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            String[] ports = SerialPort.GetPortNames();
            ComboboxSerials.Items.Clear();

            for (int i = 0; i < ports.Length; i++)
            {
                ComboboxSerials.Items.Add(ports[i]);
            }
            if (ports.Length > 0)
            {
                ComboboxSerials.SelectedIndex = ComboboxSerials.Items.Count - 1;
                serialPort1.BaudRate = 115200;
                serialPort1.DtrEnable = true;
                serialPort1.RtsEnable = true;
            }
        }

        private void ButtonConnect_Click(object sender, RoutedEventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = (String)ComboboxSerials.Items[ComboboxSerials.SelectedIndex];
                serialPort1.Open();
                string line = serialPort1.ReadExisting();
                Console.WriteLine("Start");
            }
            else
            {
                serialPort1.Close();
            }
        }


        private void Pattern1_Click(object sender, RoutedEventArgs e)
        {
            string str = "1243";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: "+ currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
            
        }

        private void Pattern2_Click(object sender, RoutedEventArgs e)
        {
            string str = "1342";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern3_Click(object sender, RoutedEventArgs e)
        {
            string str = "1234";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern4_Click(object sender, RoutedEventArgs e)
        {
            string str = "2143";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern5_Click(object sender, RoutedEventArgs e)
        {
            string str = "134";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern6_Click(object sender, RoutedEventArgs e)
        {
            string str = "243";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern7_Click(object sender, RoutedEventArgs e)
        {
            string str = "132";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern8_Click(object sender, RoutedEventArgs e)
        {
            string str = "124";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern9_Click(object sender, RoutedEventArgs e)
        {
            string str = "312";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern10_Click(object sender, RoutedEventArgs e)
        {
            string str = "213";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern11_Click(object sender, RoutedEventArgs e)
        {
            string str = "234";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern12_Click(object sender, RoutedEventArgs e)
        {
            string str = "324";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern21_Click(object sender, RoutedEventArgs e)
        {
            string str = "12";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern22_Click(object sender, RoutedEventArgs e)
        {
            string str = "14";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern23_Click(object sender, RoutedEventArgs e)
        {
            string str = "13";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern24_Click(object sender, RoutedEventArgs e)
        {
            string str = "24";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern15_Click(object sender, RoutedEventArgs e)
        {
            string str = "31";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern16_Click(object sender, RoutedEventArgs e)
        {
            string str = "32";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern17_Click(object sender, RoutedEventArgs e)
        {
            string str = "34";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern13_Click(object sender, RoutedEventArgs e)
        {
            string str = "23";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern18_Click(object sender, RoutedEventArgs e)
        {
            string str = "43";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern19_Click(object sender, RoutedEventArgs e)
        {
            string str = "41";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern20_Click(object sender, RoutedEventArgs e)
        {
            string str = "42";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern14_Click(object sender, RoutedEventArgs e)
        {
            string str = "21";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern25_Click(object sender, RoutedEventArgs e)
        {
            string str = "1";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern26_Click(object sender, RoutedEventArgs e)
        {
            string str = "2";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern27_Click(object sender, RoutedEventArgs e)
        {
            string str = "3";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Pattern28_Click(object sender, RoutedEventArgs e)
        {
            string str = "4";
            if (patternAnswering)
            {
                if (currentAskingPattern == str)
                {
                    randomPlayAnswerLabel.Content = "O";
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    randomPlayAnswerLabel.Content = "X, 정답: " + currentAskingPattern;
                    randomPlayAnswerLabel.Visibility = Visibility.Visible;
                }
                patternAnswering = false;
            }
            else
            {
                patternGenerate(str);
            }
        }

        private void Motor1Fix_Click(object sender, RoutedEventArgs e)
        {
            string powerStr = "";
            string freqStr = "";
            string modulateOnTimeStr = "";
            string modulateOffTimeStr = "";

            int power = (int)motor1power.Value;
            if (power >= 100)
                powerStr = "1a" + power.ToString();
            else if (power >= 10)
                powerStr = "1a0" + power.ToString();
            else
                powerStr = "1a00" + power.ToString();

            int freq = (int)motor1frequency.Value;
            if (freq >= 100)
                freqStr = "1f" + freq.ToString();
            else if (freq >= 10)
                freqStr = "1f0" + freq.ToString();
            else
                freqStr = "1f00" + freq.ToString();

            if (modulateOnTime >= 100)
                modulateOnTimeStr = "1br" + modulateOnTime.ToString();
            else if (modulateOnTime >= 10)
                modulateOnTimeStr = "1br0" + modulateOnTime.ToString();
            else
                modulateOnTimeStr = "1br00" + modulateOnTime.ToString();

            if (modulateOffTime >= 100)
                modulateOffTimeStr = "1bs" + modulateOffTime.ToString();
            else if (modulateOffTime >= 10)
                modulateOffTimeStr = "1bs0" + modulateOffTime.ToString();
            else
                modulateOffTimeStr = "1bs00" + modulateOffTime.ToString();


            Boolean modulation = (bool)motor1Modulation.IsChecked;

            serialPort1.WriteLine(powerStr);
            serialPort1.WriteLine(freqStr);
            if (modulation)
            {
                serialPort1.WriteLine(modulateOnTimeStr);
                serialPort1.WriteLine(modulateOffTimeStr);
            }
            else
            {
                serialPort1.WriteLine("1bs000");
            }
        }

        private void Motor2Fix_Click(object sender, RoutedEventArgs e)
        {
            string powerStr = "";
            string freqStr = "";
            string modulateOnTimeStr = "";
            string modulateOffTimeStr = "";

            int power = (int)motor2power.Value;
            if (power >= 100)
                powerStr = "2a" + power.ToString();
            else if (power >= 10)
                powerStr = "2a0" + power.ToString();
            else
                powerStr = "2a00" + power.ToString();

            int freq = (int)motor2frequency.Value;
            if (freq >= 100)
                freqStr = "2f" + freq.ToString();
            else if (freq >= 10)
                freqStr = "2f0" + freq.ToString();
            else
                freqStr = "2f00" + freq.ToString();

            if (modulateOnTime >= 100)
                modulateOnTimeStr = "2br" + modulateOnTime.ToString();
            else if (modulateOnTime >= 10)
                modulateOnTimeStr = "2br0" + modulateOnTime.ToString();
            else
                modulateOnTimeStr = "2br00" + modulateOnTime.ToString();

            if (modulateOffTime >= 100)
                modulateOffTimeStr = "2bs" + modulateOffTime.ToString();
            else if (modulateOffTime >= 10)
                modulateOffTimeStr = "2bs0" + modulateOffTime.ToString();
            else
                modulateOffTimeStr = "2bs00" + modulateOffTime.ToString();


            Boolean modulation = (bool)motor2Modulation.IsChecked;

            serialPort1.WriteLine(powerStr);
            serialPort1.WriteLine(freqStr);
            if (modulation)
            {
                serialPort1.WriteLine(modulateOnTimeStr);
                serialPort1.WriteLine(modulateOffTimeStr);
            }
            else
            {
                serialPort1.WriteLine("2bs000");
            }
        }

        private void Motor3Fix_Click(object sender, RoutedEventArgs e)
        {
            string powerStr = "";
            string freqStr = "";
            string modulateOnTimeStr = "";
            string modulateOffTimeStr = "";

            int power = (int)motor3power.Value;
            if (power >= 100)
                powerStr = "3a" + power.ToString();
            else if (power >= 10)
                powerStr = "3a0" + power.ToString();
            else
                powerStr = "3a00" + power.ToString();

            int freq = (int)motor3frequency.Value;
            if (freq >= 100)
                freqStr = "3f" + freq.ToString();
            else if (freq >= 10)
                freqStr = "3f0" + freq.ToString();
            else
                freqStr = "3f00" + freq.ToString();

            if (modulateOnTime >= 100)
                modulateOnTimeStr = "3br" + modulateOnTime.ToString();
            else if (modulateOnTime >= 10)
                modulateOnTimeStr = "3br0" + modulateOnTime.ToString();
            else
                modulateOnTimeStr = "3br00" + modulateOnTime.ToString();

            if (modulateOffTime >= 100)
                modulateOffTimeStr = "3bs" + modulateOffTime.ToString();
            else if (modulateOffTime >= 10)
                modulateOffTimeStr = "3bs0" + modulateOffTime.ToString();
            else
                modulateOffTimeStr = "3bs00" + modulateOffTime.ToString();


            Boolean modulation = (bool)motor3Modulation.IsChecked;

            serialPort1.WriteLine(powerStr);
            serialPort1.WriteLine(freqStr);
            if (modulation)
            {
                serialPort1.WriteLine(modulateOnTimeStr);
                serialPort1.WriteLine(modulateOffTimeStr);
            }
            else
            {
                serialPort1.WriteLine("3bs000");
            }
        }

        private void Motor4Fix_Click(object sender, RoutedEventArgs e)
        {
            string powerStr = "";
            string freqStr = "";
            string modulateOnTimeStr = "";
            string modulateOffTimeStr = "";

            int power = (int)motor4power.Value;
            if (power >= 100)
                powerStr = "4a" + power.ToString();
            else if (power >= 10)
                powerStr = "4a0" + power.ToString();
            else
                powerStr = "4a00" + power.ToString();

            int freq = (int)motor4frequency.Value;
            if (freq >= 100)
                freqStr = "4f" + freq.ToString();
            else if (freq >= 10)
                freqStr = "4f0" + freq.ToString();
            else
                freqStr = "4f00" + freq.ToString();

            if (modulateOnTime >= 100)
                modulateOnTimeStr = "4br" + modulateOnTime.ToString();
            else if (modulateOnTime >= 10)
                modulateOnTimeStr = "4br0" + modulateOnTime.ToString();
            else
                modulateOnTimeStr = "4br00" + modulateOnTime.ToString();

            if (modulateOffTime >= 100)
                modulateOffTimeStr = "4bs" + modulateOffTime.ToString();
            else if (modulateOffTime >= 10)
                modulateOffTimeStr = "4bs0" + modulateOffTime.ToString();
            else
                modulateOffTimeStr = "4bs00" + modulateOffTime.ToString();


            Boolean modulation = (bool)motor4Modulation.IsChecked;

            serialPort1.WriteLine(powerStr);
            serialPort1.WriteLine(freqStr);
            if (modulation)
            {
                serialPort1.WriteLine(modulateOnTimeStr);
                serialPort1.WriteLine(modulateOffTimeStr);
            }
            else
            {
                serialPort1.WriteLine("4bs000");
            }
        }

        private void vibDurationFix_Click(object sender, RoutedEventArgs e)
        {
            duration = (int)vibDuration.Value;
        }

        private void modulationOnTimeFix_Click(object sender, RoutedEventArgs e)
        {
            modulateOnTime = (int)modulationOnTime.Value;
            string modulateOnTimeStr = "";
            string modulateOffTimeStr = "";

            int i;
            for (i = 0; i < 4; i++)
            {
                CheckBox[] modulations = { motor1Modulation, motor2Modulation, motor3Modulation, motor4Modulation };
                if (modulateOnTime >= 100)
                    modulateOnTimeStr = (i+1).ToString() + "br" + modulateOnTime.ToString();
                else if (modulateOnTime >= 10)
                    modulateOnTimeStr = (i + 1).ToString() + "br0" + modulateOnTime.ToString();
                else
                    modulateOnTimeStr = (i + 1).ToString() + "br00" + modulateOnTime.ToString();

                if (modulateOffTime >= 100)
                    modulateOffTimeStr = (i + 1).ToString() + "bs" + modulateOffTime.ToString();
                else if (modulateOffTime >= 10)
                    modulateOffTimeStr = (i + 1).ToString() + "bs0" + modulateOffTime.ToString();
                else
                    modulateOffTimeStr = (i + 1).ToString() + "bs00" + modulateOffTime.ToString();

                Boolean modulation = (bool)modulations[i].IsChecked;
                if (modulation)
                {
                    serialPort1.WriteLine(modulateOnTimeStr);
                    serialPort1.WriteLine(modulateOffTimeStr);
                }
                else
                {
                    serialPort1.WriteLine((i + 1).ToString() + "bs000");
                }
            }
            
        }

        private void modulationOffTimeFix_Click(object sender, RoutedEventArgs e)
        {
            modulateOffTime = (int)modulationOffTime.Value;
            string modulateOnTimeStr = "";
            string modulateOffTimeStr = "";

            int i;
            for (i = 0; i < 4; i++)
            {
                CheckBox[] modulations = { motor1Modulation, motor2Modulation, motor3Modulation, motor4Modulation };
                if (modulateOnTime >= 100)
                    modulateOnTimeStr = (i + 1).ToString() + "br" + modulateOnTime.ToString();
                else if (modulateOnTime >= 10)
                    modulateOnTimeStr = (i + 1).ToString() + "br0" + modulateOnTime.ToString();
                else
                    modulateOnTimeStr = (i + 1).ToString() + "br00" + modulateOnTime.ToString();

                if (modulateOffTime >= 100)
                    modulateOffTimeStr = (i + 1).ToString() + "bs" + modulateOffTime.ToString();
                else if (modulateOffTime >= 10)
                    modulateOffTimeStr = (i + 1).ToString() + "bs0" + modulateOffTime.ToString();
                else
                    modulateOffTimeStr = (i + 1).ToString() + "bs00" + modulateOffTime.ToString();

                Boolean modulation = (bool)modulations[i].IsChecked;
                if (modulation)
                {
                    serialPort1.WriteLine(modulateOnTimeStr);
                    serialPort1.WriteLine(modulateOffTimeStr);
                }
                else
                {
                    serialPort1.WriteLine((i + 1).ToString() + "bs000");
                }
            }
        }
        String[] patternSet = { "1243", "1342", "1234", "2143",
                                "134", "243", "132", "124", "312", "213", "234", "324",
                                "12", "13", "14", "21", "23", "24", "31", "32", "34", "41", "42", "43",
                                "1", "2", "3", "4"};
        String currentAskingPattern = "";
        bool patternAnswering = false;
        private void randomPlay_Click(object sender, RoutedEventArgs e)
        {
            if(!patternAnswering)
            {
                randomPlayAnswerLabel.Visibility = Visibility.Hidden;

                Random rnd = new Random();
                patternSet = patternSet.OrderBy(x => rnd.Next()).ToArray();

                currentAskingPattern = patternSet[0];
                patternGenerate(patternSet[0]);
                patternAnswering = true;

            }
            
        }
    }
}
