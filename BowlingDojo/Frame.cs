namespace BowlingDojo;

internal class Frame
{
	private readonly List<int> _rolls = new();

	public Frame? Previous { get; init; }
	public Frame? Next { get; set; }

	private bool IsStrike => FirstRoll == 10;
	private bool IsSpare => !IsStrike && FirstRoll + SecondRoll == 10;

	public bool IsFull
	{
		get
		{
			if (IsStrike)
			{
				return _rolls.Count >= 1;
			}
			return _rolls.Count >= 2;

		}
	}

	private int FrameCount => (Previous?.FrameCount ?? 0) + 1;
	private int FirstRoll => _rolls.FirstOrDefault();
	private int SecondRoll => _rolls.Skip(1).FirstOrDefault();

	public int Score
	{
		get
		{
			if (FrameCount > 10)
				return Previous!.Score;

			var bonus = 0;
			if (IsStrike)
				bonus = CalculateStrikeBonus();
			else if (IsSpare)
				bonus = CalculateSpareBonus();

			return FirstRoll + SecondRoll + bonus + (Previous?.Score ?? 0);
		}
	}

	public void AddRoll(int pins)
	{
		_rolls.Add(pins);
	}

	private int CalculateSpareBonus()
	{
		return Next?.FirstRoll ?? 0;
	}

	private int CalculateStrikeBonus()
	{
		var bonus = Next?.FirstRoll ?? 0;
		if (Next is { IsStrike: true })
			bonus += Next?.Next?.FirstRoll ?? 0;
		else
			bonus += Next?.SecondRoll ?? 0;

		return bonus;
	}

}