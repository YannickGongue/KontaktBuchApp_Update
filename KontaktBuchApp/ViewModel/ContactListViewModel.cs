using CommunityToolkit.Mvvm.Input;
using KontaktBuchApp.Models;
using KontaktBuchApp.Repositories;
using KontaktBuchApp.Services;
using KontaktBuchApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KontaktBuchApp.ViewModel
{
	public class ContactListViewModel : ViewModelBase
	{
		private string searchText;
		private string contactId;
		private string vorname;
		private string nachname;
		private bool _bNewRow;

		private MAddress _mAddress;
		private MContactMethod _mContactMethod;

		private IContactList _IcontactList;
		private IContactDetails _IcontactDetail;

		private ImageSource imagePath;
		private ObservableCollection<MAddress> addresses;
		private ObservableCollection<MContactMethod> contactMethods	;
		private IMessageService _Imessageservice;
		private IImagesService _IimageService;
		private IFileDialogService _fileDialogService;
		private ContactDetailViewModel _vmContactDetail;
		private ContactDetailView ContactDetailView;

		private OpenContactView openContactView;
		private OPenContactViewModel _vmOpenContact;

		private ObservableCollection<MContact> _contacts;
		private MContact _mContact;
		private MContact _selectedContact;
		private ImageSource _imageSource;

		public Action<MContact> ContactSaved { get; set; }

		public bool bNewRow
		{
			get { return _bNewRow; }
			set
			{
				_bNewRow = value;
				OnPropertyChanged(nameof(bNewRow));
			}
		}
		public ImageSource ProfilbildImage
		{
			get => this._imageSource;
			set
			{
				_imageSource = value;
				OnPropertyChanged(nameof(ProfilbildImage));
			}
		}


		public MContact SelectedContact
		{
			get => _selectedContact;
			set
			{
				_selectedContact = value;
				OnPropertyChanged(nameof(SelectedContact));
			}
		}
		public ObservableCollection<MContact> Contacts
		{
			get => _contacts;
			set
			{
				_contacts = value;
				OnPropertyChanged(nameof(Contacts));
			}
		}
		public string SearchText
		{
			get { return searchText; }
			set { searchText = value; 
			      OnPropertyChanged(nameof(this.SearchText)); }
		}

		public string ContactId
		{
			get { return contactId; }
			set
			{
				contactId = value;
				OnPropertyChanged(nameof(this.ContactId));
			}
		}

		public string Vorname
		{
			get { return vorname; }
			set
			{
				vorname = value;
				OnPropertyChanged(nameof(this.Vorname));
			}
		}

		public string Nachname
		{
			get { return nachname; }
			set
			{
				nachname = value;
				OnPropertyChanged(nameof(this.Nachname));
			}
		}

		public ImageSource ImagePath
		{
			get { return imagePath; }
			set
			{
				imagePath = value;
				OnPropertyChanged(nameof(this.ImagePath));
			}
		}

		public ObservableCollection<MAddress> Addresses
		{
			get { return addresses; }
			set
			{
				addresses = value;
				OnPropertyChanged(nameof(this.Addresses));
			}
		}

		public ObservableCollection<MContactMethod> ContactMethods
		{
			get { return contactMethods	; }
			set
			{
				contactMethods	 = value;
				OnPropertyChanged(nameof(this.ContactMethods));
			}
		}

		public IRelayCommand OpenCommand { get; set; }
		public IRelayCommand AddCommand { get; set; }
		public IRelayCommand SearchCommand { get; set; }

		public IRelayCommand EditCommand { get; set; }


		public ContactListViewModel(IContactList iContactList,
			                         IContactDetails icontactDetail,
			                         IFileDialogService fileDialogService,
											 IImagesService IimageService,
			                         IMessageService Imessageservice,
											 MContact mContact,
											 MAddress mAddress,
											 MContactMethod mContactMethod)
		{
			this._mContact = mContact;
			this._mAddress = mAddress;
			this._mContactMethod = mContactMethod;
			this._IcontactList = iContactList;
			this._IcontactDetail = icontactDetail;
			this._fileDialogService = fileDialogService;
			this._IimageService = IimageService;
			this._Imessageservice = Imessageservice;

			this._contacts = new ObservableCollection<MContact>();
			Contacts = _IcontactList.GetAll();

			foreach (var contact in this.Contacts)
			{
				contact.ProfilbildImage = _IimageService.ConvertToImage(contact.Profilbild);
			}

			this.OpenCommand = new RelayCommand(OpenContact);
			this.AddCommand = new RelayCommand(AddContact);
			this.SearchCommand = new RelayCommand(SearchContacts);
			this.EditCommand = new RelayCommand(EditContact);
		}

		private void EditContact()
		{
			this.ShowContactView();
			this.ContactSaved = AddContactToList;

		}

		private void SearchContacts()
		{
			this.Contacts = this._IcontactList.Get(this.SearchText);
		}

		private void AddContact()
		{
			this.bNewRow = true;
		  this.ShowContactView();
			this.ContactSaved = AddContactToList;
			this.Contacts = this._contacts;

		}

		private void AddContactToList(MContact contact)
		{
			if (Contacts == null)
			{
				Contacts = new ObservableCollection<MContact>();
			}

			Contacts.Add(contact);
		}

		private void OpenContact()
		{

			this._vmOpenContact = new OPenContactViewModel(FillContact(), this._IimageService);
			this.openContactView = new OpenContactView();

			this.openContactView.DataContext = this._vmOpenContact;
			this.openContactView.Show();
		}

		public void ShowContactView()
		{
			this.ContactDetailView = new ContactDetailView();
			this._vmContactDetail = new ContactDetailViewModel(this._fileDialogService,
																				this._IimageService,
																				this._Imessageservice,
																				this._IcontactDetail,
																				this._IcontactList,
																				FillContact(),
																				this._mAddress,
																				this._mContactMethod);
			this.ContactDetailView.DataContext = this._vmContactDetail;
			this.ContactDetailView.Show();
		}

		private MContact FillContact()
		{
			
			if (SelectedContact == null)
				return null;

			return new MContact
			{
				ContactId = SelectedContact.ContactId,
				Vorname = SelectedContact.Vorname,
				Nachname = SelectedContact.Nachname,
				Profilbild = SelectedContact.Profilbild,
				Addresses = SelectedContact.Addresses,
				ContactMethods = SelectedContact.ContactMethods
			};
		}
	}
}
