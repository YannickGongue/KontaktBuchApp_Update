using KontaktBuchApp.Models;
using KontaktBuchApp.Repositories;
using KontaktBuchApp.Services;
using KontaktBuchApp.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KontaktBuchTest;

[TestClass]
public class ContactDetailViewModelTests
{
    [TestMethod]
	public void SaveContact_Should_Update_Model()
	{
		// Arrange
		var fileDialogServiceMock = new Mock<IFileDialogService>();
		var imageServiceMock = new Mock<IImagesService>();
		var messageServiceMock = new Mock<IMessageService>();
		var contactDetailsMock = new Mock<IContactDetails>();
		var contactListMock = new Mock<IContactList>();
		var contact = new MContact();
		var address = new MAddress();
		var contactMethod = new MContactMethod();

		var vm = new ContactDetailViewModel(
	 fileDialogServiceMock.Object,
	 imageServiceMock.Object,
	 messageServiceMock.Object,
	 contactDetailsMock.Object,
	 contactListMock.Object,
	 contact,
	 address,
	 contactMethod
);

		vm.FirstName = "Yannick";
		vm.LastName = "Gongue";

		// Act
		vm.SaveCommand.Execute(null);

		// Assert
		Assert.AreEqual("Yannick", contact.Vorname);
		Assert.AreEqual("Gongue", contact.Nachname);
	}

	[TestMethod]
	public void Add_Should_Add_Contact()
	{
		var repo = new ContactList();

		var contact = new MContact
		{
			ContactId = "99",
			Vorname = "Test",
			Nachname = "User"
		};

		repo.Add(contact);

		var result = repo.Get("99").FirstOrDefault();

		Assert.IsNotNull(result);
		Assert.AreEqual("Test", result.Vorname);
	}
}
