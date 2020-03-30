using System;

namespace ToDoClass
{
    class ToDo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Int16 Priority { get; set; }
        public DateTime Deadline { get; set; }
        public bool HasDeadline { get; }
        public bool Finished { get; set; }

        public ToDo() { }
        public ToDo(string nm)
        { Name = nm; }
        public ToDo(string nm, string dsc, Int16 pr)
        { Name = nm; Description = dsc; Priority = pr; HasDeadline = false; Finished = false; }
        public ToDo(string nm, string dsc, Int16 pr, DateTime dt)
        { Name = nm; Description = dsc; Priority = pr; Deadline = dt; HasDeadline = true; Finished = false; }
        public ToDo(string nm, string dsc, Int16 pr, DateTime dt, bool ddl, bool ffl)
        { Name = nm; Description = dsc; Priority = pr; Deadline = dt; HasDeadline = ddl; Finished = ffl; }

        public override string ToString()
        {
            string res = "";

            if (Finished)
                res += "\tDONE\n";

            res += Name + $"\tPriority: {Priority.ToString()}";
            if (HasDeadline)
                res += $"\tDeadline: {Deadline.ToString()}";
            res += "\n\n";
            res += Description;
            return res;
        }

        public override bool Equals(object obj)
        {
            ToDo objAsToDo = obj as ToDo;
            return (this.Name == objAsToDo.Name) ? true : false;
        }

        public static bool operator ==(ToDo left, ToDo right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return object.ReferenceEquals(right, null);
            }
            return left.Equals(right);
        }
        public static bool operator !=(ToDo left, ToDo right)
        {
            return !(left == right);
        }
        public static bool operator <(ToDo left, ToDo right)
        {
            return (left.Priority < right.Priority ? true : false);
        }
        public static bool operator >(ToDo left, ToDo right)
        {
            return (left.Priority > right.Priority ? true : false);
        }
        public override int GetHashCode()
        {
            char[] c = this.Name.ToCharArray();
            return (int)c[0];
        }
    }
}
