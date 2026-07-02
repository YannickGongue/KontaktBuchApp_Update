using CommunityToolkit.Mvvm.Input;
using KontaktBuchApp.Models;
using KontaktBuchApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace KontaktBuchApp.ViewModel
{
    public class OPenContactViewModel : ViewModelBase
	 {
		private IImagesService _imageService;
		private MContact _mContact;
		private string _contactName;	
		private string ? _contactEmail;
		private string ? _contactPhone;
		private ImageSource _selectedImage;
		public ImageSource ContactImage
		{
			get { return _selectedImage; }
			set
			{
				_selectedImage = value;
				OnPropertyChanged(nameof(ContactImage));
			}
		}

		public string FullName
		{
			get {  return _contactName; }
			set { _contactName = value; 
			     OnPropertyChanged(nameof(FullName));}
		}


		public string PrimaryEmail
		{
			get { return _contactEmail; }
			set { _contactEmail = value;
			     OnPropertyChanged(nameof(PrimaryEmail));}
		}

		public string PrimaryPhone
		{
			get { return _contactPhone; }
			set
			{
				_contactPhone = value;
				OnPropertyChanged(nameof(PrimaryPhone));
			}
		}

		public OPenContactViewModel(MContact mContact, IImagesService imagesService)
		{
			this._mContact = mContact;
			this._imageService = imagesService;
			this.FullName=this._mContact.Vorname;
			this.PrimaryEmail =this._mContact.Nachname;
			this.PrimaryPhone = this._mContact.ContactId;
			this.ContactImage = this._imageService.ConvertToImage(this._mContact.Profilbild);
		}

	}
}
