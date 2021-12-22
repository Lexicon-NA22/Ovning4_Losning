using System;
using System.Linq;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        static void ExamineList()
        {
            var list = new List<string>();
            bool finish = false;
            Console.Clear();

            Console.WriteLine("Examine list:" +
                "\n'+': Add new element to list" +
                "\n'-': Remove element from list" +
                "\n'p': Print entire list" +
                "\n'0': Exit to main menu");

            do
            {
                var input = Console.ReadLine();
                var nav = input[0];
                var value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        AddToList(value, list);
                        break;
                    case '-':
                        RemoveFromList(value, list);
                        break;
                    case 'p':
                        PrintList(list);
                        break;
                    case '0':
                        finish = true;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Please do as you're told\n");
                        break;
                }

            }while (!finish);
        }

        private static void PrintList(List<string> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        private static void RemoveFromList(string value, List<string> list)
        {
            var removalSuccesfull = list.Remove(value);
            if (removalSuccesfull)
            {
                Console.WriteLine($"\"{value}\" has been removed from the list");
                Console.WriteLine($"Current number of elements: {list.Count}");
                Console.WriteLine($"Current capacity of list: {list.Capacity}\n");
            }
            else
            {
                Console.WriteLine($"\"{value}\" not found in list!\n");
            }
        }

        private static void AddToList(string value, List<string> list)
        {
            list.Add(value);
            Console.WriteLine($"\"{value}\" has been added to the list");
            Console.WriteLine($"Current number of elements: {list.Count}");
            Console.WriteLine($"Current capacity of list: {list.Capacity}\n");
        }

        static void ExamineQueue()
        {
            var queue = new Queue<string>();
            bool finish = false;
            Console.Clear();

            Console.WriteLine("Examine queue:" +
                "\n'+': Add new element to queue" +
                "\n'-': Remove element from queue" +
                "\n'p': Print entire queue" +
                "\n'0': Exit to main menu");

            do
            {
                var input = Console.ReadLine();
                var nav = input[0];
                var value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        AddToQueue(value, queue);
                        break;
                    case '-':
                        RemoveFromQueue(queue);
                        break;
                    case 'p':
                        PrintQueue(queue);
                        break;
                    case '0':
                        finish = true;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Please do as you're told\n");
                        break;
                }

            } while (!finish);
        }

        private static void PrintQueue(Queue<string> queue)
        {
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }

        private static void RemoveFromQueue(Queue<string> queue)
        {
            if (queue.Count > 0)
            {
                var element = queue.Dequeue();
                Console.WriteLine($"\"{element}\" has been removed from queue.\n");
            }
            else
            {
                Console.WriteLine("Queue is empty!");
            }
        }

        private static void AddToQueue(string value, Queue<string> queue)
        {

                queue.Enqueue(value);
                Console.WriteLine($"\"{value}\" has been added to the queue.\n");

        }

        static void ExamineStack()
        {
            ReverseText();
        }

        static void ReverseText()
        {
            Console.WriteLine("Give me something to reverse!");
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            foreach (var item in input)
            {
                stack.Push(item);
            }

            foreach (var item in stack)
            {
                Console.Write(item);
            }

            Console.WriteLine("\n");
        }

        static void CheckParanthesis()
        {
            Console.WriteLine("**Check Parantehsis**" +
                "\n Enter a string to check or enter '0' to go back to main menu.");
            
            var finished = false;

            do
            {
                var input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        finished = true;
                        break;
                    default:
                        Console.WriteLine($"Wellformated: {IsWellFormated(input)}");
                        break;
                }
                

            } while (!finished);
            
                
        }

        private static bool IsWellFormated(string? input)
        {

            Dictionary<char,char> dict = new Dictionary<char, char>
            {
                {'{','}'},
                {'(',')'},
                {'[',']'},
                {'<','>'}
            };

            var stack = new Stack<char>();

            // [}, ((, }  

            foreach (var c in input)
            {
                if (stack.Count == 0 && dict.ContainsValue(c)) return false;
                if (dict.ContainsValue(c) && dict[stack.Pop()] != c) return false;
                if (dict.ContainsKey(c)) stack.Push(c);
            }

            return stack.Count == 0;
        }
    }
}

