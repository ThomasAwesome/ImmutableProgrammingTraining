using NUnit.Framework;

namespace ImmutableProgrammingTraining.Exercises.Exercise1;

public class ConvertToRecord
{
  public ConvertToRecord(string name, string email)
  {
    Name = name.ToUpper();
    Email = email;
  }

  public string Name { get; set; }

  public string Email { get; set; }

}

public class ConvertToRecordTests
{

  [Test]
  public void Test1()
  {
    var convertToRecord = new ConvertToRecord("General Kenboi", "kenboi@example.com");

    Assert.That(convertToRecord.Name, Is.EqualTo("GENERAL KENBOI"));
  }
}