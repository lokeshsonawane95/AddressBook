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
                Console.WriteLine("4. Delete added person contact using name");
                Console.WriteLine("5. Add multitple person");
                Console.WriteLine("6. Add multiple Address Books");
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
                        Console.WriteLine("Edit contact details using name ? 1: Yes/ OtherNumber: No");
                        Console.Write("Enter your choice : ");
                        int choice3 = Convert.ToInt32(Console.ReadLine());
                        if (choice3 == 1)
                        {
                            person3.EditContactDetails();
                            person3.DisplayDetails();
                        }
                        break;
                    case 4:
                        ContactPerson person4 = new ContactPerson();
                        person4.AddingContactDetails();
                        person4.DisplayDetails();

                        //Asking user if he/she wanted to edit the contact details or not
                        Console.WriteLine("Edit contact details using name ? 1: Yes/ OtherNumber: No");
                        Console.Write("Enter your choice : ");
                        int choice4 = Convert.ToInt32(Console.ReadLine());
                        if (choice4 == 1)
                        {
                            person4.EditContactDetails();
                            person4.DisplayDetails();
                        }

                        //Asking user if he/she wanted to delete the contact details or not
                        Console.WriteLine("Delete person using person name ? 1. Yes/ OtherNumber:  No");
                        Console.Write("Enter your choice : ");
                        int choice42 = Convert.ToInt32(Console.ReadLine());
                        person4.DeleteContactDetails();
                        //person4.DisplayDetails();
                        break;
                    case 5:
                        ContactPersonMultiple person5 = new ContactPersonMultiple();
                    Add:
                        Console.WriteLine("You want to enter details ? 1: Yes/ Other: No");
                        Console.Write("Enter your choice : ");
                        int c = Convert.ToInt32(Console.ReadLine());
                        if (c == 1)
                        {
                            person5.AddingContactDetails();
                            person5.DisplayDetails();
                            goto Add;
                        }

                    //Asking user if he/she wanted to edit the contact details or not
                    Edit:
                        if (person5.detailsList.Count > 0)
                        {
                            Console.WriteLine("Edit contact details using name ? 1: Yes/ OtherNumber: No");
                            Console.Write("Enter your choice : ");
                            int choice5 = Convert.ToInt32(Console.ReadLine());
                            if (choice5 == 1)
                            {
                                person5.EditContactDetails();
                                person5.DisplayDetails();
                                goto Edit;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No contact details available to edit");
                        }

                    //Asking user if he/she wanted to delete the contact details or not
                    Delete:
                        if (person5.detailsList.Count > 0)
                        {
                            Console.WriteLine("Delete person using person name ? 1. Yes/ OtherNumber:  No");
                            Console.Write("Enter your choice : ");
                            int choice52 = Convert.ToInt32(Console.ReadLine());
                            if (choice52 == 1)
                            {
                                person5.DeleteContactDetails();
                                person5.DisplayDetails();
                                goto Delete;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No contact details available for deletion");
                        }
                        break;
                    case 6:
                        Console.Write("How many Address Books do you need : ");
                        int need = Convert.ToInt32(Console.ReadLine());
                        MultipleAddressBook person6 = new MultipleAddressBook(need);
                    GoAgain:
                        person6.DisplayAllAddressBooks();
                        person6.AddingMultipleAddressBooks();
                        person6.DisplayAllAddressBooks();
                        person6.AccessingAddressBook();

                    Add1:
                        Console.Write("You want to enter details ? ( Press 1 for Yes / OtherNumber for No) : ");
                        int c6 = Convert.ToInt32(Console.ReadLine());
                        if (c6 == 1)
                        {
                            person6.AddingContactDetails();
                            person6.DisplayDetails();
                            goto Add1;
                        }

                    //Asking user if he/she wanted to edit the contact details or not
                    Edit1:
                        if (person6.detailsList[person6.addressBookIndex].Count > 0)
                        {
                            Console.Write("Edit contact details using name ? ( Press 1 for Yes / OtherNumber for No) : ");
                            int choice6 = Convert.ToInt32(Console.ReadLine());
                            if (choice6 == 1)
                            {
                                person6.EditContactDetails();
                                person6.DisplayDetails();
                                goto Edit1;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No contact details available to edit");
                        }

                    //Asking user if he/she wanted to delete the contact details or not
                    Delete1:
                        if (person6.detailsList[person6.addressBookIndex].Count > 0)
                        {
                            Console.Write("Delete person using person name ? ( Press 1 for Yes / OtherNumber for No) : ");
                            int choice62 = Convert.ToInt32(Console.ReadLine());
                            if (choice62 == 1)
                            {
                                person6.DeleteContactDetails();
                                person6.DisplayDetails();
                                goto Delete1;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No contact details available for deletion");
                        }
                        Console.WriteLine("Want to choose Address Book again ? ( Press 1 for Yes / OtherNumber for No) : ");
                        int start = Convert.ToInt32(Console.ReadLine());
                        if (start == 1)
                        {
                            goto GoAgain;
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