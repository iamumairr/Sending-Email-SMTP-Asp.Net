using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;
using System.Web.UI;

namespace SendingEmail
{
    public partial class Default : Page
    {
        private readonly string abc = WebConfigurationManager.ConnectionStrings["EmailsConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSendInformation_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(abc);
            try
            {
                // get the file name and extentension
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string ext = Path.GetExtension(FileUpload1.FileName);
                // start the connection to your database insert the data
                SqlCommand cmd = new SqlCommand("insert into Testing (Name,National_ID,Email,Phone,Description,Contents) values (@name,@nationalid,@email,@phone,@description,@content)", con);
                cmd.Parameters.AddWithValue("@name", TxtName.Text);
                cmd.Parameters.AddWithValue("@nationalid", TxtNationalID.Text);
                cmd.Parameters.AddWithValue("@email", TxtEmail.Text);
                cmd.Parameters.AddWithValue("@phone", TxtPhone.Text);
                cmd.Parameters.AddWithValue("@description", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@content", filename + ext);
                con.Open();
                cmd.ExecuteNonQuery();

                // create message object
                MailMessage msg = new MailMessage();
                // sender e-mail address
                msg.From = new MailAddress("Sender Email");
                // receiver e-mail address (the customer e-mail address)
                msg.To.Add(TxtEmail.Text);
                // A message to Administrator
              //  msg.To.Add("Administrator Email");

                // message subject
                msg.Subject = TxtSubject.Text;
                // the e-mail body
                msg.Body = TxtName.Text + "\n" + TxtNationalID.Text + "\n" + TxtEmail.Text + "\n" + TxtPhone.Text + "\n" + TxtDescription.Text;
                // attachment
                string path = Server.MapPath("~\\Folders\\");
                FileUpload1.SaveAs(path + FileUpload1.FileName);
                Attachment att = new Attachment(path + FileUpload1.FileName); ;
                msg.Attachments.Add(att);

                // create smtp object (host server and port)
                string server = "smtp.gmail.com";

                // the smtp client
                SmtpClient sc = new SmtpClient(server);
                sc.Port = 587;

                // smtp credentials "email,password"
                string Email = "Your Email";
                string Password = "Your Password";
                sc.UseDefaultCredentials = false;

                sc.Credentials = new NetworkCredential(Email, Password);

                // enabling SSL
                sc.EnableSsl = true;
                // sending the email
                sc.Send(msg);

                //Display message after successful submit
                TxtMessage.Text = "Data Submitted Successfully.";
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
