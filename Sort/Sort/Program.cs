using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static List<int> mainList = new List<int>();
        static List<int> copyList = new List<int>();
        static bool running;

        public static void showCommand(int flag)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---------------- [Список допустимых команд] ----------------");
            Console.ForegroundColor = ConsoleColor.White;
            if (flag == 1)
            {
                Console.WriteLine("ADD          -> добавить еще 1 элемент в основной лист");
                Console.WriteLine("SHOW         -> показать лист");
                Console.WriteLine("DELETE       -> удалить элемент по индексу в основном листе");
                Console.WriteLine("EDIT         -> изменить элемент по индексу в основном листе");
                Console.WriteLine("SORT         -> сортировать лист (создает копию листа)");
                Console.WriteLine("REVERSE      -> реверс основного листа");
                Console.WriteLine("COMMAND      -> список команд");
                Console.WriteLine("EXIT         -> выйти из программы");
            }
            else if (flag == 2)
            {
                Console.WriteLine("MAIN LIST    -> показать основной лист");
                Console.WriteLine("COPY LIST    -> показать скопированный лист");
            }
            else if (flag == 3)
            {
                Console.WriteLine("BUBBLE       -> сортировка: пузырьком");
                Console.WriteLine("SHAKER       -> сортировка: перемешиванием");
                Console.WriteLine("SELECTION    -> сортировка: вибором");
                Console.WriteLine("QUICK        -> сортировка: быстрая");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static public void addNum() // добавление элемента в конец листа
        {
            int t;

            try
            {
                Console.Write("Введите число, которое хотите добавить: ");
                t = Int32.Parse(Console.ReadLine());
                mainList.Add(t);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Что то пошло не так при добавлении элемента в лист. \nОригинальная ошибка: " + ex);
            }
        }

        static public void showList(int flag)
        {
            if (flag == 1)
            {
                Console.Write("Основной: ");
                for (int i = 0; i < mainList.Count; i++)
                {
                    if (i == mainList.Count - 1)
                        Console.Write(mainList[i]);
                    else
                        Console.Write(mainList[i] + " ");
                }
            }
            else if (flag == 2)
            {
                Console.Write("Скопированный: ");
                for (int i = 0; i < copyList.Count; i++)
                {
                    if (i == copyList.Count - 1)
                        Console.Write(copyList[i]);
                    else
                        Console.Write(copyList[i] + " ");
                }
                if (copyList.Count == 0)
                    Console.Write("Пустой лист.");
            }
            Console.WriteLine();
        }

        static public void deleteNum()
        {
            int index;

            try
            {
                Console.Write("Введите индекс элемента, который хотите удалить: ");
                Console.ForegroundColor = ConsoleColor.Green;
                index = Int32.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;

                if (index >= mainList.Count)
                    Console.WriteLine("Индекс больше размера листа!");
                else if (index <= -1)
                    Console.WriteLine("Индекс меньше 0!");
                else
                    mainList.RemoveAt(index);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Что то пошло не так при удалении элемента из листа. \nОригинальная ошибка: " + ex);
            }
        }

        static public void editNum()
        {
            int index;
            int newNum;

            try
            {
                Console.Write("Введите индекс элемента, который хотите изменить: ");
                Console.ForegroundColor = ConsoleColor.Green;
                index = Int32.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;

                if (index >= mainList.Count)
                    Console.WriteLine("Индекс больше размера листа!");
                else if (index <= -1)
                    Console.WriteLine("Индекс меньше 0!");
                else
                {
                    Console.Write("Введите новое число: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    newNum = Int32.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;
                    mainList[index] = newNum;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Что то пошло не так при удалении элемента из листа. \nОригинальная ошибка: " + ex);
            }
        }

        static public void reverseList()
        {
            int tmp;

            try
            {
                for (int i = 0; i < mainList.Count / 2; i++)
                {
                    tmp = mainList[i];
                    mainList[i] = mainList[mainList.Count - i - 1];
                    mainList[mainList.Count - i - 1] = tmp;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Что то пошло не так при реверсе листа. \nОригинальная ошибка: " + ex);
            }
        }

        static public void findCommand(string command)
        {
            string temp = null;

            switch (command)
            {
                case "ADD":
                    addNum();
                    break;
                case "SHOW":
                    showCommand(2);
                    try
                    {
                        Console.Write("Какой из листов Вы хотите посмотреть: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        temp = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        switch (temp)
                        {
                            case "MAIN LIST":
                                showList(1);
                                break;
                            case "COPY LIST":
                                showList(2);
                                break;
                            default:
                                Console.WriteLine("Команда не найдена.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при вызове функции SHOW. \nОригинальная ошибка: " + ex);
                    }
                    break;
                case "DELETE":
                    deleteNum();
                    break;
                case "EDIT":
                    editNum();
                    break;
                case "SORT":
                    showCommand(3);
                    try
                    {
                        int[] tmp = new int[mainList.Count];

                        Console.Write("Какую сортировку Вы хотите применить: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        temp = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;

                        copyList.Clear();
                        mainList.CopyTo(tmp);
                        copyList = tmp.ToList<int>();

                        //Console.WriteLine("size: " + copyList.Count + " [0]: " + copyList[0]);

                        switch (temp)
                        {
                            case "BUBBLE":
                                sortBubble();
                                Console.WriteLine("Результат был записан в copyList");
                                break;
                            case "SHAKER":
                                sortShaker();
                                Console.WriteLine("Результат был записан в copyList");
                                break;
                            case "SELECTION":
                                sortSelection();
                                Console.WriteLine("Результат был записан в copyList");
                                break;
                            case "QUICK":
                                //copyList = mainList;
                                sortQuick(copyList, 0, copyList.Count - 1);
                                Console.WriteLine("Результат был записан в copyList");
                                break;
                            default:
                                Console.WriteLine("Команда не найдена.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при вызове функции SORT. \nОригинальная ошибка: " + ex);
                    }
                    break;
                case "REVERSE":
                    reverseList();
                    break;
                case "EXIT":
                    running = false;
                    break;
                case "COMMAND":
                    showCommand(1);
                    break;
                default:
                    Console.Write("Команда не найдена. \nЧтобы посмотреть все команды, напишите: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("COMMAND");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        static public void sortBubble()
        {
            //copyList = mainList;
            int t;

            for (int i = 0; i < copyList.Count; i++)
            {
                for (int j = 0; j < copyList.Count; j++)
                {
                    if (copyList[i] < copyList[j])
                    {
                        t = copyList[i];
                        copyList[i] = copyList[j];
                        copyList[j] = t;
                    }
                }
            }
        }

        static public void sortShaker()
        {
            //copyList = mainList;

            int l = 0;
            int r = copyList.Count - 1;
            int tmp;

            while (l <= r)
            {
                for (int i = l; i < r; i++)
                {
                    if (copyList[i] > copyList[i + 1])
                    {
                        tmp = copyList[i];
                        copyList[i] = copyList[i + 1];
                        copyList[i + 1] = tmp;
                    }
                }
                r--;

                for (int j = r; j > l; j--)
                {
                    if (copyList[j - 1] > copyList[j])
                    {
                        tmp = copyList[j - 1];
                        copyList[j - 1] = copyList[j];
                        copyList[j] = tmp;
                    }
                }
                l++;
            }
        }

        static private int minIndex(int start)
        {
            int smallest = start;

            for (int i = start; i < copyList.Count; i++)
                if (copyList[i] < copyList[smallest])
                    smallest = i;

            if (smallest == start)
                return -1;

            return smallest;
        }

        static public void sortSelection()
        {
            //copyList = mainList;

            int smallestIndex = 0;
            int tmp;

            for (int i = 0; i < copyList.Count; i++)
            {
                smallestIndex = minIndex(i);
                if (smallestIndex != -1)
                {
                    tmp = copyList[i];
                    copyList[i] = copyList[smallestIndex];
                    copyList[smallestIndex] = tmp;
                }
            }
        }

        static Random rand = new Random();

        static private void swap(List<int> list, int l, int r)
        {
            if (l != r)
            {
                int tmp = list[l];
                list[l] = list[r];
                list[r] = tmp;
            }
        }

        static private int part(List<int> t, int l, int r, int rIndex)
        {
            int value = t[rIndex];

            swap(t, rIndex, r);

            int newIndex = l;

            for (int i = l; i < r; i++)
            {
                if (t[i] < value)
                {
                    swap(t, i, newIndex);
                    newIndex += 1;
                }
            }

            swap(t, newIndex, r);
            return newIndex;
        }

        static public void sortQuick(List<int> tmp, int left, int right)
        {
            if (left < right)
            {
                int randIndex = rand.Next(left, right);
                int b = part(tmp, left, right, randIndex);

                sortQuick(tmp, left, b - 1);
                sortQuick(tmp, b + 1, right);
            }
        }

        static void Main(string[] args)
        {
            int n = -1;
            running = true;
            string command = null;

            try //на тот случай, если на входе будут невалидные данные
            {
                Console.Write("Введите кол-во элементов листа: ");
                Console.ForegroundColor = ConsoleColor.Green;
                n = Int32.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                if (n < 2)
                    Console.WriteLine("Должно быть минимум 2 элемента. Попробуйте еще раз.");
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("[" + i + "]: ");
                        mainList.Add(Int32.Parse(Console.ReadLine()));
                    }
                    showCommand(1); //вывод всех команд, которые можно использовать

                    while (running) //цикл работы программы
                    {
                        Console.Write("Введите команду: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        command = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        findCommand(command);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Что то пошло не так. Попробуйте еще раз\nОригинальная ошибка: " + ex);
                
                Console.WriteLine("\nНажмите любую кнопку, чтобы закрыть окно...");
                Console.ReadKey();
            }
        }
    }
}
