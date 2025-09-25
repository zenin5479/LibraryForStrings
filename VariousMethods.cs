using System;
using System.IO;
using System.Text;

namespace LibraryForStrings
{
   public class VariousMethods
   {
      public static string[,] EnterArrayString(string path)
      {
         // Одномерный массив строк
         string[,] arrayString = { };
         // Чтение файла за одну операцию
         string[] allLines = File.ReadAllLines(path);
         if (allLines == null)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            Console.WriteLine("Исходный массив строк");
            int indexLines = 0;
            while (indexLines < allLines.Length)
            {
               allLines[indexLines] = allLines[indexLines];
               Console.WriteLine(allLines[indexLines]);
               indexLines++;
            }

            // Разделение строки на подстроки по пробелу для определения количества столбцов в строке
            int[] sizeArray = new int[allLines.Length];
            char symbolSpace = ' ';
            int countRow = 0;
            int countSymbol = 0;
            int countСolumn = 0;
            while (countRow < allLines.Length)
            {
               string line = allLines[countRow];
               while (countSymbol < line.Length)
               {
                  if (symbolSpace == line[countSymbol])
                  {
                     countСolumn++;
                  }

                  if (countSymbol == line.Length - 1)
                  {
                     countСolumn++;
                  }

                  countSymbol++;
               }

               sizeArray[countRow] = countСolumn;
               //Console.WriteLine("В строке {0} количество столбцов {1}", countRow, countСolumn);
               countСolumn = 0;
               countRow++;
               countSymbol = 0;
            }

            // Поиск максимального элемента массива
            // Cчитаем, что максимум - это первый элемент массива
            int max = sizeArray[0];
            int columns = 0;
            while (columns < sizeArray.Length)
            {
               if (max < sizeArray[columns])
               {
                  max = sizeArray[columns];
               }

               columns++;
            }

            //Console.WriteLine("Максимум равен: {0}", max);

            // Разделение строк на подстроки по пробелу и заполнение двумерного массива строк элементами
            // Измерение массива (0) - количество строк, измерение массива (1) - количество столбцов, равное максимуму
            Console.WriteLine("Двумерный массив строк");
            StringBuilder stringModified = new StringBuilder();
            arrayString = new string[allLines.Length, max];
            char spaceCharacter = ' ';
            int row = 0;
            int column = 0;
            int countCharacter = 0;
            while (row < arrayString.GetLength(0))
            {
               string line = allLines[row];
               while (column < sizeArray[row])
               {
                  while (countCharacter < line.Length)
                  {
                     if (spaceCharacter == line[countCharacter])
                     {
                        string subLine = stringModified.ToString();
                        arrayString[row, column] = subLine;
                        Console.Write(arrayString[row, column] + " ");
                        stringModified.Clear();
                        column++;
                     }
                     else
                     {
                        stringModified.Append(line[countCharacter]);
                     }

                     if (countCharacter == line.Length - 1)
                     {
                        string subLine = stringModified.ToString();
                        arrayString[row, column] = subLine;
                        Console.Write(arrayString[row, column]);
                        stringModified.Clear();
                        column++;
                     }

                     countCharacter++;
                  }

                  countCharacter = 0;
               }

               Console.WriteLine();
               column = 0;
               row++;
            }
         }

         return arrayString;
      }

      public static string[,] ReplaceWord(string[,] arrayString, string oldWord, string newWord)
      {
         // Поиск и замена слов в массиве строк
         int k = 0;
         while (k < arrayString.GetLength(0))
         {
            int l = 0;
            while (l < arrayString.GetLength(1))
            {
               // Сравниваем значения string используя оператор == с учетом регистра
               if (arrayString[k, l] == oldWord)
               {
                  arrayString[k, l] = newWord;
               }

               // Сравниваем значения string используя метод String.CompareOrdinal с учетом регистра и текущей культуры
               //if (string.CompareOrdinal(arrayString[k, l], oldWord) == 0)
               //{
               //   arrayString[k, l] = newWord;
               //}

               // Сравниваем значения string используя метод Compare игнорируя регистр
               //if (string.Compare(arrayString[k, l], oldWord, StringComparison.OrdinalIgnoreCase) == 0)
               //{
               //   arrayString[k, l] = newWord;
               //}

               // Сравниваем значения string используя метод Compare с указанием культуры и опций
               //if (string.Compare(arrayString[k, l], oldWord, CultureInfo.InvariantCulture, CompareOptions.IgnoreNonSpace) == 0)
               //{
               //   arrayString[k, l] = newWord;
               //}

               // Сравниваем значения string используя метод Equals(string) с учетом регистра
               //if (Equals(arrayString[k, l], oldWord))
               //{
               //   arrayString[k, l] = newWord;
               //}

               // Сравниваем значения string используя метод Equals(string) игнорируя регистр
               //if (string.Equals(arrayString[k, l], oldWord, StringComparison.OrdinalIgnoreCase))
               //{
               //   arrayString[k, l] = newWord;
               //}

               l++;
            }

            k++;
         }

         Console.WriteLine("Измененный двумерный массив строк");
         int i = 0;
         while (i < arrayString.GetLength(0))
         {
            int j = 0;
            while (j < arrayString.GetLength(1))
            {
               if (j == arrayString.GetLength(1) - 1)
               {
                  Console.Write(arrayString[i, j]);
               }
               else
               {
                  Console.Write(arrayString[i, j] + " ");
               }

               j++;
            }

            i++;
            Console.WriteLine();
         }

         return arrayString;
      }

      public static string FindWordWithMostVowels(string[,] words)
      {
         // Вариант 1
         char[] vowels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я', 'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я' };
         // Вариант 2
         //char[] vowels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
         string mostWord = "";
         int countMaxVowel = -1;
         int i = 0;
         while (i < words.GetLength(0))
         {
            int j = 0;
            while (j < words.GetLength(1))
            {
               if (words[i, j] != null)
               {
                  //Console.WriteLine(words[i, j]);
                  int countVowel = 0;
                  int k = 0;
                  while (k < words[i, j].Length)
                  {
                     string partString = words[i, j][k].ToString();
                     int l = 0;
                     while (l < vowels.Length)
                     {
                        // Вариант 1
                        // Сравниваем значения string используя оператор == с учетом регистра
                        if (vowels[l].ToString() == partString)
                        {
                           countVowel++;
                        }

                        // Вариант 1
                        // Сравниваем значения string используя метод String.CompareOrdinal с учетом регистра и текущей культуры
                        //if (string.CompareOrdinal(vowels[l].ToString(), partString) == 0)
                        //{
                        //   countVowel++;
                        //}

                        // Вариант 2
                        // Сравниваем значения string используя метод Compare игнорируя регистр
                        //if (string.Compare(vowels[l].ToString(), partString, StringComparison.OrdinalIgnoreCase) == 0)
                        //{
                        //   countVowel++;
                        //}

                        // Вариант 1
                        // Сравниваем значения string используя метод Equals(string) с учетом регистра
                        //if (Equals(vowels[l].ToString(), partString))
                        //{
                        //   countVowel++;
                        //}

                        // Вариант 2
                        // Сравниваем значения string используя метод Equals(string) игнорируя регистр
                        //if (string.Equals(vowels[l].ToString(), partString, StringComparison.OrdinalIgnoreCase))
                        //{
                        //   countVowel++;
                        //}

                        l++;
                     }

                     k++;
                  }

                  //Console.WriteLine(countVowel);

                  if (countVowel > countMaxVowel)
                  {
                     countMaxVowel = countVowel;
                     mostWord = words[i, j];
                  }
               }

               j++;
            }

            i++;
         }

         return mostWord;
      }

      public static string[] OutputArrayString(string[,] inputArray)
      {
         // Объединение двумерного массива string[,]
         // в одномерный массив строк string[] для записи в файл
         Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         string[] arrayString = new string[inputArray.GetLength(0)];
         string subLine = "";
         int row = 0;
         while (row < inputArray.GetLength(0))
         {
            int column = 0;
            while (column < inputArray.GetLength(1))
            {
               if (column == inputArray.GetLength(1) - 1)
               {
                  stringModified.Append(inputArray[row, column]);
                  subLine = stringModified.ToString();
                  arrayString[row] = subLine;
               }
               else
               {
                  stringModified.Append(inputArray[row, column] + " ");
                  subLine = stringModified.ToString();
                  arrayString[row] = subLine;
               }

               column++;
            }

            Console.WriteLine(subLine);
            stringModified.Clear();
            row++;
         }

         return arrayString;
      }

      public static void FileWriteArrayString(string path, string[] arrayString, string nameFile)
      {
         // Запись массива строк в файл
         Console.WriteLine("Запись массива строк в файл {0}", nameFile);
         File.WriteAllLines(path, arrayString);
      }

      public static void FileWriteArrayString(string path, string line)
      {
         // Создание одномерного массива строк string[] для записи в файл строки
         string[] stringArray = { line };
         // Запись массива строк в файл
         File.WriteAllLines(path, stringArray);
      }

      public static void FileAppendStringArray(string path, string line)
      {
         // Создание одномерного массива строк string[] для записи в файл строки
         string[] stringArray = { line };
         // Добавление массива строк в файл
         File.AppendAllLines(path, stringArray);
      }
   }
}