using System;
using System.Collections.Generic;

using ToDoClass;

namespace TodoManagerClass
{
    class TodoManager
    {
        static List<ToDo> todos = new List<ToDo>();
        static void Main()
        {
            Console.WriteLine("TodoManager\n" +
                              "To view the todo list type 'view'\n" +
                              "To add a new todo type 'add'\n" +
                              "To leave type 'close'\n");
            string action = Console.ReadLine();

            while (action != "close")
            {
                switch (action)
                {
                    case "view": printList(); break;
                    case "add": addItem(); break;
                    default: Console.WriteLine("Unknown command!\n" +
                                               "To view the todo list type 'view'\n" +
                                               "To add a new todo type 'add'\n" +
                                               "To leave type 'close'\n");break;
                }
                Console.WriteLine("To view the todo list type 'view'\n" +
                                  "To add a new todo type 'add'\n" +
                                  "To leave type 'close'\n");
                action = Console.ReadLine();
            }
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
            Console.WriteLine("ToDo added successfully!");
        }

        static void printList()
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
