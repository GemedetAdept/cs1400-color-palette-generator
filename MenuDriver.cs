namespace menudriver {
	public class MenuDriver {

		List<string> menuOptions = new List<string>();

		int activeItem = 0;
		public bool menuLoop = true;
		public int selectedItem = -1;

		public void AddOptions(string[] options) {

			for (int i=0; i < options.Length; i++) {

				menuOptions.Add(options[i]);
			}
		}

		public void DisplayMenu() {

			string selector = "> ";

			for (int i=0; i < menuOptions.Count; i++) {

				string option = "";

				if (i == activeItem) {
					option += selector;
				}

				option += menuOptions[i];
				Console.WriteLine(option);
			}
		}

		public void SetMenuCursor() {

			selectedItem = -1;

			int optionsCount = menuOptions.Count;
			var keyInput = Console.ReadKey(false);

			if (keyInput.Key == ConsoleKey.UpArrow && activeItem > 0) {

				activeItem -= 1;
			}

			else if (keyInput.Key == ConsoleKey.DownArrow && activeItem < optionsCount-1) {

				activeItem += 1;
			}

			else if (keyInput.Key == ConsoleKey.Enter) {
				
				selectedItem = activeItem;
			}
		}
	}
}