using MyNotepad.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
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

namespace MyNotepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyModel model = new MyModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = model;
        }

        private void Bold_Checked(object sender, RoutedEventArgs e)
        {
            textBox1.FontWeight = FontWeights.Bold;
        }

        private void Bold_Unchecked(object sender, RoutedEventArgs e)
        {
            textBox1.FontWeight = FontWeights.Normal;
        }

        private void Italic_Checked(object sender, RoutedEventArgs e)
        {
            textBox1.FontStyle = FontStyles.Italic;
        }

        private void Italic_Unchecked(object sender, RoutedEventArgs e)
        {
            textBox1.FontStyle = FontStyles.Normal;
        }

        private void IncreaseFont_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.FontSize < 18)
            {
                textBox1.FontSize += 2;
            }
        }

        private void DecreaseFont_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.FontSize > 10)
            {
                textBox1.FontSize -= 2;
            }
        }

        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            model = new MyModel();
            DataContext = model;
        }

        private void NewCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //setIP(new string[] {"192.168.1.100"}, new string[] {"255.255.255.0"}, new string[] {"192.168.1.100"});

            //DataClasses1DataContext dc = new DataClasses1DataContext();
            //// Create the query. 
            //// lowNums is an IEnumerable<int> 
            //var lowNums = from word in dc.MyTables
            //              where word.Id > 0
            //              select word;

            //foreach (var item in lowNums)
            //{
            //    MessageBox.Show(item.Name);
            //}

            //Service1Client service1Client = new Service1Client();
            //string s = service1Client.GetData(10);
            //MessageBox.Show(s);

            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".mnp"; // Default file extension
            dlg.Filter = "MyNotepad documents (.mnp)|*.mnp"; // Filter files by extension 

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // open document 
                string filename = dlg.FileName;

                System.Xml.Serialization.XmlSerializer reader =
                    new System.Xml.Serialization.XmlSerializer(typeof(MyModel));
                System.IO.StreamReader file = new System.IO.StreamReader(filename);
                model = (MyModel)reader.Deserialize(file);
                DataContext = model;
            }
        }

        //public void setIP(string[] IPAddress, string[] SubnetMask, string[] Gateway)
        //{

        //    ManagementClass objMC = new ManagementClass(
        //        "Win32_NetworkAdapterConfiguration");
        //    ManagementObjectCollection objMOC = objMC.GetInstances();


        //    foreach (ManagementObject objMO in objMOC)
        //    {

        //        if (!(bool)objMO["IPEnabled"])
        //            continue;



        //        try
        //        {
        //            ManagementBaseObject objNewIP = null;
        //            ManagementBaseObject objSetIP = null;
        //            ManagementBaseObject objNewGate = null;


        //            objNewIP = objMO.GetMethodParameters("EnableStatic");
        //            objNewGate = objMO.GetMethodParameters("SetGateways");



        //            //Set DefaultGateway

        //            objNewGate["DefaultIPGateway"] = Gateway;
        //            objNewGate["GatewayCostMetric"] = new int[] { 1 };


        //            //Set IPAddress and Subnet Mask

        //            objNewIP["IPAddress"] = IPAddress;
        //            objNewIP["SubnetMask"] = SubnetMask;

        //            objSetIP = objMO.InvokeMethod("EnableStatic", objNewIP, null);
        //            objSetIP = objMO.InvokeMethod("SetGateways", objNewGate, null);



        //            MessageBox.Show(
        //               "Updated IPAddress, SubnetMask and Default Gateway!");



        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Unable to Set IP : " + ex.Message);
        //        }
        //    }
        //}

        private void OpenCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Focus();

            // Configure save file dialog box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "MyNotepad"; // Default file name
            dlg.DefaultExt = ".mnp"; // Default file extension
            dlg.Filter = "MyNotepad documents (.mnp)|*.mnp"; // Filter files by extension 

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results 
            if (result == true)
            {
                // Save document 
                string filename = dlg.FileName;
                System.Xml.Serialization.XmlSerializer writer =
                    new System.Xml.Serialization.XmlSerializer(typeof(MyModel));
                System.IO.StreamWriter file = new System.IO.StreamWriter(filename);
                writer.Serialize(file, model);
                file.Close();
            }
        }

        private void SaveCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
