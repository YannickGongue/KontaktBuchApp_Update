using KontaktBuchApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontaktBuchApp.Models
{
	public class MAddress
	{		
		[Key]
		public string AddressId { get; set; }
		public string ContactId { get; set; }
		public string Plz { get; set; }
		public string Ort { get; set; }
		public string Strasse { get; set; }
		public string strasseNr { get; set; }
		public string Land { get; set; }

		public MContact mContact { get; set; }
	}
}
