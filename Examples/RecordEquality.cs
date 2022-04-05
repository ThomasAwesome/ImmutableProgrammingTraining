namespace ImmutableProgrammingTraining.Examples;

public record RecordEquality(string Name, string Type)
{
	//You don't have to override Equals. It needs to either virtual or the record needs to be sealed.
	//this is pretty close to what the default would be.
	public virtual bool Equals(RecordEquality? other)
	{
		if (ReferenceEquals(other, null))
		{
			return false;
		}

		if (ReferenceEquals(this, other))
		{
			return true;
		}

		return Name.Equals(other.Name) && Type.Equals(other.Type);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Name, Type);
	}
}

