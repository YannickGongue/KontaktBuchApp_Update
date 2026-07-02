using KontaktBuchApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontaktBuchApp.Repositories
{
	public interface IContactDetails
	{
		public ObservableCollection<MAddress> GetAll();
		public List<MAddress> GetAddressesByContactId(string contactId);

		public void UpdateAddressesByContactId(string contactId);
		public void DeletesAddresse(string id);

		public List<MContactMethod> GetContactMethodsByContactId(string contactId);
		public void UpdateContactMethodsByContactId(string contactId);
		public void DeletesContactMethod(string id);
	}
}
