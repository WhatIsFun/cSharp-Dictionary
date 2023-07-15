using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_Dictionary
{
    internal class Contacts
    {
        private Dictionary<String, String> contactInfo;

        public Contacts() 
        {
            contactInfo = new Dictionary<String, String>();
        }
        public void Add(String name, String phoneNum)
        {
            if (contactInfo.ContainsKey(name))
            {
                // If the name is already taken
                Console.WriteLine("The name {0} already exists in the phone book.", name);
            }
            else
            {
                contactInfo.Add(name, phoneNum);
                Console.WriteLine("The contact {0} with number {1} has successfully added to the phone book.", name, phoneNum);
            }
        }
        public void Remove(String name)
        {
            if (contactInfo.ContainsKey(name))
            {
                contactInfo.Remove(name);

                Console.WriteLine("The contact {0} has been deleted from the phone book.", name);
            }
            else
            {
                Console.WriteLine("The contact {0} is not found in the phone book.", name);
            }
        }
        public void Search (String name)
        {
            if (contactInfo.ContainsKey(name))
            {
                string number = contactInfo[name];
                Console.WriteLine("The contact name: {0} \r\nPhone number: {1}.", name, number);
            }
            else
            {
                Console.WriteLine("The contact {0} is not found in the phone book.", name);
            }
        }
    }
}
