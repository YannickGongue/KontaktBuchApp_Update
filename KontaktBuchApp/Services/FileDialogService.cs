using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontaktBuchApp.Services
{
	public class FileDialogService : IFileDialogService
	{
		public OpenFileDialog OpenImageFileDialog()
		{
			// Implementation for opening image file dialog
			OpenFileDialog dialog = new OpenFileDialog();

			dialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*"; ;
			dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			return dialog;
		}
	}
}
