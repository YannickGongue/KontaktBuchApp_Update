using CommunityToolkit.Mvvm.Input;
using KontaktBuchApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KontaktBuchApp.ViewModel
{
	public class ContactMethodsViewModel : ViewModelBase
	{
		private string _mobile;
		private string _email;
		private string _phone;
		private string _fax;
		public Action<MContactMethod> ContactMethodSaved { get; set; }
		public MContactMethod ContactMethod { get; private set; }

		public string Mobile
		{
			get { return _mobile; }
			set
			{
				_mobile = value;
				OnPropertyChanged(nameof(Mobile));
			}
		}

		public string Email
		{
			get { return _email; }
			set
			{
				_email = value;
				OnPropertyChanged(nameof(Email));
			}
		}

		public string Phone
		{
			get { return _phone; }
			set
			{
				_phone = value;
				OnPropertyChanged(nameof(Phone));
			}
		}

		public string Fax
		{
			get { return _fax; }
			set
			{
				_fax = value;
				OnPropertyChanged(nameof(Fax));
			}
		}

		public IRelayCommand OkCommand { get; set; }

		public IRelayCommand CancelCommand { get; set; }

		public ContactMethodsViewModel(MContactMethod contactMethod)
		{
			ContactMethod = contactMethod;
			this.OkCommand = new RelayCommand(SaveContactMethod);

		}

		private void SaveContactMethod()
		{
			if (!string.IsNullOrWhiteSpace(Mobile))
			{
				ContactMethod.Type = MContactMethodType.Mobile;
				ContactMethod.Value = Mobile;
			}
			else if (!string.IsNullOrWhiteSpace(Email))
			{
				ContactMethod.Type = MContactMethodType.Email;
				ContactMethod.Value = Email;
			}
			else if (!string.IsNullOrWhiteSpace(Phone))
			{
				ContactMethod.Type = MContactMethodType.Phone;
				ContactMethod.Value = Phone;
			}
			else if (!string.IsNullOrWhiteSpace(Fax))
			{
				ContactMethod.Type = MContactMethodType.Fax;
				ContactMethod.Value = Fax;
			}

			ContactMethodSaved?.Invoke(ContactMethod);
		}
	}
}
