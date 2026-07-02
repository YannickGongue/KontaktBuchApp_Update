using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KontaktBuchApp.Services
{
	public interface IImagesService
	{
		byte[] ConvertToBytes(string path);
		string FileName(string path);
		string FileExtension(string path);
		ImageSource LoadImage(OpenFileDialog dialog);
		BitmapImage ConvertToImage(byte[] imageData);

	}
}
