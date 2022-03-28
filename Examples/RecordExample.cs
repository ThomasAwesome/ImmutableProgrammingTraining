namespace ImmutableProgrammingTraining.Examples;
//This is called positional parameters 
public record RecordExample1(string Foo, string Bar);

//Without using positional parameters 
public record RecordExample2
{
  public string Foo { get; init; }
  public string Bar { get; init; }

  public RecordExample2(string foo, string bar)
  {
    Foo = foo;
    Bar = bar;
  }
}