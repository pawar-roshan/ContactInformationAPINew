
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataAccessLayer
{
    public static class Utilily
    {

         

       static string filePath = @"D:\Practices\ContactInformationAPI\Contact.txt";

        public static List<ContactInfo> ReadData()
        {

            List<ContactInfo>  contactList = new List<ContactInfo>();
            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                ContactInfo contact = new ContactInfo();
                contact.ContactId = Convert.ToInt32(entries[0]);
                contact.FirstName = entries[1];
                contact.LastName = entries[2];
                contact.Email = entries[3];
                contact.PhoneNo = entries[4];
                contact.Status = Convert.ToBoolean(entries[5]);

                contactList.Add(contact);

            }

            return contactList;
        }

        public static void WriteData(List<ContactInfo> contactInfo)
        {
            List<string> writelines = new List<string>();

            foreach (var contact in contactInfo) {

                writelines.Add(contact.ContactId+","+contact.FirstName+","+contact.LastName+","+contact.Email+","+contact.PhoneNo+","+contact.Status);
            }
            File.WriteAllLines(filePath, writelines);
        }

    }
}
