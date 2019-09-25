using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLayer
{
    public class BusinessDataModel : IDataModel
    {
        private IDataRepository dataAccessLayerObj;

        //public BusinessDataModel(IDataRepository provider)
        //{
        //    dataAccessLayerObj = provider;
        //}
        public BusinessDataModel()
        {
            dataAccessLayerObj = new DataRepository();
        }
        public ContactInfo AddContact(ContactInfo contact)
        {
            return dataAccessLayerObj.AddContact(contact);
        }
        
        public IEnumerable<ContactInfo> GetContacts()
        {
            return dataAccessLayerObj.GetContacts();
        }

        public ContactInfo GetContact(int ContactID)
        {
            return dataAccessLayerObj.EditContact(ContactID);
        }

        public ContactInfo UpdateContact(ContactInfo contact)
        {
            return dataAccessLayerObj.UpdateContact(contact);
        }

        public ContactInfo Delete(int ContactID)
        {
            return dataAccessLayerObj.Delete(ContactID);
        }

        public ContactInfo EditContact(int ContactID)
        {
            return dataAccessLayerObj.EditContact(ContactID);
        }
    }
}
