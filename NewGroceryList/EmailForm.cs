using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using NewGroceryList.Properties;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewGroceryList
{
    public partial class EmailForm : Form
    {
        private static DataTable data;
        public bool EmailSuccessfullySent;
        public EmailForm(DataTable table)
        {
            InitializeComponent();
            data = table;
            this.EmailSuccessfullySent = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.EmailSuccessfullySent = SendEmail(textBox1.Text);
            }
            catch (Exception ex)
            {
                this.EmailSuccessfullySent = false;
                MessageBox.Show("error sending email: " + ex.Message);
            }
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal static bool SendEmail(string pTo)
        {
            try
            {
                // create email message
                decimal total = 0;

                //environment variables
                var param1 = Environment.GetEnvironmentVariable("GroceryEmailPassword");
                var param2 = Environment.GetEnvironmentVariable("GroceryApiEmail");

                var password = Encoding.Unicode.GetString(Convert.FromBase64String(Environment.GetEnvironmentVariable("GroceryEmailPassword")));
                var fromEmail = Encoding.Unicode.GetString(Convert.FromBase64String(Environment.GetEnvironmentVariable("GroceryApiEmail")));
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(fromEmail);
                email.To.Add(MailboxAddress.Parse(pTo));
                email.Subject = "Grocery List";

                var messageBody = Resources.EmailHtml;

                foreach (DataRow row in data.Rows)
                {
                    decimal.TryParse(row["ItemPrice"].ToString(), out decimal price);

                    //put this in a for loop to make the body table {0},{1},{2:$C},{3}
                    messageBody += string.Format(
                      @"<tr>
                            <td>{0}</td>
                            <td>{1}</td>
                            <td>{2:$C}</td>
                            <td>{3}</td>
                      </tr>",
                      row["ItemQuantity"].ToString(),
                      row["ItemName"].ToString(),
                      price.ToString("$#.00"),
                      row["IsTaxable"].ToString());

                    total += price;
                }
                messageBody += @"</table><br /><br />"; //end of the table

                //final total
                messageBody += $"<h1>Grand Total (minus taxes if applicable): {total.ToString("$#.00")}";

                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = messageBody
                };

                // send email
                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    smtp.Authenticate(fromEmail, password);
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
