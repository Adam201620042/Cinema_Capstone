namespace Capstone.Menus
{
	/// <summary>
	/// Represents a menu item that allows the user to add a number within a specified range to a running total stored in an instance of ExampleSumObject.
	/// </summary>
	internal class ExampleMenuItem : MenuItem
	{
		/// <summary>
		/// Gets the minimum value (inclusive) for the range.
		/// </summary>
		public int Min { get; private set; }

		/// <summary>
		/// Gets the maximum value (inclusive) for the range.
		/// </summary>
		public int Max { get; private set; }

		private ExampleSumObject _totalSum;

		/// <summary>
		/// Initializes a new instance of the <see cref="ExampleMenuItem"/> class.
		/// </summary>
		/// <param name="total">A reference to the <see cref="ExampleSumObject"/> that maintains the running total.</param>
		/// <param name="min">The minimum value (inclusive) for the range.</param>
		/// <param name="max">The maximum value (inclusive) for the range.</param>
		/// <exception cref="Exception">Thrown when the minimum value is greater than the maximum value.</exception>
		public ExampleMenuItem(ref ExampleSumObject total, int min, int max)
		{
			if (min > max) { throw new Exception($"minimum value {min} cannot be greater than maximum value {max}."); }

			Min = min;
			Max = max;
			_totalSum = total;
		}

		/// <summary>
		/// Gets the text to be displayed for the menu item.
		/// </summary>
		/// <returns>A string representing the menu text.</returns>
		public override string MenuText()
		{
			return $"Get Number In Range {Min} to {Max}";
		}

		/// <summary>
		/// Prompts the user to enter a number within the specified range and adds it to the running total.
		/// </summary>
		public override void Select()
		{
			int valueToAdd = ConsoleHelpers.GetIntegerInRange(Min, Max, "Enter number to add");
			_totalSum.AddToSum(valueToAdd);
		}
	}
}
