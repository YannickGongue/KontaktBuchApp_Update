
using KontaktBuchApp.Models;
using KontaktBuchApp.Repositories;

namespace KontaktBuchTest
{
	[TestClass]
	public sealed class ContactLIstTest
	{
		[TestMethod]
   	public void CreateContact_ShouldSetNames()
		{
			// Arrange
			var contact = new MContact
			{
				Vorname = "Yannick",
				Nachname = "Gongue"
			};

			// Assert
			Assert.AreEqual("Yannick", contact.Vorname);
			Assert.AreEqual("Gongue", contact.Nachname);
		}

		[TestMethod]
		public void AddContact_Should_Increase_Count()
		{
			// Arrange
			var repo = new ContactList();

			var before = repo.GetAll().Count;

			var contact = new MContact
			{
				ContactId = "99",
				Vorname = "Test",
				Nachname = "User"
			};

			// Act
			repo.Add(contact);

			var after = repo.GetAll().Count;

			// Assert
			Assert.AreEqual(before + 1, after);
		}

		[TestMethod]
		public void Contact_Should_Set_Properties_Correctly()
		{
			// Arrange
			var contact = new MContact();

			// Act
			contact.Vorname = "Max";
			contact.Nachname = "Mustermann";

			// Assert
			Assert.AreEqual("Max", contact.Vorname);
			Assert.AreEqual("Mustermann", contact.Nachname);
		}

		[TestMethod]

		public void Update_Should_Update_Existing_Contact()
		{
			// Arrange
			var repo = new ContactList();

			var updatedContact = new MContact
			{
				ContactId = "01",
				Vorname = "Max",
				Nachname = "Mustermann",
				Profilbild = null
			};

			// Act
			repo.Update(updatedContact);

			var result = repo.Get("01").FirstOrDefault();

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("Max", result.Vorname);
			Assert.AreEqual("Mustermann", result.Nachname);
		}
	}
}

