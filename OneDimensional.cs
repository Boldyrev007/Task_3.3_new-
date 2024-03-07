using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace fpgiuh
{
    public sealed class OneDimensional : BaseArray, IOneDimensionalArray
    {
        private int[] array;

        public OneDimensional( bool choice) 
        {
            Create(choice);
        }

        protected override void fill_RandomArray()
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-150, 150);
            }
        }

        protected override void fillArray_by_User()
        {
            for (int i = 0; i < array.Length; i++)
            {
               array[i] = int.Parse(Console.ReadLine());
                
            }
        }

        public override decimal Average_Value()
        {
            Console.WriteLine("\nЗадание 1");
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                counter += array[i];
            }
            return counter / array.Length;
        }

        public void over_one_hundred()
        {
            Console.WriteLine("\nЗадание 2");
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) < 100)
                {
                    counter += 1;
                }
            }
            int[] new_Array = new int[counter];
            int x = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) < 100)
                {
                    new_Array[x] = array[i];
                    x++;
                }
            }
            foreach (var item in new_Array)
            {
                Console.WriteLine(item);
            }
        }
        
        public override void Create(bool choice)
        {
            // input length here
            Console.WriteLine("Введите длину массива: ");
            int length = Convert.ToInt32(Console.ReadLine());
            array = new int[length];
            base.Create(choice);
        }

        void IOneDimensionalArray.without_repeats()
        {
            Console.WriteLine("\nЗадание 3");
            int newArrayLength = array.Length;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[i] == array[j] && i != j)
                    {
                        newArrayLength--;
                        break;
                    }
                }
            }
            int[] newArray = new int[newArrayLength];
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = int.MinValue;
            }
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (!Exists(array[i], newArray))
                {
                    newArray[counter] = array[i];
                    counter++;
                }
            }
        }

        private static bool Exists(int value, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        public override void Print()
        {
            foreach (var element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}

