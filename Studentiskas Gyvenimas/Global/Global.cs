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
	public int bookTotalScore { get; set; } = 0;
	public int bookScore { get; set; } = 0;

    public void CurrentScore()
	{
		string rez = string.Format("Cockroach: {0}\nParking: {1}\nTyper: {2}\n Book: {3}\nTotal: {4}",
			cockroachScore, parkingScore, typerScore, bookScore, Sum());
		Console.WriteLine(rez);
	}
	public int Sum()
	{
		return cockroachTotalScore + parkingTotalScore + typerTotalScore + bookTotalScore;
	}

}
