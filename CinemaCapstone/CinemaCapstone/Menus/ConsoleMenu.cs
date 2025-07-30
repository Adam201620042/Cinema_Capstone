using System.Text;

namespace Capstone.Menus
{
	/// <summary>
	/// Represents an abstract base class for a console menu.
	/// Inherits from <see cref="MenuItem"/> and contains a list of menu items.
	/// </summary>
	internal abstract class ConsoleMenu : MenuItem
	{
		/// <summary>
		/// A list of menu items contained in this console menu.
		/// </summary>
		protected List<MenuItem> _menuItems = new List<MenuItem>();

		/// <summary>
		/// Gets or sets a value indicating whether the menu is active.
		/// This is toggled by the exit menu item, which allows thee user to exit the menu
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// Derived classes should override CreateMenu to add menu items to _menuItems.
		/// </summary>
		public abstract void CreateMenu();

		/// <summary>
		/// Executes the action associated with selecting the console menu.
		/// </summary>
		public override void Select()
		{
			IsActive = true;
			do
			{
				CreateMenu();
				string output = $"{MenuText()}{Environment.NewLine}";
				int selection = ConsoleHelpers.GetIntegerInRange(1, _menuItems.Count, this.ToString()) - 1;
				_menuItems[selection].Select();
			} while (IsActive);
		}

		/// <summary>
		/// Returns a string that represents the current console menu.
		/// </summary>
		/// <returns>A string representing the menu text and its items.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(MenuText());
			for (int i = 0; i < _menuItems.Count; i++)
			{
				sb.AppendLine($"{i + 1}. {_menuItems[i].MenuText()}");
			}
			return sb.ToString();
		}
	}
}
