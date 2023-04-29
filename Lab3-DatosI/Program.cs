using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Schema;

namespace Lab3_DatosI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Lectura de deserializacion
            string Custom = @"C:\Users\sical\OneDrive\Escritorio\input_customer_example_lab_3.jsonl";
            string Auctions = @"C:\Users\sical\OneDrive\Escritorio\input_auctions_example_lab_3.jsonl";
            // Lee el contenido del archivo
            string fileCustomer = File.ReadAllText(Custom);
            string fileAuctions = File.ReadAllText(Auctions);
            // Separa los objetos JSON utilizando una expresión regular
            var regex = new Regex(@"\{.*?\}(?=\s*\{|\s*$)", RegexOptions.Singleline);
            var jsonCustomer = regex.Matches(fileCustomer);
            var jsonAuctions = regex.Matches(fileAuctions);

            // Deserializa cada objeto JSON en una instancia de las clases Client
            List<PropertyData> Bettors = new List<PropertyData>();

            foreach (Match jsonMatch in jsonAuctions)
            {
                string jsonString = jsonMatch.Value;
                PropertyData cliente = JsonConvert.DeserializeObject<PropertyData>(jsonString);
                Bettors.Add(cliente);
            }
            // Deserializa cada objeto JSON en una instancia de las clases Customers
            List<Client> Clientes = new List<Client>();
            foreach(Match jsonMatch in jsonCustomer)
            {
                string jsonString = jsonMatch.Value;
                Client cliente = JsonConvert.DeserializeObject<Client>(jsonString);
                Clientes.Add(cliente);
            }
            #endregion

            //Creamos un arbol
            ArbolBin tree = new ArbolBin();
            int n=0;
            foreach (Client client in Clientes)
            {
                tree.Inserta(client);
            }
            long dpiToFind = 4866841378551;
            Client foundClient = tree.Encontrar(dpiToFind);

            if (foundClient != null)
            {
                Console.WriteLine($"Client found: DPI: {foundClient.DPI}, Name: {foundClient.firstName} {foundClient.lastName}, Birth Date: {foundClient.birthDate.ToShortDateString()}, Job: {foundClient.job}, Place Job: {foundClient.placeJob}, Salary: {foundClient.salary}");
            }
            else
            {
                Console.WriteLine($"Client with DPI {dpiToFind} not found");
            }

        }
    }
    #region clases generales
    public class Client
    {
        public long DPI { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string job { get; set; }
        public string placeJob { get; set; }
        public int salary { get; set; }
    }
    public class PropertyData
    {
        [JsonProperty("property")]
        public string Property { get; set; }

        [JsonProperty("customers")]
        public List<Customer> Customers { get; set; }

        [JsonProperty("rejection")]
        public int Rejection { get; set; }
    }

    public class Customer
    {
        [JsonProperty("dpi")]
        public long Dpi { get; set; }

        [JsonProperty("budget")]
        public int Budget { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
    #endregion
}
