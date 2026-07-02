using KontaktBuchApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontaktBuchApp.Services
{
	public interface INavigationService
	{
		ViewModelBase CurrentViewModel { get; }

		void NavigateTo(ViewModelBase viewModel);
	}
}
