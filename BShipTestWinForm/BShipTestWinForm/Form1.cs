using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BShipLogic;
using System.ServiceModel;
using System.Net;
using System.ServiceModel.Description;

namespace BShipTestWinForm
{
    public partial class Form1 : Form
    {
        int indx,arrayCnt = 0;
        int [] depPoints;
        GameController gm;

        //variables for WCF hosting
        private ServiceHost host = null;
        private string urlMeta, urlService = "";

        public GameController GM
        {
            get 
            {
                if (gm == null)
                {
                    gm = new GameController();
                }
                return gm; 
            }
            
        }

        public Form1()
        {
            InitializeComponent();
            depPoints = new int[10];
        }

        #region Buttons...
        private void button1_Click(object sender, EventArgs e)
        {
            AddToArray((Button)sender);
            arrayCnt++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddToArray((Button)sender);
            arrayCnt++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddToArray((Button)sender);
            arrayCnt++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddToArray((Button)sender);
            arrayCnt++;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddToArray((Button)sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddToArray((Button)sender);
            arrayCnt++;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddToArray((Button)sender);
            arrayCnt++;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddToArray((Button)sender);
            arrayCnt++;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddToArray((Button)sender);
            arrayCnt++;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddToArray((Button)sender);
            arrayCnt++;
        }
#endregion

        private void AddToArray(Button btn)
        {
            try
            {
                int tmpVal = int.Parse(btn.Text) -1;
                depPoints[indx++] = tmpVal;
            }
            catch (IndexOutOfRangeException) { }
        }

        private void DeployShip()
        {
            GM.DeployShips(depPoints, Ships.Sub);
        }

        private void btnDepShips_Click(object sender, EventArgs e)
        {
            DeployShip();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            int hitNo = int.Parse(textBox1.Text);
            GM.CheckHits(hitNo);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            SendWcfRequest(int.Parse(textBox1.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartService();
        }

        private void StartService()
        {
            try
            {
                //Address
                string hostName = Dns.GetHostName();
                urlService = "net.tcp://" + hostName.ToString() + ":8000/MyService";
                host = new ServiceHost(typeof(BShipServiceLib.BShipServiceClass));

                NetTcpBinding tcpBinding = new NetTcpBinding();
                tcpBinding.TransactionFlow = false;
                tcpBinding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
                tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
                tcpBinding.Security.Mode = SecurityMode.None; // <- Very crucial

                //Binding - add endpoint
                host.AddServiceEndpoint(typeof(BShipServiceLib.IBShipService), tcpBinding, urlService);

                //Channel
                ServiceMetadataBehavior metadataBehavior;
                metadataBehavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (metadataBehavior == null)
                {
                    //Gonna remove the app.config file by doing this, enabling meta data
                    metadataBehavior = new ServiceMetadataBehavior();
                    metadataBehavior.HttpGetUrl = new Uri("http://" + hostName.ToString() + ":8001/MyService");
                    metadataBehavior.HttpGetEnabled = true;
                    metadataBehavior.ToString();
                    host.Description.Behaviors.Add(metadataBehavior);
                    urlMeta = metadataBehavior.HttpGetUrl.ToString();
                }

                host.Open();
            }
            catch (Exception ex) { }
        }


        private static void SendWcfRequest(int hutNo)
        {
            try
            {
                string serverName = "rakplk1";
                //string resultFilesLoc = System.Configuration.ConfigurationManager.AppSettings["ResultsFileLocation"];
                string errorString = string.Empty;

                //Config the address - A
                //machine name must be taken from a config file
                string endPointAddr = "net.tcp://" + serverName + ":57070/MyService";
                EndpointAddress endpointAddress = new EndpointAddress(endPointAddr);

                //Config the TCP binding settings - B
                NetTcpBinding tcpBinding = new NetTcpBinding();
                tcpBinding.TransactionFlow = false;
                //If this is not working reduce the protection level to none, but riskful - rakplk
                tcpBinding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
                tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
                tcpBinding.Security.Mode = SecurityMode.None;

                //Create the proxy to access the service calls - going with ABC concept
                IBShipService proxy = ChannelFactory<IBShipService>.CreateChannel(tcpBinding, endpointAddress);

                using (proxy as IDisposable)
                {
                    //Machine name must be programatically sent
                    proxy.RecieveAttack(hutNo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ReadKey();
            }
        }

      
    }
}
