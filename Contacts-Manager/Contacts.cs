using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_Manager
{
    public class Contacts
    {
        public static List<string> contacts = new List<string>();

        public static void ContactManager()
        {
            int number;
            do
            {
                Console.WriteLine("Enter 0 to exit the program");
                Console.WriteLine("Enter 1 to add a contact and add the name of the contact");
                Console.WriteLine("Enter 2 to remove a contact then put the name of the contact to delete it");
                Console.WriteLine("Enter 3 to Display the available contacts");
                number = int.Parse(Console.ReadLine());
                string contact;
                switch (number)
                {
                    case 1:
                        Console.WriteLine("Enter the name of the contact to add:");
                        contact = Console.ReadLine();
                        AddContact(contact);
                        break;

                    case 2:
                        Console.WriteLine("Enter the name of the contact to remove:");
                        contact = Console.ReadLine();
                        RemoveContact(contact);
                        break;

                    case 3:
                        ViewAllContacts();
                        break;

                    default:
                        break;
                }
            } while (number != 0);
        }

        public static List<string> AddContact(string contact)
        {
            if (string.IsNullOrWhiteSpace(contact))
            {
                throw new ArgumentException("Contact cannot be empty or whitespace.");
            }

            if (contacts.Contains(contact))
            {
                throw new InvalidOperationException("You cannot add duplicate contacts.");
            }

            contacts.Add(contact);
            Console.WriteLine("Contact added successfully.");
            return contacts;
        }

        public static List<string> RemoveContact(string contact)
        {
            if (!contacts.Contains(contact))
            {
                throw new KeyNotFoundException("Contact does not exist.");
            }

            contacts.Remove(contact);
            Console.WriteLine("Contact removed successfully.");
            return contacts;
        }

        public static List<string> ViewAllContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts available.");
                return contacts;
            }

            Console.WriteLine("Available contacts:");
            foreach (var item in contacts)
            {
                Console.WriteLine(item);
            }

            return contacts;
        }
    }
}
