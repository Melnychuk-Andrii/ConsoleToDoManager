using System;

namespace ToDoClass
{
    class ToDo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Int16 Priority { get; set; }
        public DateTime Deadline { get; set; }
        public bool hasDeadline { get; }

        public ToDo(string nm, string dsc, Int16 pr)
        { Name = nm; Description = dsc; Priority = pr; hasDeadline = false; }
        public ToDo(string nm, string dsc, Int16 pr, DateTime dt)
        { Name = nm; Description = dsc; Priority = pr; Deadline = dt; hasDeadline = true; }

        public override string ToString()
        {
            string res;

            res = Name + "\tPriority: " + Priority.ToString();
            if (hasDeadline)
                res += "\tDeadline: " + Deadline.ToString();
            res += "\n\n";
            res += Description;
            return res;
        }
    }
}
