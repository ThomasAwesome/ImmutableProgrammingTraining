using System;
using NUnit.Framework;

namespace ImmutableProgrammingTraining.Exercises.Exercise3;

//Remove the ticks from the datatime. Some databases can't save datetimes with that much precision.
public record ModifingDateTime(Guid Id, string Name, DateTime LastUpdated)
{
	private DateTime lastUpdated = RemoveTicks(LastUpdated);

	public DateTime LastUpdated
	{
		get => lastUpdated;
		set => lastUpdated = RemoveTicks(value);
	}

	public static DateTime RemoveTicks(DateTime dateTime)
	{
		return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond, dateTime.Kind);
	}
}

[TestFixture]
public class ModifingPropertyValuesTests
{
	[Test]
	public void RemoveTicksFromDateTime()
	{
		var lastUpdated = DateTime.UtcNow;
		var expected = new DateTime(lastUpdated.Year, lastUpdated.Month, lastUpdated.Day, lastUpdated.Hour, lastUpdated.Minute, lastUpdated.Second, lastUpdated.Millisecond, lastUpdated.Kind);
		var modifingDateTime = new ModifingDateTime(Guid.NewGuid(), "Mando", lastUpdated);
		Assert.That(modifingDateTime.LastUpdated, Is.EqualTo(expected));

		var upatedLastUpdated = DateTime.UtcNow.AddDays(1).AddHours(-1);
		var updatedExpected = new DateTime(upatedLastUpdated.Year, upatedLastUpdated.Month, upatedLastUpdated.Day, upatedLastUpdated.Hour, upatedLastUpdated.Minute, upatedLastUpdated.Second, upatedLastUpdated.Millisecond, upatedLastUpdated.Kind);
		var updatedDateTime = modifingDateTime with { Name = "Kenobi", LastUpdated = upatedLastUpdated };
		Assert.That(updatedDateTime.LastUpdated, Is.EqualTo(updatedExpected));
	}
}