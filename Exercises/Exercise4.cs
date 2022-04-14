using System;
using System.Collections.Immutable;
using NUnit.Framework;

namespace ImmutableProgrammingTraining.Exercises.Exercise4;

//Implement the logic in the method to pass the tests. 
//The methods should use the "with" to return a new object.
public record User(Guid Id, string Email, string Name, ImmutableList<string> AdditionalEmails)
{
	//Prevents the User Id from being changed.
	public Guid Id { get; } = Id;

	public User UpdateEmail(string email)
	{
		return null;
	}

	public User UpdateName(string name)
	{
		return null;
	}

	public User AddAdditionalEmail(string email)
	{
		return null;
	}

	public User RemoveAdditionalEmail(string email)
	{
		return null;
	}

}

[TestFixture]
public class UserTests
{

	[Test]
	public void When_updating_the_email_and_they_are_the_same()
	{
		string email = "General-Kenobi@eample.com";
		var user = new User(Guid.NewGuid(), email, "Obi", ImmutableList.Create<string>());

		var updatedUser = user.UpdateEmail(email);

		Assert.That(updatedUser, Is.EqualTo(user));
	}

	[Test]
	public void When_updating_the_email_and_they_are_different()
	{
		string email = "General-Kenobi@eample.com";
		var user = new User(Guid.NewGuid(), email, "Obi", ImmutableList.Create<string>());
		var updatedEmail = "hello-there@eample.com";
		var updatedUser = user.UpdateEmail(updatedEmail);

		Assert.Multiple(() =>
		{
			Assert.That(updatedUser, Is.Not.EqualTo(user));
			Assert.That(updatedUser.Email, Is.EqualTo(updatedEmail));
		});
	}

	[Test]
	public void When_updating_the_name_and_they_are_the_same()
	{
		const string Name = "Obi";

		var user = new User(Guid.NewGuid(), "General-Kenobi@eample.com", Name, ImmutableList.Create<string>());

		var updatedUser = user.UpdateName(Name);

		Assert.That(updatedUser, Is.EqualTo(user));
	}

	[Test]
	public void When_updating_the_name_and_they_are_different()
	{
		var user = new User(Guid.NewGuid(), "General-Kenobi@eample.com", "Obi", ImmutableList.Create<string>());
		var upatedName = "Obi-Wan";

		var updatedUser = user.UpdateName(upatedName);

		Assert.Multiple(() =>
		{
			Assert.That(updatedUser, Is.Not.EqualTo(user));
			Assert.That(updatedUser.Name, Is.EqualTo(upatedName));
		});
	}

	[Test]
	public void When_adding_an_additional_email_and_it_adds_it_to_the_list_of_emails()
	{
		var user = new User(Guid.NewGuid(), "General-Kenobi@eample.com", "Obi", ImmutableList.Create<string>());

		var additionalEmail = "obi-wan-kenboi@example.com";
		var updatedUser = user.AddAdditionalEmail(additionalEmail);

		Assert.Multiple(() =>
		{
			Assert.That(updatedUser, Is.Not.EqualTo(user));
			Assert.That(updatedUser.AdditionalEmails, Does.Contain(additionalEmail));
		});
	}

	[Test]
	public void When_removing_an_additional_email_and_it_removes_it_to_the_list_of_emails()
	{
		var additionalEmail = "obi-wan-kenboi@example.com";
		var user = new User(Guid.NewGuid(), "General-Kenobi@eample.com", "Obi", ImmutableList.Create<string>(additionalEmail));

		var updatedUser = user.RemoveAdditionalEmail(additionalEmail);

		Assert.Multiple(() =>
		{
			Assert.That(updatedUser, Is.Not.EqualTo(user));
			Assert.That(updatedUser.AdditionalEmails, Does.Not.Contain(additionalEmail));
		});
	}
}
