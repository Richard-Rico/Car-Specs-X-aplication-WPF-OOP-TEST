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
using System.Speech.Synthesis;

namespace WpfAutoOlio2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Car volvo = new Car(); //luodaan Car-tyyppinen olio, jonka nimi on "volvo"
        Car ford = new Car(); //luodaan Car-tyyppinen olio, jonka nimi on "ford"
        string EngineType;

        public MainWindow()
        {
            InitializeComponent(); //ComboBox
            txtColor.Focus();
            cbTransMission.Items.Add("Manual");
            cbTransMission.Items.Add("Automatic");
            cbTransMission.Items.Add("Robotic");
            cbTransMission2.ItemsSource = cbTransMission.Items;
        }
        private void btnAuto1_Click(object sender, RoutedEventArgs e)
        {
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("wellcome to car specs x");

            Boolean ok = true;
            //kun käyttäjä klikkaa tätä buttonia, asetetaan oliolle nämä arviot ominaisuuksiin
            volvo.Color = txtColor.Text;
            volvo.Model = txtModel.Text;

            try
            {
                volvo.MaxSpeed = int.Parse(txtMaxSpeed.Text);
            }
            catch (Exception)
            {

                lblMaxSpeedInfo.Content = "*** The value of the max.speed must be between (1 - 400)km/h!";
                txtMaxSpeed.Text = "";
                txtMaxSpeed.Focus();
                ok = false;
            }

            try
            {
                volvo.HorsePower = int.Parse(txtHorsePower.Text);
            }
            catch (Exception)
            {

                lblHorsePowerInfo.Content = "*** The value of the HorsePower must be between (1 -1800)!";
                txtHorsePower.Text = "";
                txtHorsePower.Focus();
                ok = false;
            }

            
            volvo.TransMission = cbTransMission.Text;
            volvo.EngineType = EngineType;

            if (ok) 
            {
                ClearTextBoxes();
                SetRadioButtonsOff();
            }

            
        }

        public void ShowCarInfo(Car auto) // Tämä rutiini listaa parametrinä saadun olion arvot
        {
            string message = "Model: " + auto.Model + "\n" +
                "Color: " + auto.Color + "\n" +
                "MaxSpeed: " + auto.MaxSpeed + "\n" +
                "HorsePower: " + auto.HorsePower + "\n" +
                "Transmission: " + auto.TransMission + "\n" +
                "EngineType: " + auto.EngineType + "\n" +
                "Engine running: " + auto.Running;


            MessageBox.Show(message);
        }

        private void btnAuto1Info_Click(object sender, RoutedEventArgs e)
        {
            ShowCarInfo(volvo);
        }

        private void btnAuto2_Click(object sender, RoutedEventArgs e)
        {
            Boolean ok = true;
            ford.Color = txtColor.Text;
            ford.Model = txtModel.Text;

            try
            {
                ford.MaxSpeed = int.Parse(txtMaxSpeed.Text);
            }
            catch (Exception)
            {

                lblMaxSpeedInfo.Content = "*** The max.speed may not exceed 400 km/h!";
                txtMaxSpeed.Text = "";
                txtMaxSpeed.Focus();
                ok = false;
            }

            try
            {
                ford.HorsePower = int.Parse(txtHorsePower.Text);
            }
            catch (Exception)
            {

                lblHorsePowerInfo.Content = "*** The value of the HorsePower must be between (1 -1800)!";
                txtHorsePower.Text = "";
                txtHorsePower.Focus();
                ok = false;
            }

            
            ford.TransMission = cbTransMission2.Text;
            ford.EngineType = EngineType;

            if (ok)
            {
                ClearTextBoxes();
                SetRadioButtonsOff();
            }
        }

        private void btnAuto2Info_Click(object sender, RoutedEventArgs e)
        {
            ShowCarInfo(ford);
        }

        private void btnStar_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnStar) 
            {
                volvo.StarEngine();
                if (volvo.Running == true)
                {
                    btnIndicator.Background = Brushes.PaleGreen;
                }
            } else if (sender == btnStar2)
            {
                ford.StarEngine();
                if (ford.Running == true)
                {
                    btnIndicator2.Background = Brushes.PaleGreen;
                }
            }
            
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnStop)
            {
                volvo.StopEngine();
                if (volvo.Running == false)
                {
                    btnIndicator.Background = Brushes.Yellow;
                }
            } else if (sender == btnStop2)
            {
                ford.StopEngine();
                if (ford.Running == false)
                {
                    btnIndicator2.Background = Brushes.Yellow;
                }
            }
            
        }

        private void EngineButtons_Checked(object sender, RoutedEventArgs e)
        {
            var Button = sender as RadioButton;

            EngineType = Button.Content.ToString();
        }

        private void btnAccelerate_Click(object sender, RoutedEventArgs e)
        {
            if (volvo.CurrentSpeed < volvo.MaxSpeed) 
            {
                volvo.Accelerate();
            }
            txtCurrentSpeed.Text = volvo.CurrentSpeed.ToString();
        }

        private void btnBrake_Click(object sender, RoutedEventArgs e)
        {
            if (volvo.CurrentSpeed > 0)
            {
                volvo.Brake();
            }
            txtCurrentSpeed.Text = volvo.CurrentSpeed.ToString();

        }
        private void btnAccelerate2_Click(object sender, RoutedEventArgs e)
        {
            if (ford.CurrentSpeed < ford.MaxSpeed)
            {
                ford.Accelerate();
            }
            txtCurrentSpeed2.Text = ford.CurrentSpeed.ToString();
        }

        private void btnBrake2_Click(object sender, RoutedEventArgs e)
        {
            if (ford.CurrentSpeed > 0)
            {
                ford.Brake();
            }
            txtCurrentSpeed2.Text = ford.CurrentSpeed.ToString();

        }

        //alirutiinit
        private void ClearTextBoxes()
        {
            txtColor.Text = "";
            txtModel.Text = "";
            txtMaxSpeed.Text = "";
            lblMaxSpeedInfo.Content = "";
            lblHorsePowerInfo.Content = "";
            txtHorsePower.Text = "";
            txtCurrentSpeed.Text = "0";
            txtCurrentSpeed2.Text = "0";
        }
        private void SetRadioButtonsOff()
        {
            rbDiesel.IsChecked = false;
            rbGasoline.IsChecked = false;
            rbElectric.IsChecked = false;
        }
    }
}
