using System.Dynamic;

namespace BowlingDojo;

public class Game
{
	private Frame _lastFrame = new();

	public int Score()
	{
		return _lastFrame.Score;
	}

	public void Roll(int pins)
	{
		if (_lastFrame.IsFull)
		{
			var frame = new Frame { Previous = _lastFrame };
			_lastFrame.Next = frame;
			_lastFrame = frame;
		}

		_lastFrame.AddRoll(pins);
	}
}