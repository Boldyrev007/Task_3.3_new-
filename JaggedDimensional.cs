using System;
namespace fpgiuh
{
    public sealed class JaggedDimensional : BaseArray, IJaggedArray
    {
        private int rows;
        private int[][] array;

        public JaggedDimensional(bool choice)
        {
            array = new int[rows][];
            Create(choice);
            //PrintArray();
        }

        public override void Create(bool choice)
        {
            // input length here
            Console.WriteLine("Введите длину массива: ");
            int length = Convert.ToInt32(Console.ReadLine());
            array = new int[length][];
            base.Create(choice);
        }

        protected override void fill_RandomArray()
        {
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int columns = rand.Next(1, 6);
                array[i] = new int[columns];
                for (int j = 0; j < columns; j++)
                {
                    array[i][j] = rand.Next(-150, 150);
                }
                Console.WriteLine();
            }
        }

        protected override void fillArray_by_User()
        {
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"элементов в {i + 1} подмассиве: ");
                array[i] = new int[int.Parse(Console.ReadLine())];
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
        }

        public override decimal Average_Value()
        {
            Console.WriteLine("\nЗадание 1");
            int summa = 0;
            int counter = 1;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    summa += array[i][j];
                    counter += 1;
                }
            }
            return summa / counter;
        }

        public void MiddleValueInEachJagged()
        {
            Console.WriteLine("\nЗадание 2");
            for (int i = 0; i < array.Length; i++)
            {
                int summa = 0;
                int counter = 1;
                for (int j = 0; j < array[i].Length; j++)
                {
                    summa += array[i][j];
                    counter += 1;
                }
                try
                {
                    Console.WriteLine(summa / (counter - 1));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Пустой массив: {e.Message}");
                    throw;
                }
            }
        }

        public void JaggedArray_ReplaceEvenValues()
        {
            Console.WriteLine("\nЗадание 3");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] % 2 == 0)
                    {
                        array[i][j] = i * j;
                    }
                }
            }
            Print();
        }

        public override void Print()
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
