using System.Collections.Immutable;

namespace ImmutableProgrammingTraining.Examples;

public record Plan(string PlanId, ImmutableList<string> Subscriptions)
{
	public virtual bool Equals(Plan? other)
	{
		if (ReferenceEquals(this, other))
		{
			return true;
		}

		if (other is null)
		{
			return false;
		}

		return PlanId == other.PlanId
				&& Subscriptions.OrderBy(sub => sub).SequenceEqual(other.Subscriptions.OrderBy(sub => sub));
	}

	public override int GetHashCode()
	{
		var collectionHashCode = new HashCode();
		foreach (var subscription in Subscriptions)
		{
			collectionHashCode.Add(subscription);
		}
		return HashCode.Combine(PlanId, collectionHashCode);
	}
}

public record User(Guid Id, string Name, string Email, ImmutableList<string> Subscriptions, Plan Plan)
{
	public User UpdateEmail(string email)
	{
		return this with {Email = email};
	}

	public virtual bool Equals(User? other)
	{
		if (ReferenceEquals(this, other))
		{
			return true;
		}

		if (other is null)
		{
			return false;
		}

		return Id == other.Id
				&& Name == other.Name
				&& Email == other.Name
				&& Subscriptions.OrderBy(sub => sub).SequenceEqual(other.Subscriptions.OrderBy(sub => sub))
				&& Plan == other.Plan;
	}

	public override int GetHashCode()
	{
		var collectionHashCode = new HashCode();
		foreach (var subscription in Subscriptions)
		{
			collectionHashCode.Add(subscription);
		}
		return HashCode.Combine(Id, Name, Email, Plan, collectionHashCode);
	}
}

public class ExampleLogic
{
	public void HandleEvent()
	{
		var user = new User(
			Guid.NewGuid(),
			"Obi-Wan",
			"general-kenboi@example.com", 
			ImmutableList.Create("sub1"),
			new Plan(
				"Jedi Order",
				ImmutableList.Create("plan-sub1")));

		var updatedUser = user.UpdateEmail("hello-there@example.com");

		if(user != updatedUser){
			//Trigger some business logic.
		}
	}
}
