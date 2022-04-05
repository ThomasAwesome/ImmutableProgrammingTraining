using NUnit.Framework;

namespace ImmutableProgrammingTraining.Exercises.Exercise1;

public class ConvertToRecord
{
	public ConvertToRecord(string name, string? email = null)
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
		Assert.That(convertToRecord.Email, Is.Null);
	}
}