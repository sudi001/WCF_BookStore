using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace LibraryWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [FaultContract(typeof(ServiceData))]
        ServiceData TestConnection(string ConnectionString);
        [OperationContract]
        string login(string user, string password);
        [OperationContract]
        void logout(string uid);
        [OperationContract]
        [FaultContract(typeof(ServiceData))]
        ServiceData Add(string name, string author, string code,int price, string uid);
        [OperationContract]
        [FaultContract(typeof(ServiceData))]
        ServiceData AddUser(string username, string password);
        [OperationContract]
        string bye();
        [OperationContract]
        string CreateSale(string uid);
        [OperationContract]
        List<Book> List();
        [OperationContract]
        string Buy(string code, string uid);


        // TODO: Add your service operations here
    }

    [DataContract]
    public class ServiceData
    {
        [DataMember]
        public bool Result { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public string ErrorDetails { get; set; }
    }


    [DataContract] // Nem feltétlenül kell. Akkor kell ha konkrét usert adok vissza operation contractban
    public class User
    {
        public User() // Serialization miatt kell a paraméter nélküli konstruktor
        {

        }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        private string username;
        
        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        
        private string password;


        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Book
    {
        string id, name, author = null;
        int curr_price;

        [DataMember]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        [DataMember]
        public int Curr_price
        {
            get 
            { 
                return curr_price; 
            }
            set 
            {
                curr_price = value; 
            }
        } 

        public Book() // Serialization miatt kell a paraméter nélküli konstruktor
        {

        }
        public Book(string name, string author, string id, int curr_price)
        {
            this.name = name; this.author = author; this.id = id; this.curr_price = curr_price;
        }
    }
}
