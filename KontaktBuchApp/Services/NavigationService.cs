using KontaktBuchApp.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontaktBuchApp.Services
{
	public class NavigationService : ViewModelBase, INavigationService
	{
		private ViewModelBase _currentViewModel;

		public ViewModelBase CurrentViewModel
		{
			get => _currentViewModel;
			private set
			{
				_currentViewModel = value;
				PropertyChanged?.Invoke(
					 this,
					 new PropertyChangedEventArgs(nameof(CurrentViewModel)));
			}
		}

		public void NavigateTo(ViewModelBase viewModel)
		{
			CurrentViewModel = viewModel;
		}

		public event PropertyChangedEventHandler? PropertyChanged;
	}
}
