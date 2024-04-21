using Godot;
using System;

public partial class Global : Node
{
	public int cockroachTotalScore { get; set; } = 0;
	public int parkingTotalScore { get; set; } = 0;
	public int typerTotalScore { get; set; } = 0;
	public int cockroachScore { get; set; } = 0;
	public int parkingScore { get; set; } = 0;
	public int typerScore { get; set; } = 0;

	public void CurrentScore()
	{
		string rez = string.Format("Cockroach: {0}\nParking: {1}\nTyper: {2}\nTotal: {3}",
			cockroachScore, parkingScore, typerScore, Sum());
		Console.WriteLine(rez);
	}
	public int Sum()
	{
		return cockroachTotalScore + parkingTotalScore + typerTotalScore;
	}

}
