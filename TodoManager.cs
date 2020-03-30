using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

using ToDoClass;

namespace TodoManagerClass
{
    class TodoManager
    {
        static List<ToDo> todos = new List<ToDo>();
        static string functions = "To view the todo list type 'view'\n" +
                                  "To add a new todo type 'add'\n" +
                                  "To leave type 'close'\n" +
                                  "To mark a todo as done type 'done'\n" +
                                  "To delete a todo type 'delete'\n";
        static void Main()
        {
            string text = System.IO.File.ReadAllText(@"D:\Text.json");
            try
            {
                todos = JsonSerializer.Deserialize<List<ToDo>>(text);
            }
            catch { todos = new List<ToDo>(); }

            bool are_deadlines = false;

            foreach (ToDo todo in todos)
            {
                if (todo.Deadline.Date == DateTime.Now.Date)
                {
                    if (are_deadlines == false)
                    {
                        Console.WriteLine("Here are tasks for today:\n\n");
                        are_deadlines = true;
                    }
                    Console.WriteLine("**********************************************************************\n");
                    Console.WriteLine(todo.ToString());
                }
            }

            Console.WriteLine("**********************************************************************\n\n" + functions);
            string action = Console.ReadLine();

            while (action != "close")
            {
                switch (action)
                {
                    case "view": printList(); break;
                    case "add": addItem(); break;
                    case "done": markItem(); break;
                    case "delete": deleteItem(); break;
                    default: Console.WriteLine("Unknown command!\n" + functions); break;
                }
                Console.WriteLine(functions);
                action = Console.ReadLine();
            }
            string restext = JsonSerializer.Serialize(todos);
            System.IO.File.WriteAllText(@"D:\Text.json", restext);
        }

        static void deleteItem()
        {
            Console.WriteLine("Type in the name of the ToDo that you would like to delete:");
            string name = Console.ReadLine();

            todos.Remove(new ToDo(name));
            Console.WriteLine("\nToDo removed!\n");
        }

        static void markItem()
        {
            Console.WriteLine("Type in the name of the ToDo that you would like to mark as done:");
            string name = Console.ReadLine();
            ToDo check = new ToDo(name);
            bool found = false;

            foreach (ToDo todo in todos)
            {
                if (todo.Equals(check))
                {
                    todo.Finished = true;
                    found = true;
                    break;
                }
            }
            if (found)
                Console.WriteLine("\nToDo marked as finished!\n");
            else
                Console.WriteLine("\nNo ToDo with name ${name} found!\n");
        }

        static void addItem()
        {
            DateTime deadline = new DateTime();

            Console.WriteLine("Type in the name of your new ToDo:");
            string name = Console.ReadLine();

            Console.WriteLine("Type in the description of your new ToDo:");
            string description = Console.ReadLine();

            Console.WriteLine("Type in the priority of your new ToDo(1-10):");
            Int16 priority;
            Int16.TryParse(Console.ReadLine(), out priority);

            Console.WriteLine("Does your task have a deadline?(yes/no):");
            string hasD = Console.ReadLine();

            if (hasD == "yes")
            {
                Console.WriteLine("When is the deadline for this ToDo:");
                DateTime.TryParse(Console.ReadLine(), out deadline);
            }

            todos.Add((hasD == "yes") ?
                new ToDo(name, description, priority, deadline) :
                new ToDo(name, description, priority));
            Console.WriteLine("\nToDo added successfully!\n");
        }

        static void printList()
        {
            Console.WriteLine("To sort by priority type 'sorted'\n" +
                              "To view only unfinished todos type 'pending':\n" +
                              "To view only finished todos type 'finished'\n" +
                              "To view all todos press return:\n");
            string res = Console.ReadLine();

            if (res == "sorted")
            {
                todos = todos.OrderByDescending(o => o.Priority).ToList();
                foreach (ToDo todo in todos)
                {
                    Console.WriteLine("**********************************************************************\n");
                    Console.WriteLine(todo.ToString());
                }
                Console.WriteLine("**********************************************************************\n");
            }
            else if(res == "pending")
            {
                foreach (ToDo todo in todos)
                {
                    if (todo.Finished) continue;
                    Console.WriteLine("**********************************************************************\n");
                    Console.WriteLine(todo.ToString());
                }
                Console.WriteLine("**********************************************************************\n");
            }else if (res == "finished")
            {
                foreach (ToDo todo in todos)
                {
                    if (!todo.Finished) continue;
                    Console.WriteLine("**********************************************************************\n");
                    Console.WriteLine(todo.ToString());
                }
                Console.WriteLine("**********************************************************************\n");
            }
            else
            {
                foreach (ToDo todo in todos)
                {
                    Console.WriteLine("**********************************************************************\n");
                    Console.WriteLine(todo.ToString());
                }
                Console.WriteLine("**********************************************************************\n");
            }

        }
    }
}
