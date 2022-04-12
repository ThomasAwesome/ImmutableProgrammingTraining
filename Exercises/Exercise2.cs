using System;

namespace ImmutableProgrammingTraining.Exercises.Exercise2;

//Prevent the Id Property from being changed with the "with" keyword

public record ReadOnlyIdentity(Guid Id, string Name)
{
	
}

public class CodeChallenge
{
	public void Challenge()
	{
		var user = new ReadOnlyIdentity(Guid.NewGuid(), "kenobi");

		//prevent the identity of the entity from changing.
		var preventThis = user with {Id = Guid.NewGuid()};
	}
}