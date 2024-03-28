using Godot;
using System;

public partial class Global : Node
{
	public int cockroachScore { get; set; } = 0;
	public int parkingScore { get; set; } = 0;
	public int typerScore { get; set; } = 0;

	public void CurrentScore()
	{
		string rez = string.Format("Cockroach: {0}\nParking: {1}\nTyper: {2}\nTotal: {3}",
			cockroachScore, parkingScore, typerScore, Sum());
        Console.WriteLine(rez);
    }
	int Sum()
	{
		return cockroachScore + parkingScore + typerScore;
	}
}
