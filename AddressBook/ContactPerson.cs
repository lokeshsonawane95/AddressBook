using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class ContactPerson
    {
        //Declaring list to add multiple data type information
        List<Details> detailsList;

        public ContactPerson()
        {
            detailsList = new List<Details>();
        }

        public void AddingContactDetails()
        {
            //Filling the contact details
            Console.WriteLine("Add details one by one");
            Console.Write("Enter First Name : ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name : ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Address : ");
            string address = Console.ReadLine();
            Console.Write("Enter City : ");
            string city = Console.ReadLine();
            Console.Write("Enter State : ");
            string state = Console.ReadLine();
            Console.Write("Enter zip code : ");
            int zip = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter phone number : ");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter Email id : ");
            string email = Console.ReadLine();

            //Passing values to the details object
            Details details = new Details(firstName, lastName, address, city, state, email, zip, phoneNumber);

            //Checking if entered details already present or not
            if (detailsList.Contains(details))
            {
                Console.WriteLine("These details already present in Address book");
            }

            //If not add it to the list
            else
            {
                detailsList.Add(details);
            }
        }

        //Displaying the details
        public void DisplayDetails()
        {
            foreach (Details d in detailsList)
            {
                Console.WriteLine("\nContact details are as shown below");
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
