using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KontaktBuchApp.Models;
using KontaktBuchApp.Repositories;
using KontaktBuchApp.Services;
using KontaktBuchApp.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KontaktBuchApp.ViewModel
{
	public class ContactDetailViewModel : ViewModelBase
	{
		private string contactText;
		private MContact _mContacts;
		private MAddress _mAddress;
		private MContactMethod _mContactMethod;
		private IFileDialogService _fileDialogService;
		private IImagesService _imageService;
		private IMessageService _messageService;
		private IContactDetails _IcontactDetails;
		private IContactList _IContactList;
		private OpenFileDialog _OpenFileDialog;
 		private ImageSource _SelectedImage;

		private string _firstname;
		private string _lastname;
		private string street;
		private string city;
		private string postalCode;
		private string country;
		private MContactMethod contacttype;
		private string value;
		private ObservableCollection<MAddress> _addresses;
		private ObservableCollection<MContactMethod> _contactMethods;
		private AddressView _AddressView;
		private AddressViewModel AddressViewModel;

		public ObservableCollection<MAddress> Addresses
		{
			get { return _addresses; }
			set
			{
				_addresses = value;
				OnPropertyChanged(nameof(Addresses));
			}
		}

		public ObservableCollection<MContactMethod> ContactMethods
		{
			get { return _contactMethods; }
			set
			{
				_contactMethods = value;
				OnPropertyChanged(nameof(ContactMethods));
			}
		}
		public string FirstName
		{
			get { return _firstname; }
			set
			{
				_firstname = value;
				OnPropertyChanged(nameof(FirstName));
			}
		}

		public string LastName
		{
			get { return _lastname; }
			set
			{
				_lastname = value;
				OnPropertyChanged(nameof(LastName));
			}
		}
		public ImageSource SelectedImage
		{
			get { return this._SelectedImage; }
			set { this._SelectedImage = value;
				OnPropertyChanged(nameof(SelectedImage));
			}
		}

		public string Street
		{
			get { return street; }
			set
			{
				street = value;
				OnPropertyChanged(nameof(Street));
			}
		}
		public string City
		{
			get { return city; }
			set
			{
				city = value;
				OnPropertyChanged(nameof(City));
			}
		}

		public string PostalCode
		{
			get { return postalCode; }
			set
			{
				postalCode = value;
				OnPropertyChanged(nameof(PostalCode));
			}
		} 
		
		public string Country
		{
			get { return country; }
			set
			{
				country = value;
				OnPropertyChanged(nameof(Country));
			}
		}

		public string ContactText
		{
			get { return contactText; }
			set
			{
				contactText = value;
				OnPropertyChanged(nameof(ContactText));
			}
		}

		public MContactMethod ContactType
		{
			get { return contacttype; }
			set
			{
				contacttype = value;
				OnPropertyChanged(nameof(Type));
			}
		}

		public string Value
		{
			get { return value; }
			set
			{
				value = value;
				OnPropertyChanged(nameof(Value));
			}
		}

		public IRelayCommand SaveCommand { get; }
		public IRelayCommand DeleteCommand { get; }
		public IRelayCommand AddAddressCommand { get; }
		public IRelayCommand DeleteAddressCommand { get; }
		public IRelayCommand AddContactMethodCommand { get; }
		public IRelayCommand DeleteContactMethodCommand { get; }
		public IRelayCommand ChangeImageCommand { get; }

		public ContactDetailViewModel(IFileDialogService fileDialogService,
			                           IImagesService imageService, 
												IMessageService messageService,
												IContactDetails contactDetails,
												IContactList contactList,
												MContact mContact,
												MAddress mAddress,
												MContactMethod mContactMethod)
		{
			this._fileDialogService = fileDialogService;
			this._imageService = imageService;
			this._messageService = messageService;
			this._mContacts = mContact;
			this._mAddress = mAddress;
			this._mContactMethod = mContactMethod;
			this._IcontactDetails = contactDetails;
			this._IContactList = contactList;

			this.SaveCommand = new RelayCommand(SaveContact);
			this.DeleteCommand = new RelayCommand(DeleteContact);
			this.AddAddressCommand = new RelayCommand(AddAddress);
			this.DeleteAddressCommand = new RelayCommand(DeleteAddress);
			this.AddContactMethodCommand = new RelayCommand(AddContactMethod);
			this.DeleteContactMethodCommand = new RelayCommand(DeleteContactMethod);
			this.ChangeImageCommand = new RelayCommand(ChangeImage);

			if(this.AddText().Contains("Kontakt bearbeiten"))
			{
				this.FirstName = this._mContacts.Nachname;
				this.LastName = this._mContacts.Vorname;
				this._SelectedImage = this._imageService.ConvertToImage(this._mContacts.Profilbild);
				this.Addresses = this._mContacts.Addresses;
				this.ContactMethods = this._mContacts.ContactMethods;
			}
			else
			{
				this.FirstName = "";
				this.LastName = "";
				this._SelectedImage = null;
				this.Addresses =null ;
				this.ContactMethods = null;
			}
		}


		private string AddText()
		{
			if (this._mContacts == null)
				return this.ContactText = "Neuer Kontakt Hinzufügen";
			else
				return this.ContactText = "Kontakt bearbeiten";
		}

		private void SaveContact()
		{
		
				_mContacts.Nachname = this.LastName;
				_mContacts.Vorname = this.FirstName;
			   _mContacts.ProfilbildImage = this.SelectedImage;
			   _mContacts.Addresses = this.Addresses;
			  _mContacts.ContactMethods = this.ContactMethods;
				this._IContactList.Add(this._mContacts);     
				
			
		}

		private void DeleteContact()
		{
			if (!string.IsNullOrEmpty(this._mContacts.ContactId))
			{
				//this._IContactList.Delete(this._mContacts.ContactId);
			}
		}

		private void AddAddress()
		{
	
			this._AddressView = new AddressView();
			this.AddressViewModel = new AddressViewModel(this._mAddress);
			this._AddressView.DataContext = this.AddressViewModel;
			this._AddressView.Show();
			

		}

		private void DeleteAddress()
		{
			this._IcontactDetails.DeletesAddresse(this._mAddress.AddressId);
		}

		private void AddContactMethod()
		{
			_mContactMethod.Type = this.ContactType.Type;
			_mContactMethod.Value = this.Value;

			this._IcontactDetails.GetContactMethodsByContactId(this._mContacts.ContactId);
		}

		private void DeleteContactMethod()
		{
			this._IcontactDetails.DeletesContactMethod(this._mContactMethod.ContactTypeId);
		}

		private void ChangeImage() {

			try
			{
				this._OpenFileDialog = this._fileDialogService.OpenImageFileDialog();
				this.SelectedImage = this._imageService.LoadImage(this._OpenFileDialog);
			}
			catch (Exception ex)
			{
				this._messageService.ShowMessage(ex.Message);
			}
		}
		

	}
}
