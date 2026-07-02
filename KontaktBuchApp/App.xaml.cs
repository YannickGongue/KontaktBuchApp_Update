using KontaktBuchApp.Services;
using KontaktBuchApp.Views;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using KontaktBuchApp.Models;
using KontaktBuchApp.Repositories;
using KontaktBuchApp.ViewModel;
using KontaktBuchApp.DBManager;

namespace KontaktBuchApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly IServiceProvider _serviceProvider;
		public App()
		{
			IServiceCollection services = new ServiceCollection();
			ConfigureServices(services);

			_serviceProvider = services.BuildServiceProvider();
		}


		private void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<ContactListView>();
			services.AddSingleton<ContactDetailView>();
			services.AddSingleton<OpenContactView>();
			services.AddSingleton<AddressView>();
			services.AddSingleton<ContactMethodView>();

			services.AddTransient<ContactListViewModel>();
			services.AddTransient<OPenContactViewModel>();
			services.AddTransient<ContactDetailViewModel>();
			services.AddTransient<AddressViewModel>();

			services.AddTransient<MContact>();
			services.AddTransient<MContactMethod>();
			services.AddTransient<MAddress>();

			services.AddTransient<IImagesService, ImageService>();
			services.AddTransient<IContactList, ContactList>();
			services.AddTransient<IFileDialogService, FileDialogService>();
			services.AddTransient<IMessageService, MessageService>();
			services.AddTransient<IContactDetails, ContactDetails>();


		}

		private void Application_Startup(object sender, StartupEventArgs e)
		{
			var mainWindow = _serviceProvider.GetRequiredService<ContactListView>();
			mainWindow.DataContext = _serviceProvider.GetRequiredService<ContactListViewModel>();

			mainWindow.Show();

		}
	}

}
