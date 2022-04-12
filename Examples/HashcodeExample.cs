namespace ImmutableProgrammingTraining.Examples;

public record HashcodeExample(string Foo, bool Bar, int Baz);

public class ExampleToShow
{
	public void Example()
	{
		var hashcodeExampleOne = new HashcodeExample("test", true, 10);
		var hashcodeExampleTwo = new HashcodeExample("test", true, 10);

		Console.WriteLine(hashcodeExampleOne.GetHashCode() == hashcodeExampleTwo.GetHashCode());
		//output: True
	}
}