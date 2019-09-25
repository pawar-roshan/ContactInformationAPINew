using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class DataModel : IDataModel
    {
        private IDataRepository dataAccessLayerObj;

        //Injected data accessLayer object using depedency injection
        public DataModel(IDataRepository provider)
        {
            dataAccessLayerObj = provider;
        }        
        public contact_info AddContact(contact_info contact)
        {
            return dataAccessLayerObj.AddContact(contact);
        }

        public contact_info Delete(int ContactID)
        {
            return dataAccessLayerObj.Delete(ContactID);
        }

        public contact_info GetContact(int ContactID)
        {
            return dataAccessLayerObj.GetContact(ContactID);
        }

        public IEnumerable<contact_info> GetContacts()
        {
            return dataAccessLayerObj.GetContacts();
        }

        public contact_info UpdateContact(int id,contact_info contact)
        {
            var contactDetails = dataAccessLayerObj.GetContact(id);

            if (contact != null)
            {
                contactDetails.first_name = contact.first_name;
                contactDetails.last_name = contact.last_name;
                contactDetails.phone_no = contact.phone_no;
                contactDetails.email = contact.email;
                contactDetails.status = contact.status;
            }

            return dataAccessLayerObj.UpdateContact(contactDetails);
        }
    }
}
