using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using WCFMemberServiceLibrary;

namespace WCFMemberServiceGUI
{
    public partial class Form1 : Form
    {
        internal static ServiceHost myServiceHost = null;

        bool isServiceStarted = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void startService()
        {
            Uri baseAddress = new Uri("http://localhost:8080/MemberService");

            myServiceHost = new ServiceHost(typeof(SampleService),baseAddress);
            myServiceHost.Open();
            isServiceStarted = true;
            serviceButton.Text = "Stop Service";
        }

        private void stopService()
        {
            if (myServiceHost.State != CommunicationState.Closed)
            {
                myServiceHost.Close();
                isServiceStarted = false;
                serviceButton.Text = "Start Service";
            }
        }

        private void serviceButton_Click(object sender, EventArgs e)
        {
            if (!isServiceStarted)
            {
                startService();
            }
            else
            {
                stopService();
            }
        }
    }
}