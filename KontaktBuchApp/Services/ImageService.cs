using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KontaktBuchApp.Services
{
	public class ImageService : IImagesService
	{
		private IMessageService _messageService;
		private ImageSource imageSource;
		private ImageSource imageSourcedefault;
		private string ImagePath;


		public ImageService(IMessageService messageService)
		{
			this._messageService = messageService;
		}

		public byte[] ConvertToBytes(string path)
		{
			return File.ReadAllBytes(path);
		}

		public string FileName(string path)
		{
			return Path.GetFileName(path);
		}

		public string FileExtension(string path)
		{
			return Path.GetExtension(path);
		}

		public BitmapImage ConvertToImage(byte[] imageData)
		{
			using var ms = new MemoryStream(imageData);

			var image = new BitmapImage();

			image.BeginInit();
			image.CacheOption = BitmapCacheOption.OnLoad;
			image.StreamSource = ms;
			image.EndInit();
			image.Freeze();

			return image;
		}

		public ImageSource LoadImage(OpenFileDialog dialog)
		{

			try
			{
				if (dialog.ShowDialog() == true)
				{
					ImagePath = dialog.FileName;
					imageSource = new BitmapImage(new Uri(ImagePath));
					return imageSource;
				}
			}
			catch (Exception ex)
			{
				this._messageService.ShowMessage(ex.Message);
			}

			return imageSourcedefault;

		}
	}
}
