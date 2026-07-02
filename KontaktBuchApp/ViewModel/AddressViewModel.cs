using CommunityToolkit.Mvvm.Input;
using KontaktBuchApp.Models;
using KontaktBuchApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontaktBuchApp.ViewModel
{
	public class AddressViewModel : ViewModelBase
	{
		private string strasse;
		private string strasseNr;
		private string plz;
		private string ort;
		private string land;
		private ContactDetailViewModel _vmContactDetail;
		private IContactDetails _IContactDetail;

		public string Strasse
		{
			get { return strasse; }
			set
			{
				strasse = value;
				OnPropertyChanged(nameof(strasse));
			}
		}

		public string StrasseNr
		{
			get { return strasseNr; }
			set
			{
				strasseNr = value;
				OnPropertyChanged(nameof(strasseNr));
			}
		}

		public string Plz
		{
			get { return plz; }
			set
			{
				plz = value;
				OnPropertyChanged(nameof(Plz));
			}
		}

		public string Ort
		{
			get { return ort; }
			set
			{
				ort = value;
				OnPropertyChanged(nameof(Ort));
			}
		}

		public string Land
		{
			get { return land; }
			set
			{
				land = value;
				OnPropertyChanged(nameof(Land));
			}
		}
		public MAddress _mAddress;

		public Action CloseAction { get; set; }
		public Action<MAddress> AddressSaved { get; set; }

		public IRelayCommand OkCommand { get; set; }

		public IRelayCommand CancelCommand { get; set; }

		public AddressViewModel(MAddress mAddress)
		{
			this._mAddress = mAddress;
			this.OkCommand = new RelayCommand(SaveAddress);
		}

		private void SaveAddress()
		{
			this._mAddress.Ort = this.Ort;
			this._mAddress.Plz = this.Plz;
			this._mAddress.Land = this.Land;
			this._mAddress.strasseNr = this.StrasseNr;

			AddressSaved?.Invoke(_mAddress);

			CloseAction?.Invoke();

		}
	}
}
