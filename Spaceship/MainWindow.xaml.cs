using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Spaceship
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer timer = new Timer(10000);

        public MainWindow()
        {
            InitializeComponent();
            timer.Elapsed += timer_Elapsed;
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MessageBox.Show("Timer Elapsed");
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            await Task.Run(() =>
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();

                // Configure the audio output. 
                synth.SetOutputToDefaultAudioDevice();

                synth.Speak("10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, Start.");
                // Speak a string.
                synth.Speak("Houston we have a problem.");

                synth.Speak("C# is the best programming language in the world.");
            });
        }
     }
}
