using System;
namespace AddressBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MultipleAddressBook multipleAddressBook = new MultipleAddressBook();
            Console.WriteLine("\t\t\t\t\t\tWelcome to Address Book Program");
            int choice;
            while (true)
            {
                Console.WriteLine("\n 1. Add new address book");
                Console.WriteLine(" 2. Add new contact");
                Console.WriteLine(" 3. Edit added contact");
                Console.WriteLine(" 4. Delete persons contact using first name");
                Console.WriteLine(" 5. Display all address books and contacts");
                Console.WriteLine(" 6. Delete address book");
                Console.WriteLine(" 7. Search contact details using city");
                Console.WriteLine(" 8. Search contact details using state");
                Console.WriteLine(" 9. View contact details using city");
                Console.WriteLine("10. View contact details using state");
                Console.WriteLine(" 0. Exit");
                Console.Write("Enter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        multipleAddressBook.DisplayAllAddressBooks();
                        multipleAddressBook.AddingMultipleAddressBooks();
                        multipleAddressBook.DisplayAllAddressBooks();
                        break;
                    case 2:
                        multipleAddressBook.DisplayAllAddressBooks();
                        multipleAddressBook.AddContactsInAddressBook();
                        multipleAddressBook.DisplayAllAddressBooks();
                        break;
                    case 3:
                        multipleAddressBook.EditDetailsOfAddressBook();
                        multipleAddressBook.DisplayAddressBookAndContactDetails();
                        break;
                    case 4:
                        multipleAddressBook.DeletingDetailsInAddressBook();
                        multipleAddressBook.DisplayAddressBookAndContactDetails();
                        break;
                    case 5:
                        multipleAddressBook.DisplayAddressBookAndContactDetails();
                        break;
                    case 6:
                        multipleAddressBook.DeleteAddressBook();
                        break;
                    case 7:
                        multipleAddressBook.SearchPersonByCity();
                        break;
                    case 8:
                        multipleAddressBook.SearchPersonByState();
                        break;
                    case 9:
                        multipleAddressBook.GetCityNames();
                        multipleAddressBook.AddToCityDictionary();
                        multipleAddressBook.ViewPersonByCity();
                        break;
                    case 10:
                        multipleAddressBook.GetStateNames();
                        multipleAddressBook.AddToStateDictionary();
                        multipleAddressBook.ViewPersonByState();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Enter correct choice");
                        break;
                }
            }
        }
    }
}