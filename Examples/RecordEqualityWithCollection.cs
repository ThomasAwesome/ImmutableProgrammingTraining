namespace ImmutableProgrammingTraining.Examples;

public record RecordEqualityWithCollection(string Name, string[] Emails)
{
	public virtual bool Equals(RecordEqualityWithCollection? other)
	{
		if (ReferenceEquals(other, null))
		{
			return false;
		}

		if (ReferenceEquals(this, other))
		{
			return true;
		}

		return Name.Equals(other.Name)
			&& Emails.OrderBy(email => email).SequenceEqual(other.Emails.OrderBy(email => email));
	}

	public override int GetHashCode()
	{
		var collectionHashCode = new HashCode();
		foreach (var email in Emails)
		{
			collectionHashCode.Add(email);
		}
		return HashCode.Combine(Name, collectionHashCode);
	}
}

