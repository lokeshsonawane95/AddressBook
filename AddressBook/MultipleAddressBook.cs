using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class MultipleAddressBook
    {
        public string choose;

        //Declaring city dictionary
        public Dictionary<string, List<Details>> cityDictionary = new Dictionary<string, List<Details>>();

        //Declaring city list to store cities as city names can be duplicates and dictionary does not support duplicates
        public HashSet<string> cityList = new HashSet<string>();

        //Declaring state dictionary
        public Dictionary<string, List<Details>> stateDictionary = new Dictionary<string, List<Details>>();

        //Declaring state list to store states as state names can be duplicates and dictionary does not support duplicates
        public HashSet<string> stateList = new HashSet<string>();

        //Declaring dictionary for maintaining multiple Address book
        public Dictionary<string, ContactPerson> AddrBook = new Dictionary<string, ContactPerson>();

        //Adding Address Books one by one
        public void AddingMultipleAddressBooks()
        {
            Console.Write("Address book name : ");
            string addressBookName = Console.ReadLine();

            //If entered value is null
            if (addressBookName == "" | addressBookName == null)
            {
                Console.WriteLine("Please write Address Book name");
            }

            //If entered value already present
            if (AddrBook.ContainsKey(addressBookName))
            {
                Console.WriteLine("Entered Address Book name already present please enter again");
            }
            else
            {
                ContactPerson contactPerson = new ContactPerson();
                AddrBook.Add(addressBookName, contactPerson);
            }
        }

        //Asking user to choose which Address book to access
        public void AddContactsInAddressBook()
        {
            if (AddrBook.Count > 0)
            {
                Console.Write("Enter the name of the Address Book you want to access : ");
                string choose = Console.ReadLine();

                //Check if entered AddressBook name(here key) is available in dictionary or entered Address book is empty
                if (!AddrBook.ContainsKey(choose))
                {
                    Console.WriteLine("Choose from available names");
                    /*this.choose = choose;
                    MultipleAddressBook multipleAddressBook = AddrBook[choose];*/
                }
                //Check again
                else
                {
                    ContactPerson contactPerson = AddrBook[choose];
                    contactPerson.AddingContactDetails();
                }
            }
            else
            {
                Console.WriteLine("Address book records are empty");
            }
        }

        public void EditDetailsOfAddressBook()
        {
            if (AddrBook.Count > 0)
            {
                Console.Write("Enter the name of the Address Book you want to access : ");
                string choose = Console.ReadLine();

                //Check if entered AddressBook name(here key) is available in dictionary or entered Address book is empty
                if (!AddrBook.ContainsKey(choose))
                {
                    Console.WriteLine("Choose from available names");
                }
                //Check again
                else
                {
                    ContactPerson contactPerson = AddrBook[choose];
                    contactPerson.EditContactDetails();
                }
            }
            else
            {
                Console.WriteLine("Address book records are empty");
            }
        }

        //Displaying all Address Books available and their index numbers
        public void DisplayAllAddressBooks()
        {
            if (AddrBook.Count > 0)
            {
                Console.WriteLine("*********************");
                Console.WriteLine("Address books are :");
                foreach (KeyValuePair<string, ContactPerson> pair in AddrBook)
                {
                    Console.WriteLine("Address Book Name : {0}", pair.Key);
                }
                Console.WriteLine("*********************");
            }
            else
            {
                Console.WriteLine("Address Book records are empty");
            }
        }

        public void DeletingDetailsInAddressBook()
        {
            if (AddrBook.Count > 0)
            {
                Console.Write("Enter the name of the Address Book you want to access : ");
                string choose = Console.ReadLine();

                //Check if entered AddressBook name(here key) is available in dictionary or entered Address book is empty
                if (!AddrBook.ContainsKey(choose))
                {
                    Console.WriteLine("Choose from available names");
                }
                //Check again
                else
                {
                    ContactPerson contactPerson = AddrBook[choose];
                    contactPerson.DeleteContactDetails();
                }
            }
            else
            {
                Console.WriteLine("Address book records are empty");
            }
        }

        public void DeleteAddressBook()
        {
            Console.Write("Enter the name of the Address Book you want to Delete : ");
            string choose = Console.ReadLine();

            //Check if entered AddressBook name(here key) is available in dictionary or entered Address book is empty
            if (!AddrBook.ContainsKey(choose))
            {
                Console.WriteLine("Choose from available names");
            }
            else
            {
                AddrBook.Remove(choose);
            }
        }

        public void DisplayAddressBookAndContactDetails()
        {
            foreach (KeyValuePair<string, ContactPerson> keyValuePair in AddrBook)
            {
                Console.WriteLine("Address book name is : " + keyValuePair.Key);
                ContactPerson contactPerson = keyValuePair.Value;
                contactPerson.DisplayDetails();
            }
        }

        public void SearchPersonByCity()
        {
            Console.Write("Enter the city to search : ");
            string cityName = Console.ReadLine();

            foreach (KeyValuePair<string, ContactPerson> keyValuePair in AddrBook)
            {
                Console.WriteLine("Address book name is : " + keyValuePair.Key);
                ContactPerson person = keyValuePair.Value;
                person.SearchPersonByCity(cityName);
            }
        }

        public void SearchPersonByState()
        {
            Console.Write("Enter the state name to search : ");
            string stateName = Console.ReadLine();

            foreach (KeyValuePair<string, ContactPerson> keyValuePair in AddrBook)
            {
                Console.WriteLine("Address book name is : " + keyValuePair.Key);
                ContactPerson person = keyValuePair.Value;
                person.SearchPersonByState(stateName);
            }
        }

        public void GetCityNames()
        {
            foreach (KeyValuePair<string, ContactPerson> keyValuePair in AddrBook)
            {
                ContactPerson contactPerson = keyValuePair.Value;

                foreach (string city in contactPerson.AddToCityList())
                {
                    cityList.Add(city);
                }
            }
        }

        public void GetStateNames()
        {
            foreach (KeyValuePair<string, ContactPerson> keyValuePair in AddrBook)
            {
                ContactPerson contactPerson = keyValuePair.Value;

                foreach (string state in contactPerson.AddToStateList())
                {
                    stateList.Add(state);
                }
            }
        }

        public void AddToCityDictionary()
        {
            foreach (string city in cityList)
            {
                List<Details> cityDetailsList = new List<Details>();
                foreach (KeyValuePair<string, ContactPerson> keyValuePair in AddrBook)
                {
                    ContactPerson contactPerson = keyValuePair.Value;
                    cityDetailsList = contactPerson.ContactDetailsByCity(city, cityDetailsList);
                }
                cityDictionary.Add(city, cityDetailsList);
            }
        }

        public void AddToStateDictionary()
        {
            foreach (string state in stateList)
            {
                List<Details> stateDetailsList = new List<Details>();
                foreach (KeyValuePair<string, ContactPerson> keyValuePair in AddrBook)
                {
                    ContactPerson contactPerson = keyValuePair.Value;
                    stateDetailsList = contactPerson.ContactDetailsByState(state, stateDetailsList);
                }
                stateDictionary.Add(state, stateDetailsList);
            }
        }

        //To view person details by city name
        public void ViewPersonByCity()
        {
            foreach (KeyValuePair<string, List<Details>> keyValuePair in cityDictionary)
            {
                int count = 0;
                Console.WriteLine("\nName of the city : " + keyValuePair.Key);
                foreach (Details details in keyValuePair.Value)
                {
                    Console.WriteLine("First Name : " + details.firstName);
                    Console.WriteLine("Last Name : " + details.lastName);
                    Console.WriteLine("Address : " + details.address);
                    Console.WriteLine("City : " + details.city);
                    Console.WriteLine("State : " + details.state);
                    Console.WriteLine("Zip code : " + details.zip);
                    Console.WriteLine("Phone number : " + details.phoneNumber);
                    Console.WriteLine("Email id : " + details.email);
                    Console.WriteLine();
                    count++;
                }
                Console.WriteLine("Total contacts in city " + keyValuePair.Key + " are : " + count);
            }
        }

        //To view person details by state name
        public void ViewPersonByState()
        {
            foreach (KeyValuePair<string, List<Details>> keyValuePair in stateDictionary)
            {
                int count = 0;
                Console.WriteLine("\nName of the state : " + keyValuePair.Key);
                foreach (Details details in keyValuePair.Value)
                {
                    Console.WriteLine("First Name : " + details.firstName);
                    Console.WriteLine("Last Name : " + details.lastName);
                    Console.WriteLine("Address : " + details.address);
                    Console.WriteLine("City : " + details.city);
                    Console.WriteLine("State : " + details.state);
                    Console.WriteLine("Zip code : " + details.zip);
                    Console.WriteLine("Phone number : " + details.phoneNumber);
                    Console.WriteLine("Email id : " + details.email);
                    Console.WriteLine();
                    count++;
                }
                Console.WriteLine("Total contacts in state " + keyValuePair.Key + " are : " + count);
            }
        }

        //To Read contacts from a text file
        public void ReadContactsFromTextFile()
        {
            string path = @"C:\Users\Lokesh\CS\AddressBook\AddressBook\ReadFile.txt";
            Console.WriteLine("Reading data from a text file\n");
            if (File.Exists(path))
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }

        //To Write contacts to a text file
        public void WriteContactsToTextFile()
        {
            foreach (KeyValuePair<string, ContactPerson> keyValuePair in AddrBook)
            {
                ContactPerson contactPerson = keyValuePair.Value;
                contactPerson.AddContactsToTextFile(keyValuePair.Key);
            }
            Console.WriteLine("Contact details appended in the file");
            Console.Write("Press 1 to read the appended data (other key to exit): ");
            int readChoice = Convert.ToInt32(Console.ReadLine());
            if (readChoice == 1)
            {
                string readPath = @"C:\Users\Lokesh\CS\AddressBook\AddressBook\WriteFile.txt";
                Console.WriteLine("Reading appended data from the text file");

                if (File.Exists(readPath))
                {
                    using (StreamReader reader = File.OpenText(readPath))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
        }

        //To read data from a csv file
        public void ReadContactsFromCSVFile()
        {
            Console.WriteLine("Reading data from a csv file");
            foreach (KeyValuePair<string, ContactPerson> keyValuePair in AddrBook)
            {
                string path = @"C:\Users\Lokesh\CS\AddressBook\AddressBook\CSVFiles\" + keyValuePair.Key + ".csv";
                if (File.Exists(path))
                {
                    using (StreamReader streamReader = new StreamReader(path))
                    {
                        using (CsvReader csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                        {
                            List<Details> list = csv.GetRecords<Details>().ToList();
                            foreach (Details d in list)
                            {
                                Console.WriteLine();
                                Console.WriteLine("First Name : " + d.firstName);
                                Console.WriteLine("Last Name : " + d.lastName);
                                Console.WriteLine("Address : " + d.address);
                                Console.WriteLine("City : " + d.city);
                                Console.WriteLine("State : " + d.state);
                                Console.WriteLine("Zip code : " + d.zip);
                                Console.WriteLine("Phone number : " + d.phoneNumber);
                                Console.WriteLine("Email id : " + d.email);
                            }
                        }
                    }
                }
            }
        }

        //To write data to a csv file
        public void WriteContactsToCSVFile()
        {
            Console.WriteLine("Writing data to a csv file");

            foreach (KeyValuePair<string, ContactPerson> keyValuePair in AddrBook)
            {
                ContactPerson contactPerson = keyValuePair.Value;
                contactPerson.AddCotactsToCSVFile(keyValuePair.Key);
            }
        }

        //To read data from a JSON file
        public void ReadContactsFromJSONFile()
        {
            Console.WriteLine("Reading data from a JSON file");
            foreach (KeyValuePair<string, ContactPerson> keyValuePair in AddrBook)
            {
                string path = @"C:\Users\Lokesh\CS\AddressBook\AddressBook\JSONFiles\" + keyValuePair.Key + ".json";
                if (File.Exists(path))
                {
                    List<Details> list = JsonConvert.DeserializeObject<List<Details>>(File.ReadAllText(path));
                    foreach (Details d in list)
                    {
                        Console.WriteLine();
                        Console.WriteLine("First Name : " + d.firstName);
                        Console.WriteLine("Last Name : " + d.lastName);
                        Console.WriteLine("Address : " + d.address);
                        Console.WriteLine("City : " + d.city);
                        Console.WriteLine("State : " + d.state);
                        Console.WriteLine("Zip code : " + d.zip);
                        Console.WriteLine("Phone number : " + d.phoneNumber);
                        Console.WriteLine("Email id : " + d.email);
                    }
                }
            }
        }

        //To write data to a JSON file
        public void WriteContactsToJSONFile()
        {
            Console.WriteLine("Writing data to a JSON file");
            foreach (KeyValuePair<string, ContactPerson> keyValuePair in AddrBook)
            {
                ContactPerson contactPerson = keyValuePair.Value;
                contactPerson.AddContactsToJSONFile(keyValuePair.Key);
            }
        }
    }
}
