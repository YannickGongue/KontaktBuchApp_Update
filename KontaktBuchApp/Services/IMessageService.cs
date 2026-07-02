using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KontaktBuchApp.Services
{
	public interface IMessageService
	{
		void ShowMessage(string message);
		void ShowUserControl(Window wdControl);
	}
}
