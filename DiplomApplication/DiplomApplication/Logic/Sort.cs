namespace DiplomApplication.Logic
{
	static public class Sort
	{
		static public string BubbleSort(int[] array)
		{

			var len = array.Length;
			string sort = string.Join(" ", array) + "\n";
			for (var i = 1; i < len; i++)
			{
				for (var j = 0; j < len - i; j++)
				{
					if (array[j] > array[j + 1])
					{
						var temp = array[j];
						array[j] = array[j + 1];
						array[j + 1] = temp;
						sort = sort + string.Join(" ", array) + "\n"; 
					}
				}
				
			}
		
			return sort;
		}

		static public string SelectionSort(int[] array)
		{
			return "2";
		}

		static public string InsertionSort(int[] array)
		{
			return "3";
		}
		static public string ShakerSort(int[] array)
		{
			return "4";
		}
		static public string ShellSort(int[] array)
		{
			return "5";
		}
		static public string QuickSort(int[] array)
		{
			return "6";
		}
		static public string SortPoAlg(int[] array, string typesort)
		{
			switch (typesort)
			{
				case "Сортировка пузырьком.": return BubbleSort(array);
				case "Сортировка выбором.": return SelectionSort(array);
				case "Сортировка вставками.": return InsertionSort(array);
				case "Шейкерная сортировка.": return ShakerSort(array);
				case "Сортировка Шелла.": return ShellSort(array);
				case "Быстрая сортировка.":return QuickSort(array);
					default: return "Произошла низвестная ошибка";
			}
		}
		static public bool CheckSort(string strStudent, string strProgram)
		{
			return true;
		}

		static public string GetStrToSort(int i = 6)
		{
			string str = "";
			Random rnd = new Random();
			int value;
			for (var x = 0; x < i; x++)
			{
				value = rnd.Next(-99, 99);
				if (x == i - 1)
					str = str + value;
				else
					str = str + value + " ";
			}
			return str;
		}
	}
}
