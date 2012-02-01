using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using System.Collections;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using BShipTestWinForm;


namespace BShipTestWinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //IChannel tcpChannel;
            //BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
            //provider.TypeFilterLevel = TypeFilterLevel.Full;
            //IDictionary props = new Hashtable();
            //props["port"] = 8082;
            //try
            //{
            //    tcpChannel = new TcpChannel(props, null, provider);
            //    ChannelServices.RegisterChannel(tcpChannel, false);
            //    RemotingConfiguration.RegisterActivatedServiceType(typeof(Referee));
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("The following error occured while initiating the server\n" + ex.Message);
            //}
            //RemotingConfiguration.RegisterActivatedClientType(typeof(BShipTestWinForm.Referee), "tcp://localhost:8081/Referee");//, "tcp://localhost:8081/WarehouseDataServer");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
