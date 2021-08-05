using System;
using System.Text;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace SendTwilloCall
{
    public partial class Form1 : Form
    {
        //Constant Registry Keys
        const string rt = "HKEY_CURRENT_USER";
        const string sk = "EncryptionKeys";
        const string kn = rt + "\\" + sk;

        public string accountSID = Microsoft.Win32.Registry.GetValue(kn, "AccountSid", null).ToString();
        public string authorizationToken = Microsoft.Win32.Registry.GetValue(kn, "AuthenticationToken", null).ToString();
        public string CallerIDNumber1 = Microsoft.Win32.Registry.GetValue(kn, "CallerIDNumber1", null).ToString(); //Phone Number 1
        public string CallerIDNumber2 = Microsoft.Win32.Registry.GetValue(kn, "CallerIDNumber2", null).ToString(); //Phone Number 2

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^([0-9]( |-)?)?(\\(?[0-9]{3}\\)?|[0-9]{3})( |-)?([0-9]{3}( |-)?[0-9]{4}|[a-zA-Z0-9]{7})$");

            if (rx.IsMatch(phoneNumber.Text))
            {
                DoSendTwillo(phoneNumber.Text);
            }
            else
            {
                MessageBox.Show("Enter a valid phone number.");
            }
        }

        public void DoSendTwillo(string telephone)
        {
            try
            {
                // Find your Account Sid and Auth Token at twilio.com/console
                TwilioClient.Init(Encoding.Unicode.GetString(Convert.FromBase64String(accountSID)),
                    Encoding.Unicode.GetString(Convert.FromBase64String(authorizationToken)));

                PhoneNumber toNum = new PhoneNumber("+1" + telephone);  //Telephone Number entered by user
                PhoneNumber fromNum;

                //using milliseconds as a random dial controller
                int randomSeconds = System.DateTime.Now.Millisecond;
                if (randomSeconds <= 500)
                {
                    fromNum = new PhoneNumber(Encoding.Unicode.GetString(Convert.FromBase64String(CallerIDNumber1)));
                }
                else
                {
                    fromNum = new PhoneNumber(Encoding.Unicode.GetString(Convert.FromBase64String(CallerIDNumber2)));
                }

                var call = CallResource.Create(toNum, fromNum, url: new Uri("https://handler.twilio.com/twiml/EH7d7a3dda567edf999c62ae994c79f98f"));

                //var call = CallResource.Create(toNum, "+14026717416", url: new Uri("https://handler.twilio.com/twiml/EH7d7a3dda567edf999c62ae994c79f98f"));

                textBox2.Visible = true; //unhide the textbox and show the results.
                textBox2.Text = "Call SID: " + call.Sid;  //display the results of the phone call.
                phoneNumber.Text = string.Empty;  //clear out on success

            }
            catch (Exception ex)
            {
                phoneNumber.Text = string.Empty;  //clear out on failure
                MessageBox.Show("There was an exception in the code: " + ex.Message);
            }
        }
    }
}