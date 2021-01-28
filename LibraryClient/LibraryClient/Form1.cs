using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using LibraryClient.ServiceReference1;

namespace LibraryClient
{
    public partial class Form1 : Form
    {
        ServiceReference1.Service1Client client;
        string uid = null;
        public Form1()
        {
            InitializeComponent();
            client = new Service1Client();
            ConnectionTest();
            booksGridView.Columns.Add("id", "ID of the book (Code)");
            booksGridView.Columns.Add("name", "Name of the book");
            booksGridView.Columns.Add("author", "Author of the book");
            booksGridView.Columns.Add("price", "Price of the book in HUF");
            ListingBooks();
        }

        private async void ConnectionTest()
        {
            try
            {
                ServiceData objServiceData = client.TestConnection(@"Data Source=DESKTOP-3VFHRDD;Initial Catalog=bookstore;Integrated Security=True;");
                if (objServiceData.Result == true)
                    label1.Text = "Connection Successful";
            }
            catch (FaultException<ServiceData> Fex)
            {
                Console.WriteLine("Database Is Paused");
                label1.Text = "Connection Failed, Error Message: ";
                MessageBox.Show("Connection Failed, Error Message: " + Fex.Detail.ErrorMessage);
                await Task.Delay(1000);
                Application.Exit();
            }
            catch (Exception)
            {
                MessageBox.Show("SERVER IS OFFLINE");
                await Task.Delay(1000);
                Application.Exit();
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                uid = client.login(UsertextBox.Text, PasswordtextBox.Text);
                if (uid != null)
                {
                    label1.Text = "Login OK";
                    Logout.Enabled = true;
                    Login.Enabled = false;
                }
                else
                    label1.Text = "Login Failed: Wrong Username or Password";
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Connection has been lost with the server.");
            }
            catch (Exception)
            {
                MessageBox.Show("Communication Issues");
            }
        }



        private void Listing_Click(object sender, EventArgs e)
        {
            ListingBooks();

            Buy.Enabled = true;
            CreateSale.Enabled = true;
        }

        private void ListingBooks()
        {
            try
            {
                List<Book> result = new List<Book>();
                result = client.List().ToList<Book>();
                //label1.Text = result[0].Code;
                booksGridView.Rows.Clear();
                booksGridView.Refresh();
                foreach (Book item in result)
                {
                    booksGridView.Rows.Add(item.Id, item.Name, item.Author, item.Curr_price);
                }
            }
            catch(EndpointNotFoundException)
            {
                MessageBox.Show("Connection has been lost with the server.");
            }
            catch(Exception)
            {
                MessageBox.Show("Communication Issues");
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceData result = client.Add(NametextBox1.Text, AuthortextBox1.Text, CodetextBox2.Text, int.Parse(PricetextBox3.Text), uid);
                label1.Text = result.ErrorMessage;
                ListingBooks(); // Frissítsük a táblát
            }
            catch (FaultException<ServiceData> Fex)
            {
                label1.Text = Fex.Detail.ErrorMessage;
                MessageBox.Show("Adding Failed, Error Message: " + Fex.Detail.ErrorMessage);
            }
            catch (FormatException FrmtEx)
            {
                MessageBox.Show("Code and Price can only be numbers");
                label1.Text = FrmtEx.Message;
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Connection has been lost with the server.");
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
        }

        private async void Bye_Click(object sender, EventArgs e)
        {
            try
            {


                label1.Text = client.bye();
                await Task.Delay(1000);
                Application.Exit();
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Connection has been lost with the server.");
            }
            catch (Exception)
            {
                MessageBox.Show("Communication Issues");
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            try
            {


                client.logout(uid);
                uid = null;
                label1.Text = "Logout OK";
                Logout.Enabled = false;
                Login.Enabled = true;
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Connection has been lost with the server.");
            }
            catch (Exception)
            {
                MessageBox.Show("Communication Issues");
            }
        }

        private void Buy_Click(object sender, EventArgs e)
        {
            try
            {
                booksGridView.Rows[booksGridView.SelectedCells[0].RowIndex].Selected = true;
                if (booksGridView.SelectedRows[0].Cells[0].Value!=null)
                {
                    string code = booksGridView.SelectedRows[0].Cells[0].Value.ToString();
                    string result = client.Buy(code, uid);
                    label1.Text = result;
                    MessageBox.Show(result);
                }
                else
                {
                    label1.Text = "No book selected";
                }
                ListingBooks();
            }
            catch(NullReferenceException NullEx)
            {
                MessageBox.Show("No book in the database");
                label1.Text = NullEx.Message;
            }
            catch (ArgumentOutOfRangeException Ex)
            {
                MessageBox.Show("No book selected");
                label1.Text = Ex.Message;
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Connection has been lost with the server.");
            }
            catch (Exception)
            {
                MessageBox.Show("Communication Issues");
            }
        }

        private void CreateSale_Click(object sender, EventArgs e)
        {
            try
            {
                string result = client.CreateSale(uid);
                ListingBooks();
                label1.Text = result;
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Connection has been lost with the server.");
            }
            catch (Exception)
            {
                MessageBox.Show("Communication Issues");
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceData result = client.AddUser(Register_Username.Text, Register_Password.Text);
                label1.Text = result.ErrorMessage;
            }
            catch (FaultException<ServiceData> Fex)
            {
                label1.Text = Fex.Detail.ErrorMessage;
                MessageBox.Show("Registration Failed, Error Message: " + Fex.Detail.ErrorMessage);
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
        }
    }
}
