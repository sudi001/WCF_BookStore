using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Data;

namespace LibraryWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public static List<Book> Products = new List<Book>();
        public static List<User> Users = new List<User>();
        static Dictionary<string, string> logged = new Dictionary<string, string>();
        string strConnectionString = "Data Source=DESKTOP-3VFHRDD;Initial Catalog=bookstore;Integrated Security=True;";

        public ServiceData TestConnection(string ConnectionString)
        {
            ServiceData myServiceData = new ServiceData();
            try
            {
                SqlConnection objConnection = new SqlConnection();
                objConnection.ConnectionString = strConnectionString;
                objConnection.Open();
                myServiceData.Result = true;

                initUsersTable(objConnection);  //Userek betöltése

                objConnection.Close();
                return myServiceData;
            }
            catch(SqlException sqlEx)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "Nem tudok csatlakozni az adatbázishoz";
                myServiceData.ErrorDetails = sqlEx.ToString();
                throw new FaultException<ServiceData>(myServiceData, sqlEx.ToString()); // A DEBUGGER EL FOGJA KAPNI EZT IS, LEÁLL HOGYHA VS-BŐL VAN INDÍTVA
            }
            catch(Exception e)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "Nem tudok csatlakozni az adatbázishoz egyéb okból";
                myServiceData.ErrorDetails = e.ToString();
                throw new FaultException<ServiceData>(myServiceData, e.ToString());
            }

        }

        private void initUsersTable(SqlConnection objConnection)
        {
            SqlDataAdapter objAdapater = new SqlDataAdapter();
            objAdapater.TableMappings.Add("Table", "users");
            DataSet ObjDataset = new DataSet("users");
            SqlCommand objCommand = new SqlCommand
            ("Select * from users;");
            objCommand.Connection = objConnection;
            objAdapater.SelectCommand = objCommand;
            objAdapater.Fill(ObjDataset);
            lock (Users)
            {
                Users.Clear();
                foreach (DataRow dr in ObjDataset.Tables["users"].Rows)
                {
                    User user = new User();
                    user.Username = dr["username"].ToString();
                    user.Password = dr["password"].ToString();
                    Users.Add(user);
                }
            }
        }

        public string login (string user, string password)
        {
            foreach (User item in Users)
            {
                if(item.Username.Equals(user) && item.Password.Equals(password))
                {
                    string id = Guid.NewGuid().ToString(); //Session string generálás
                    logged.Add(id, user); // Session string és user pár hozzáadása a dictionaryhoz
                    return id;
                }
            }
            return null;
        }

        public void logout(string uid)
        {
            if(logged.ContainsKey(uid))
            logged.Remove(uid);
        }
        public string bye()
        {
            return "bye-bye";
        }

        public ServiceData AddUser(string username, string password)
        {
            ServiceData myServiceData = new ServiceData();
            try
            {
                lock (Users)
                {
                    int i = 0;
                    for (i = 0; i < Users.Count && Users[i].Username != username; i++) ;
                    if (i < Users.Count)
                    {
                        myServiceData.Result = false;
                        myServiceData.ErrorMessage = "Existing username";
                        throw new FaultException<ServiceData>(myServiceData);
                    }
                    else
                    {
                        User current = new User(username, password);
                        Users.Add(current);
                        writeRowToDatabase(current);
                        myServiceData.Result = true;
                        myServiceData.ErrorMessage = "Registration Successful " + username;
                        return myServiceData;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "Database failure";
                myServiceData.ErrorDetails = sqlEx.ToString();
                throw new FaultException<ServiceData>(myServiceData, sqlEx.ToString()); // A DEBUGGER EL FOGJA KAPNI EZT IS, LEÁLL HOGYHA VS-BŐL VAN INDÍTVA
            }
            catch (Exception e)
            {
                myServiceData.Result = false;
                myServiceData.ErrorDetails = e.ToString();
                throw new FaultException<ServiceData>(myServiceData, e.ToString());
            }
        }

        private void setupAndExecute(string query)
        {
            SqlConnection objConnection = new SqlConnection();
            objConnection.ConnectionString = strConnectionString;
            objConnection.Open();
            SqlCommand objCommand = new SqlCommand
            (query);
            objCommand.Connection = objConnection;
            objCommand.ExecuteNonQuery();
            objConnection.Close();
        }

        private void writeRowToDatabase(User current)
        {
            setupAndExecute("INSERT INTO bookstore.dbo.users VALUES ('" + current.Username + "', '" + current.Password + "');");
        }

        public ServiceData Add(string name, string author, string code, int price, string id)
        {
            ServiceData myServiceData = new ServiceData();
            try
            {
                if (id == null || !logged.ContainsKey(id))
                {
                    throw new FieldAccessException("User couldn't be verified");
                }
                else
                {
                    string value = "";
                    logged.TryGetValue(id, out value);
                    if (value.Equals("admin"))
                    {
                        lock (Products)
                        {
                            int i = 0;
                            for (i = 0; i < Products.Count && Products[i].Id != code; i++) ;
                            if (i < Products.Count)
                            {
                                myServiceData.ErrorMessage = "Product Code Already Exists";
                                return myServiceData;
                            }
                            else
                            {
                                if (price < 0)
                                {
                                    myServiceData.ErrorMessage = "Price cannot be smaller than 0";
                                    return myServiceData;
                                }
                                Book current = new Book(name, author, code, price);
                                writeRowToDatabase(current);
                                myServiceData.Result = true;
                                myServiceData.ErrorMessage = "OK, Added: " + name + " " + author + " " + code + " " + price;
                                return myServiceData;
                            }
                        }
                    }
                    else
                    {
                        myServiceData.ErrorMessage = "No Admin Privilage";
                        return myServiceData;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "Database failure";
                myServiceData.ErrorDetails = sqlEx.ToString();
                throw new FaultException<ServiceData>(myServiceData, sqlEx.ToString()); // A DEBUGGER EL FOGJA KAPNI EZT IS, LEÁLL HOGYHA VS-BŐL VAN INDÍTVA
            }
            catch (FieldAccessException fieldEx)
            {
                myServiceData.Result = false;
                myServiceData.ErrorMessage = "Please Log In";
                myServiceData.ErrorDetails = fieldEx.ToString();
                throw new FaultException<ServiceData>(myServiceData, fieldEx.ToString());
            }
            catch (Exception e)
            {
                myServiceData.Result = false;
                myServiceData.ErrorDetails = e.ToString();
                throw new FaultException<ServiceData>(myServiceData, e.ToString());
            }
        }

        private void writeRowToDatabase(Book current)
        {
            setupAndExecute
            ("INSERT INTO bookstore.dbo.book VALUES (" + current.Id + ", '"+current.Name+ "', '" + current.Author + "', "+current.Curr_price+");");
        }

        public string CreateSale(string uid)
        {
            if (uid != null && logged.ContainsKey(uid))
            {
                string value = "";
                logged.TryGetValue(uid, out value);
                if (value.Equals("admin"))
                {
                    CreateSaleToDatabase();
                    return "EVERYTHING UNDER 1000 HUF";
                }
                else
                    return "No Admin Privilage";
            }
            return "Please Log In";
        }

        private void CreateSaleToDatabase()
        {
            setupAndExecute("UPDATE bookstore.dbo.book SET price = 999 WHERE price > 999;");
        }

        public List<Book> List()
        {
                SqlConnection objConnection = new SqlConnection();
                objConnection.ConnectionString = strConnectionString;
                objConnection.Open();
                DataSet ObjDataset = new DataSet();
                SqlDataAdapter objAdapater = new SqlDataAdapter();
                SqlCommand objCommand = new SqlCommand
                ("Select * from book;");
                objCommand.Connection = objConnection;
                objAdapater.SelectCommand = objCommand;
                objAdapater.Fill(ObjDataset);
                lock (Products)
                {
                    Products.Clear();
                    foreach (DataRow dr in ObjDataset.Tables[0].Rows)
                    {
                        Book book = new Book();
                        book.Id = dr["id"].ToString();
                        book.Name = dr["name"].ToString();
                        book.Author = dr["author"].ToString();
                        book.Curr_price = int.Parse(dr["price"].ToString());
                        Products.Add(book);
                    }

                    objConnection.Close();
                    return Products;
                }
        }

        public string Buy(string code, string id)
        {
            if (id == null || !logged.ContainsKey(id))
            {
                return "Please Log in";
            }
            else
            {
                lock (Products)
                {
                    foreach (Book item in Products.ToList()) // Kell a ToList() hogy másolódjon
                    {
                        if (item.Id == code)
                        {
                            Products.Remove(item);
                            removeFromDatabase(item); //DELETE
                        }
                    }
                    return "Book Bought";
                }
            }
        }

        private void removeFromDatabase(Book item)
        {
            try
            {
                setupAndExecute("DELETE FROM bookstore.dbo.book WHERE id = " + item.Id + ";");
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
