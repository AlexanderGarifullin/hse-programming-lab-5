using System;

namespace lab5
{
    class Program
    {
        static int MAXLENGHT = 10;
        static int MINLENGHT = 1;
        static int MAXVALUE = 10;
        static int MINVALUE = -10;
        static Random rnd = new Random();
        static void FirstMenu()
        {
            Console.WriteLine("1. Работа с одномерными массивами" +
                "\n2. Работа с двумерными массивами" +
                "\n3. Работа с рваными массивами" +
                "\n4. Выход");
        }
        static void CreateMenu()
        {
            Console.WriteLine("1. Cоздать массив вручную" +
                "\n2. Создать массив с помощью ДСЧ");
        }
        static void ArrayMenu()
        {
            Console.WriteLine("1. Создать массив" +
                "\n2. Напечатать массив" + "\n3. Удалить элемент с заданным номером" + "\n4. Назад");
        }
        static void MatrMenu()
        {
            Console.WriteLine("1. Создать массив" +
                "\n2. Напечатать массив" + "\n3. Добавить строку в начало матрицы" + "\n4. Назад");
        }
        static void JagMenu()
        {
            Console.WriteLine("1. Создать массив" +
                "\n2. Напечатать массив" + "\n3. Удалить К строк, начиная с номера N" + "\n4. Назад");
        }
        #region Ввод чисел
        /// <summary>
        /// Ввод целого числа из заданного диапазона
        /// </summary>
        /// <param name="min">Левая граница диапазона</param>
        /// <param name="max">Правая граница диапазона</param>
        /// <param name="msg">Приглашение для ввода</param>
        /// <returns></returns>
        static int GetInt(int min, int max, string msg = "")
        {
            int number;
            bool isRead;
            do
            {
                Console.WriteLine(msg);
                isRead = int.TryParse(Console.ReadLine(), out number);
                if (!isRead)
                {
                    Console.WriteLine("Ошибка! Не правильно введено целое число!");
                }
                else
                {
                    if (number < min || number > max)
                    {
                        Console.WriteLine("Ошибка! Число не попадает в заданный диапазон!");
                        isRead = false;
                    }
                }
            } while (!isRead);
            return number;
        }
        #endregion
        #region Двумерные массивы
        /// <summary>
        /// Ввод количества строк
        /// </summary>
        /// <returns></returns>
        static int GiveNumberStr()
        {
            int chooseWayFilling = GetInt(1, 2, $"Выберите, сколько будет строк (от {MINLENGHT} до {MAXLENGHT}):" +
                $"\n1. Ввести число самому" + "\n2. Случайное число"); ;
            if (chooseWayFilling == 1)
                return GetInt(MINLENGHT, MAXLENGHT, $"Введите количество строк (от {MINLENGHT} до {MAXLENGHT})");
            return rnd.Next(MINLENGHT, MAXLENGHT);
        }
        /// <summary>
        /// Ввод количества столбцов в матрице
        /// </summary>
        /// <returns></returns>
        static int GiveNumberCol()
        {
            int chooseWayFilling = GetInt(1, 2, $"Выберите, сколько будет столбцов в матрице:" +
               $"\n1. Ввести число самому (от {MINLENGHT} до {MAXVALUE})" + "\n2. Случайное число"); ;
            if (chooseWayFilling == 1)
                return GetInt(MINLENGHT, MAXLENGHT, $"Введите количество столбцов в матрице (от {MINLENGHT} до {MAXLENGHT})");
            return rnd.Next(MINLENGHT, MAXLENGHT);
        }
        /// <summary>
        /// Создание матрицы с помощью ДСЧ
        /// </summary>
        /// <returns></returns>
        static int[,] CreateRandomMatr()
        {
            int str = GiveNumberStr();
            int col = GiveNumberCol();
            int[,] matr = new int[str, col];
            for (int i = 0; i < str; i++)
                for (int j = 0; j < col; j++)
                    matr[i, j] = rnd.Next(MINVALUE, MAXVALUE);
            return matr;
        }
        /// <summary>
        /// Создание матрицы вручную
        /// </summary>
        /// <returns></returns>
        static int[,] CreateMatr()
        {
            int str = GiveNumberStr();
            int col = GiveNumberCol();
            int[,] matr = new int[str, col];
            for (int i = 0; i < str; i++)
                for (int j = 0; j < col; j++)
                    matr[i, j] = GetInt(MINVALUE, MAXVALUE, $"Введите значение массива в {i + 1} строке, в {j + 1} столбце");
            return matr;
        }
        /// <summary>
        /// Проверка двумерного массива на пустоту
        /// </summary>
        /// <param name="matr">Массив, который надо проверить на пустоту</param>
        /// <returns></returns>
        static bool IsEmpty(int[,] matr)
        {
            if (matr == null || matr.Length == 0)
                return true;
            return false;
        }
        /// <summary>
        /// Вывод двумерного массива
        /// </summary>
        /// <param name="matr">Выводимая матрица</param>
        /// <param name="msg">Сообщение при выводе</param>
        static void PrintMatr(int[,] matr, string msg = "")
        {
            Console.WriteLine(msg);
            if (IsEmpty(matr))
            {
                Console.WriteLine("Матрица пустая");
                return;
            }
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    Console.Write($"{matr[i, j],4}");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Добавление строчки в начало матрицы
        /// </summary>
        /// <param name="matr">Матрица, в которую добавят строчку в начало</param>
        static void AddStrStart(ref int[,] matr)
        {
            Console.WriteLine("Добавление строчки в начало двумерного массива");
            int[,] temp = new int[matr.GetLength(0) + 1, matr.GetLength(1)];
            for (int i = 1; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    temp[i, j] = matr[i - 1, j];
                }
            }
            int chooseWayFilling = GetInt(1, 2, $"Выберите, как заполнить новую строку числами от {MINVALUE} до {MAXVALUE}:" +
                "\n1. Ввести числа самому" + "\n2. Случайными числами");
            for (int i = 0; i < temp.GetLength(1); i++)
            {
                if (chooseWayFilling == 1)
                    temp[0, i] = GetInt(MINVALUE, MAXVALUE, $"Введите {i + 1} элемент новой строки");
                else
                    temp[0, i] = rnd.Next(MINVALUE, MAXVALUE);
            }
            matr = temp;
        }
        #endregion
        #region Рваные массивы
        /// <summary>
        /// Ввод количества элементов в строке
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        static int GiveNumberCol(int i)
        {
            int chooseWayFilling = GetInt(1, 2, $"Выберите, сколько будет элементов в {i + 1} строке:" +
               $"\n1. Ввести число самому (от {MINLENGHT} до {MAXVALUE})" + "\n2. Случайное число"); ;
            if (chooseWayFilling == 1)
                return GetInt(MINLENGHT, MAXLENGHT, $"Введите количество элементов в {i + 1} строке (от {MINLENGHT} до {MAXLENGHT})");
            return rnd.Next(MINLENGHT, MAXLENGHT);
        }
        /// <summary>
        /// Создание рваного массива с помощью ДСЧ
        /// </summary>
        /// <returns></returns>
        static int[][] CreateRandomMas()
        {
            int str = GiveNumberStr(); ;
            int col;
            int[][] mas = new int[str][];
            for (int i = 0; i < str; i++)
            {
                col = GiveNumberCol(i);
                mas[i] = new int[col];
                for (int j = 0; j < (col); j++)
                    mas[i][j] = rnd.Next(MINVALUE, MAXVALUE);
            }
            return mas;
        }
        /// <summary>
        /// Создание рваного массива вручную
        /// </summary>
        /// <returns></returns>
        static int[][] CreateMas()
        {
            int str = GiveNumberStr(); ;
            int col;
            int[][] mas = new int[str][];
            for (int i = 0; i < str; i++)
            {
                col = GiveNumberCol(i);
                mas[i] = new int[col];
                for (int j = 0; j < (col); j++)
                    mas[i][j] = GetInt(MINVALUE, MAXVALUE, $"Введите значение массива в {i + 1} строке, в {j + 1} столбце");
            }
            return mas;
        }
        /// <summary>
        /// Проверка рваного массива на пустоту
        /// </summary>
        /// <param name="mas">Рваный массив, который надо проверить на пустоту</param>
        /// <returns></returns>
        static bool IsEmpty(int[][] mas)
        {
            if (mas == null || mas.Length == 0)
                return true;
            return false;
        }
        /// <summary>
        /// Вывод рваного массива
        /// </summary>
        /// <param name="mas">Массив, который надо вывести</param>
        /// <param name="msg">Сообщение при выводе</param>
        static void PrintMas(int[][] mas, string msg = "")
        {
            Console.WriteLine(msg);
            if (IsEmpty(mas))
            {
                Console.WriteLine("Матрица пустая");
                return;
            }
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    Console.Write($"{mas[i][j],4}");
                }
                Console.WriteLine();
            }
        }

        static int CountHelpLenght(int[][] JagArray, int n, int k)
        {
            return JagArray.Length - n - k + 1;
        }
        /// <summary>
        /// Вычисление количества строк в рваном массиве, которое останется после удаления k строк, начиная с n-ой строки
        /// </summary>
        /// <param name="JagArray">Рваный массив, предназначенный для вычислений</param>
        /// <param name="n">Номер строки, с которой удаляем</param>
        /// <param name="k">Количество удаляемых строк</param>
        /// <returns></returns>
        static int CountLenght(int[][] JagArray, int n, int k)
        {
            int helpLenght = CountHelpLenght(JagArray, n, k);
            int newLenght = n - 1;
            if (helpLenght > 0)
                newLenght += helpLenght;
            return newLenght;
        }
        /// <summary>
        /// Удаление k строк начиная с n-ой в рванном массиве 
        /// </summary>
        /// <param name="JagArray">Рваный массив, где удаляем строки</param>
        static void DeleteStrJaggedArray(ref int[][] JagArray)
        {
            Console.WriteLine("Удаление строк из рваного массива");
            int n = GetInt(MINLENGHT, JagArray.Length, $"Введите, начиная с какой строки удалять элементы (от {MINLENGHT} до {JagArray.Length})");
            int k = GetInt(MINLENGHT, MAXLENGHT, $"Введите, сколько строк вы хотите удалить (от {MINLENGHT} до {MAXLENGHT})");

            int[][] temp = new int[CountLenght(JagArray, n, k)][];
            for (int i = 0; i < n - 1; i++)
            {
                temp[i] = new int[JagArray[i].Length];
                for (int j = 0; j < JagArray[i].Length; j++)
                {
                    temp[i][j] = JagArray[i][j];
                }
            }
            int AddStrStart = CountHelpLenght(JagArray, n, k);
            if (AddStrStart > 0)
                for (int i = n - 1; i < temp.Length; i++)
                {
                    temp[i] = new int[JagArray[i + k].Length];
                    for (int j = 0; j < JagArray[i + k].Length; j++)
                    {
                        temp[i][j] = JagArray[i + k][j];
                    }
                }

            JagArray = temp;
        }
        #endregion
        #region Одномерные массивы
        /// <summary>
        /// Ввод длины массива
        /// </summary>
        /// <returns></returns>
        static int GiveLenght()
        {
            int sizeWay = GetInt(1, 2, "Выбертие длину массива:" +
                "\n1.Ввести значение самостоятельно" + "\n2.Присвоить случайное значение");
            if (sizeWay == 1)
                return GetInt(MINLENGHT, MAXLENGHT, $"Введите длину одномерного массива (от {MINLENGHT} до {MAXLENGHT})");
            return rnd.Next(MINLENGHT, MAXLENGHT);
        }
        /// <summary>
        /// Создание одномерного массива с ручным вводом элементов
        /// </summary>
        /// <param name="str">Длина одномерного массива</param>
        /// <returns></returns>
        static int[] CreateArray()
        {
            int str = GiveLenght();
            int[] myArray = new int[str];
            for (int i = 0; i < str; i++)
                myArray[i] = GetInt(MINVALUE, MAXVALUE, $"Введите {i + 1} элемент массива");
            return myArray;
        }
        /// <summary>
        /// Создание случайного одномерного массива
        /// </summary>
        /// <param name="str">Длина одномерного массива</param>
        /// <returns></returns>
        static int[] CreateRandomArray()
        {
            int str = GiveLenght();
            int[] myArray = new int[str];
            for (int i = 0; i < str; i++)
                myArray[i] = rnd.Next(MINVALUE, MAXVALUE);
            return myArray;
        }
        /// <summary>
        /// Проверка одномерного массива на пустоту
        /// </summary>
        /// <param name="mas">Одномерный массив, который надо првоерить на пустоту</param>
        /// <returns></returns>
        static bool IsEmpty(int[] mas)
        {
            if (mas == null || mas.Length == 0)
                return true;
            return false;
        }
        /// <summary>
        /// Вывод одномерного массива
        /// </summary>
        /// <param name="mas">Массив, который надо распечатать</param>
        /// <param name="msg">Сообщение о выводе</param>
        static void PrintArray(int[] mas, string msg = "")
        {
            Console.WriteLine(msg);
            if (IsEmpty(mas))
            {
                Console.WriteLine("Массив пустой");
                return;
            }
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write($"{mas[i],4}");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Удалить элемент с заданным номером
        /// </summary>
        /// <param name="MyArray">Массив, для выполнения функции</param>
        static void DeleteNumberArray(ref int[] MyArray)
        {
            Console.WriteLine("Удаление элемента из одномерного массива");
            if (IsEmpty(MyArray))
            {
                Console.WriteLine("Вам одномерный массив пуст! Невозможно удалить элементы!");
                return;
            }
            int k = GetInt(MINLENGHT, MyArray.Length, $"Введите номер элемента, который хотите удалить:");
            if (MyArray.Length - 1 == 0)
            {
                Console.WriteLine("Ваш массив стал пустым!");
                MyArray = null;
                return;
            }
            int[] temp = new int[MyArray.Length - 1];
            for (int i = 0; i < k - 1; i++)
                temp[i] = MyArray[i];
            for (int i = k - 1; i < temp.Length; i++)
                temp[i] = MyArray[i + 1];
            MyArray = temp;
        }
        #endregion
        static void Main()
        {
            Boolean finish = false, isCreateArray = false, isCreateMatr = false, isCreateJagArray = false;
            int choiceCreate, choiceMenu, arrayMeny;
            int[] MyArray = null;
            int[,] Matr = null;
            int[][] JagArray = null;
            do
            {
                FirstMenu();
                choiceMenu = GetInt(1, 4, "Выберите пункт меню:");
                switch (choiceMenu)
                {
                    case 1://одномерный массив
                        {
                            do
                            {
                                ArrayMenu();
                                arrayMeny = GetInt(1, 4, "Выберите пункт:");
                                switch (arrayMeny)
                                {
                                    case 1://создание массива
                                        {
                                            CreateMenu();
                                            choiceCreate = GetInt(1, 2, "Выберите пункт:");
                                            if (choiceCreate == 1)
                                                MyArray = CreateArray();
                                            else
                                                MyArray = CreateRandomArray();
                                            isCreateArray = true;
                                            break;
                                        }
                                    case 2://печать массива
                                        {
                                            if (isCreateArray)
                                                PrintArray(MyArray);
                                            else
                                                Console.WriteLine("Вы не создали массив");
                                            break;
                                        }
                                    case 3://удаление элемента из массива
                                        {

                                            if (isCreateArray)
                                                if (!IsEmpty(MyArray))
                                                    DeleteNumberArray(ref MyArray);
                                                else
                                                    Console.WriteLine("Массив пуст, нельзя удалить элементы.");
                                            else
                                                Console.WriteLine("Вы не создали массив");
                                            break;
                                        }
                                    case 4://выход 
                                        {
                                            break;
                                        }
                                }
                            } while (arrayMeny != 4);
                            break;
                        }
                    case 2://двумерный массив
                        {
                            do
                            {
                                MatrMenu();
                                arrayMeny = GetInt(1, 4, "Выберите пункт:");
                                switch (arrayMeny)
                                {
                                    case 1://создание матрицы
                                        {
                                            CreateMenu();
                                            choiceCreate = GetInt(1, 2, "Выберите пункт:");
                                            if (choiceCreate == 1)
                                                Matr = CreateMatr();
                                            else
                                                Matr = CreateRandomMatr();
                                            isCreateMatr = true;
                                            break;
                                        }
                                    case 2://печать матрицы
                                        {
                                            if (isCreateMatr)
                                                PrintMatr(Matr);
                                            else
                                                Console.WriteLine("Вы не создали матрицу");
                                            break;
                                        }
                                    case 3://добавление строчки в начало матрицы 
                                        {

                                            if (isCreateMatr)
                                                if (!IsEmpty(Matr))
                                                    AddStrStart(ref Matr);
                                                else
                                                    Console.WriteLine("Матрица пуст, нельзя удалить элементы.");
                                            else
                                                Console.WriteLine("Вы не создали матрицу");
                                            break;
                                        }
                                    case 4://выход 
                                        {
                                            break;
                                        }
                                }
                            } while (arrayMeny != 4);
                            break;
                        }
                    case 3://рваный массив
                        {
                            do
                            {
                                JagMenu();
                                arrayMeny = GetInt(1, 4, "Выберите пункт:");
                                switch (arrayMeny)
                                {
                                    case 1://создание рванного массива
                                        {
                                            CreateMenu();
                                            choiceCreate = GetInt(1, 2, "Выберите пункт:");
                                            if (choiceCreate == 1)
                                                JagArray = CreateMas();
                                            else
                                                JagArray = CreateRandomMas();
                                            isCreateJagArray = true;
                                            break;
                                        }
                                    case 2://печать рванного массива
                                        {
                                            if (isCreateJagArray)
                                                PrintMas(JagArray);
                                            else
                                                Console.WriteLine("Вы не создали рваный массив");
                                            break;
                                        }
                                    case 3:// 
                                        {

                                            if (isCreateJagArray)
                                                if (!IsEmpty(JagArray))
                                                    DeleteStrJaggedArray(ref JagArray);
                                                else
                                                    Console.WriteLine("Рваный массив пуст, нельзя удалить элементы");
                                            else
                                                Console.WriteLine("Вы не создали рваный массив");
                                            break;
                                        }
                                    case 4://выход 
                                        {
                                            break;
                                        }
                                }
                            } while (arrayMeny != 4);
                            break;
                        }
                    case 4://выход
                        {
                            finish = true;
                            break;
                        }
                }
            } while (!finish);
        }
    }
}
