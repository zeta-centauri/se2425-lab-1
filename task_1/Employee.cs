namespace task_1
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
