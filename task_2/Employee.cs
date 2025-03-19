namespace task_2
{
    abstract class Employee
    {
        public string Name { get; private set; }

        protected Employee(string name)
        {
            this.Name = name;
        }

        public abstract void Work();
    }
}
