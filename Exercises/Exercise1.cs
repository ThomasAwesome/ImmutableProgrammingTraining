using NUnit.Framework;
//Convert the class into a record using positional parameters. 
//The Record needs to automatically cast the name field to UPPER CASE without using a defined constructor.
//Email stays optional and continues to be defaulted to “hello-there@example.com”

namespace ImmutableProgrammingTraining.Exercises.Exercise1;

public class ConvertToRecord
{
	public ConvertToRecord(string name, string? email = "hello-there@example.com")
	{
		Name = name.ToUpper();
		Email = email;
	}

	public string Name { get; set; }

	public string? Email { get; set; }

}

[TestFixture]
public class ConvertToRecordTests
{

	[Test]
	public void Test1()
	{
		var convertToRecord = new ConvertToRecord("General Kenboi", "kenboi@example.com");

		Assert.Multiple(() =>
		{
			Assert.That(convertToRecord.Name, Is.EqualTo("GENERAL KENBOI"));
			Assert.That(convertToRecord.Email, Is.Not.Null);
		});
	}

	[Test]
	public void Test2()
	{
		var convertToRecord = new ConvertToRecord("General Kenboi");
		Assert.That(convertToRecord.Email, Is.EqualTo("hello-there@example.com"));
	}
}