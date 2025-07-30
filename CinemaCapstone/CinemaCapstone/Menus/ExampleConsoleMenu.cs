namespace Capstone.Menus
{
	/// <summary>
	/// Represents an example console menu that inherits from <see cref="ConsoleMenu"/>.
	/// This menu allows users to add numbers to a running total stored in an instance of the ExampleSumObject business class.
	/// </summary>
	internal class ExampleConsoleMenu : ConsoleMenu
	{
		private ExampleSumObject _totalSum;

		/// <summary>
		/// Initializes a new instance of the <see cref="ExampleConsoleMenu"/> class with a specified <see cref="ExampleSumObject"/>.
		/// </summary>
		/// <param name="sum">An instance of <see cref="ExampleSumObject"/> that maintains the running total.</param>
		public ExampleConsoleMenu(ExampleSumObject sum)
		{
			_totalSum = sum;
		}

		/// <summary>
		/// Creates the menu by adding menu items.
		/// </summary>
		public override void CreateMenu()
		{
			_menuItems.Clear();
			_menuItems.Add(new ExampleMenuItem(ref _totalSum, 1, 10));
			_menuItems.Add(new ExampleMenuItem(ref _totalSum, 21, 30));
			_menuItems.Add(new ExampleMenuItem(ref _totalSum, 100, 150));
			_menuItems.Add(new ExitMenuItem(this));
		}

		/// <summary>
		/// Gets the text to be displayed for the console menu.
		/// </summary>
		/// <returns>A string representing the menu text and the current total sum.</returns>
		public override string MenuText()
		{
			return $"Example Menu That Adds Numbers {Environment.NewLine}Total : {_totalSum.Total}";
		}
	}
}
