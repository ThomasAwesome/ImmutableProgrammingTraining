namespace ImmutableProgrammingTraining.Examples;

public record Game(string Title, string Genre, int NumberOfPlayer);

public class GameManager
{
	public void Games()
	{
		var game = new Game("Super Programming Game", "Programming", 1);

		//Really this should be done with mob programming :)
		var updatedGame = game with {NumberOfPlayer = 4,};

		Console.WriteLine(game == updatedGame); //false
		Console.WriteLine(game.Title == updatedGame.Title); //true
		Console.WriteLine(game.Genre == updatedGame.Genre); //true
		Console.WriteLine(game.NumberOfPlayer == updatedGame.NumberOfPlayer); //false
	}
}