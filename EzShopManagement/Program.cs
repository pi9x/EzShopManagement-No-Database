using System;
using System.Collections.Generic;

namespace EzShopManagement
{
    class Program
    {
        struct Product
        {
            public string Code;
            public string Name;
            public DateTime Exp;
            public string Company;
            public int Year;
            public string Category;
        }

        static List<Product> products = new List<Product>();

        static void AddProd(ref List<Product> products)
        {
            string _code;
            string _name;
            DateTime _exp;
            string _company;
            int _year;
            string _category;
            Console.Clear();
            Console.WriteLine("ADD NEW PRODUCT\n");
            // Product code
            Console.Write("Product code: "); string temp = Console.ReadLine();
            if (string.IsNullOrEmpty(temp) || string.IsNullOrWhiteSpace(temp))
            {
                Console.Write("WARNING! Please enter product code: ");
                _code = Console.ReadLine();
            }
            else _code = temp;
            // Product name
            Console.Write("Product name: "); temp = Console.ReadLine();
            if (string.IsNullOrEmpty(temp) || string.IsNullOrWhiteSpace(temp))
            {
                Console.Write("WARNING! Please enter product name: ");
                _name = Console.ReadLine();
            }
            else _name = temp;
            // Expiry date
            Console.Write("Expiry date [DD-MM-YYYY]: ");
            try
            {
                _exp = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
            }
            catch (FormatException e)
            {
                Console.Write("WARNING! Wrong date format. Please ONLY use [DD-MM-YYYY]: ", e);
            }
            finally
            {
                _exp = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
            }
            // Company name
            Console.Write("Company name: "); temp = Console.ReadLine();
            if (string.IsNullOrEmpty(temp) || string.IsNullOrWhiteSpace(temp))
            {
                Console.Write("WARNING! Please enter company name: ");
                _company = Console.ReadLine();
            }
            else _company = temp;
            // Production year
            Console.Write("Production year: ");
            try
            {
                _year = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.Write("WARNING! Wrong production year. Please enter an INTEGER: ", e);
            }
            finally
            {
                _year = int.Parse(Console.ReadLine());
            }
            // Product category
            Console.Write("Product category: "); temp = Console.ReadLine();
            if (string.IsNullOrEmpty(temp) || string.IsNullOrWhiteSpace(temp))
            {
                Console.Write("WARNING! Please enter product category: ");
                _category = Console.ReadLine();
            }
            else _category = temp;
            // Add product to list
            products.Add(new Product
            {
                Code = _code,
                Name = _name,
                Exp = _exp,
                Company = _company,
                Year = _year,
                Category = _category
            });
        }

        // Delete by product code
        static void DelProd(ref List<Product> products, string _key)
        {
            products.RemoveAll(product => product.Code.ToLower() == _key.ToLower());
            Console.Write("\nProduct successfully deleted. Press any key to continue...");
        }

        // Edit by product code
        static void EditProd(ref List<Product> products, string _key)
        {
            bool exist = false;
            foreach (Product prod in products)
                if (prod.Code.ToLower() == _key.ToLower())
                {
                    exist = true;
                    Product temp = prod;
                    Console.Write("\nNew product code: "); temp.Code = Console.ReadLine();
                    Console.Write("New product name: "); temp.Name = Console.ReadLine();
                    Console.Write("New expiry date [DD/MM/YYYY]: "); temp.Exp = DateTime.Parse(Console.ReadLine());
                    Console.Write("New production company: "); temp.Company = Console.ReadLine();
                    Console.Write("New production year: "); temp.Year = int.Parse(Console.ReadLine());
                    Console.Write("New product category: "); temp.Category = Console.ReadLine();
                    products.Add(temp);
                    products.Remove(prod);
                    break;
                }
            if (!exist)
                Console.Write("\nProduct does not exist. Press any key to continue...");
            else
                Console.Write("\nProduct successfully edited. Press any key to continue...");
        }

        // Search by name
        static void SearchName(List<Product> products, string _key)
        {
            bool exist = false;
            Console.WriteLine();
            foreach (Product prod in products)
                if (prod.Name.Contains(_key))
                {
                    exist = true;
                    Console.WriteLine($"Code: {prod.Code} | Name: {prod.Name} | Exp: {prod.Exp.ToShortDateString()} | Company: {prod.Company} | Production year: {prod.Year} | Category: {prod.Category}");
                }
            if (!exist)
                Console.Write($"There is no result for {_key}. Press any key to continue...");
        }

        // Search by category
        static void SearchCat(List<Product> products, string _key)
        {
            bool exist = false;
            Console.WriteLine();
            foreach (Product prod in products)
                if (prod.Category.Contains(_key))
                {
                    exist = true;
                    Console.WriteLine($"Code: {prod.Code} | Name: {prod.Name} | Exp: {prod.Exp.ToShortDateString()} | Company: {prod.Company} | Production year: {prod.Year} | Category: {prod.Category}");
                }
            if (!exist)
                Console.Write($"There is no product in category {_key}. Press any key to continue...");
        }

        // Delete a category
        static void DelCat(ref List<Product> products, string _key)
        {
            products.RemoveAll(product => product.Category.ToLower() == _key.ToLower());
            Console.Write("\nCategory successfully deleted. Press any key to continue...");
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("EZ SHOP MANAGEMENT\n");
            Console.WriteLine("1. Add new product");
            Console.WriteLine("2. Delete a product");
            Console.WriteLine("3. Edit a product");
            Console.WriteLine("4. Search by name");
            Console.WriteLine("5. Search by category");
            Console.WriteLine("6. Delete a category");
            Console.WriteLine("0. Exit\n");
            Console.Write("Choose an option [0 - 6]: ");
        }

        static void Main(string[] args)
        {
        start: Menu();
            string chosen = Console.ReadLine();
            switch (chosen)
            {
                case "1":
                    AddProd(ref products);
                    Console.Write("\nProduct successfully added. Press any key to continue...");
                    Console.ReadKey();
                    goto start;
                case "2":
                    Console.Clear();
                    Console.WriteLine("DELETE A PRODUCT\n");
                    Console.Write("Enter product code: ");
                    string _delcode = Console.ReadLine();
                    DelProd(ref products, _delcode);
                    Console.ReadKey();
                    goto start;
                case "3":
                    Console.Clear();
                    Console.WriteLine("EDIT A PRODUCT\n");
                    Console.Write("Enter product code: ");
                    string _editcode = Console.ReadLine();
                    EditProd(ref products, _editcode);
                    Console.ReadKey();
                    goto start;
                case "4":
                    Console.Clear();
                    Console.WriteLine("SEARCH FOR A PRODUCT\n");
                    Console.Write("Enter search term: ");
                    string _term = Console.ReadLine();
                    SearchName(products, _term);
                    Console.ReadKey();
                    goto start;
                case "5":
                    Console.Clear();
                    Console.WriteLine("SEARCH BY CATEGORY\n");
                    Console.Write("Enter product category: ");
                    string _cat = Console.ReadLine();
                    SearchCat(products, _cat);
                    Console.ReadKey();
                    goto start;
                case "6":
                    Console.Clear();
                    Console.WriteLine("DELETE A CATEGORY\n");
                    Console.Write("Enter product category: ");
                    string _delcat = Console.ReadLine();
                    DelCat(ref products, _delcat);
                    Console.ReadKey();
                    goto start;
                case "0":
                    break;
                default:
                    Console.Write("\nWrong number! Press any key to start again...");
                    Console.ReadKey();
                    goto start;
            }
        }
    }
}