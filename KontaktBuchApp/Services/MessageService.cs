using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KontaktBuchApp.Services
{
	public class MessageService : IMessageService
	{
		public void ShowMessage(string message)
		{
			MessageBox.Show(message, "Message", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		public void ShowUserControl(Window wdControl)
		{
			wdControl.Show();
		}

	}
}
