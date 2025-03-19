namespace task_2
{
    class Manager : Employee
    {
        public string Department { get; set; }

        private double _bonus;

        public double Bonus
        {
            get => _bonus;
            private set
            {
                if (value >= 0)
                {
                    _bonus = value;
                }
            }
        }

        public Manager(string name, string department)
            : base(name)
        {
            this.Department = department;
            this._bonus = CalculateBonus();
        }

        public Manager(string name)
            : base(name)
        {
            this.Department = "Unknown";
            this._bonus = CalculateBonus();
        }

        public override void Work()
        {
            Console.WriteLine($"{this.Name} is managing....");
        }

        private static double CalculateBonus()
        {
            return new Random().Next(1000, 5000); // Рандомный бонус
        }
    }
}
