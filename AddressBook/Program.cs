using System;
namespace AddressBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\t\tWelcome to Address Book Program");
            int choice;
            do
            {
                Console.WriteLine("\n1. Adding contacts details");
                Console.WriteLine("2. Add new contact");
                Console.WriteLine("3. Edit added contact");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Contact details are as shown below");
                        //Adding contact information directly through object
                        Details details = new Details("Lokesh", "Sonawane", "Warje", "Pune", "Maharashtra", "lokesh@gmail.com", 411058, 919932156480);
                        details.DisplayDetails();
                        break;
                    case 2:
                        ContactPerson person = new ContactPerson();
                        person.AddingContactDetails();
                        person.DisplayDetails();
                        break;
                    case 3:
                        ContactPerson person3 = new ContactPerson();
                        person3.AddingContactDetails();
                        person3.DisplayDetails();

                        //Asking user if he/she wanted to edit the contact details or not
                        Console.WriteLine("Edit contact details using name ? 1: Yes/ Other: No");
                        Console.Write("Enter your choice : ");
                        int choice3 = Convert.ToInt32(Console.ReadLine());
                        if (choice3 == 1)
                        {
                            person3.EditContactDetails();
                            person3.DisplayDetails();
                        }
                        break;
                    default:
                        Console.WriteLine("Enter correct choice");
                        break;
                }
            } while (choice != 0);
        }
    }
}