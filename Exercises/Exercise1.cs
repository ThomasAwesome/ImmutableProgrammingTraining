using NUnit.Framework;
//Convert the class into a record using positional parameters. 
//The Record needs to automatically cast the name field to UPPER CASE without using a defined constructor.
//Email stays optional and continues to be defaulted to “hello-there@example.com”

namespace ImmutableProgrammingTraining.Exercises.Exercise1;

public record ConvertToRecord(string Name, string? Email = "hello-there@example.com")
{
	public string Name { get; init; } = Name.ToUpper();
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