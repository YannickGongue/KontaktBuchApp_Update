using KontaktBuchApp.DBManager;
using KontaktBuchApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontaktBuchApp.Repositories
{
	public class ContactDetails : IContactDetails
	{

		public List<MAddress> _ltAddresses;
		public ContactDetails()
		{
			_ltAddresses = new List<MAddress>
			{
				new MAddress { AddressId = "1", ContactId = "1", Plz = "12345", Ort = "City1", Strasse = "Street1", strasseNr = "1", Land = "Country1" },
				new MAddress { AddressId = "2", ContactId = "1", Plz = "67890", Ort = "City2", Strasse = "Street2", strasseNr = "2", Land = "Country2" },
				new MAddress { AddressId = "3", ContactId = "2", Plz = "54321", Ort = "City3", Strasse = "Street3", strasseNr = "3", Land = "Country3" }
			};

		}
		public ObservableCollection<MAddress> GetAll()
		{
			return new ObservableCollection<MAddress>(_ltAddresses);
		}
		public List<MAddress> GetAddressesByContactId(string contactId)
		{
			
			return   this._ltAddresses
						  .Where(a => a.ContactId == contactId)
						  .ToList();
		}
		public void DeletesAddresse(string id)
		{
			var address = this._ltAddresses
									  .FirstOrDefault(a => a.AddressId == id);
			if (address != null)
			{
				this._ltAddresses.Remove(address);
			}
		}
		public List<MContactMethod> GetContactMethodsByContactId(string contactId)
		{
			throw new NotImplementedException();
		}
		public void DeletesContactMethod(string id)
		{
			throw new NotImplementedException();
		}

		public void UpdateAddressesByContactId(string contactId)
		{
			throw new NotImplementedException();
		}

		public void UpdateContactMethodsByContactId(string contactId)
		{
			throw new NotImplementedException();
		}
	}
}
