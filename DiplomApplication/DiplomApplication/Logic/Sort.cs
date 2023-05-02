namespace DiplomApplication.Logic
{
	static public class Sort
	{


		static public string BubbleSort(int[] array)
		{

			/*var len = array.Length;
			string sort = "";
			sort = sort + string.Join(" ", array) + "\n";
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
		
			return sort;*/
			return "1";
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
	}
}
