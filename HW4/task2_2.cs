using System.Text;
public abstract class Worker
{
    protected string Name;
    protected string Position;
    protected List<string> WorkDay;

    public Worker(string name)
    {
        Name = name;
        WorkDay = new List<string>();
    }

    public void Call()
    {
        Console.WriteLine($"{Name} call");
        WorkDay.Add("Call");
    }

    public void WriteCode()
    {
        Console.WriteLine($"{Name} write code");
        WorkDay.Add("Write code");
    }

    public void Relax()
    {
        Console.WriteLine($"{Name} relax");
        WorkDay.Add("Relax");
    }
    
    public abstract void FillWorkDay();

    public string getName()
    {
        return Name;
    }

    public string getPosition()
    {
        return Position;
    }

    public string getWorkDay()
    {
        if (WorkDay.Count == 0)
        {
            return "Nothing done";
        } else
        {
            var fullWorkDay = new StringBuilder();

            for (int i = 0; i < WorkDay.Count; i++)
            {
                fullWorkDay.Append($"{WorkDay[i]}, ");
            }
            return fullWorkDay.ToString();
        }

    }
}

class Developer : Worker
{
    public Developer(string name) : base(name)
    {
        Position = "Розробник";
    }

    public override void FillWorkDay()
    {
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }
}

class Manager : Worker
{
    private Random _random = new Random();

    public Manager(string name) : base(name)
    {
        Position = "Менеджер";
    }

    public override void FillWorkDay()
    {
        for (int i = 0; i < _random.Next(1, 11); i++)
        {
            Call();
        }

        Relax();

        for (int i = 0; i < _random.Next(1, 6); i++)
        {
            Call();
        }
    }
}

class Team
{
    private string _name;
    private List<Worker> workers;
    public Team(string name)
    {
        _name = name;
        workers = new List<Worker>();
    }

    public void AddWorker(Worker worker)
    {
        workers.Add(worker);
    }

    public void ShowInfo()
    {
        Console.WriteLine("Стисла інформація:");
        Console.WriteLine($"Команда: {_name}");
        Console.WriteLine("Співробітники:");

        if (workers.Count > 0)
        {
            for (int i = 0; i < workers.Count; i++)
            {
                Console.WriteLine(workers[i].getName());
            }
        } else
        {
            Console.WriteLine("No workers");
        }
    }

    public void ShowDetailedInfo()
    {
        Console.WriteLine("Повна інформація:");
        Console.WriteLine($"Команда: {_name}");
        Console.WriteLine("Співробітники:");

        if (workers.Count > 0)
        {
            for (int i = 0; i < workers.Count; i++)
            {
                Console.WriteLine($"{workers[i].getName()} - {workers[i].getPosition()} - {workers[i].getWorkDay()}");
            }   
        } else
        {
            Console.WriteLine("No workers");
        }
    }
}

class Program
{
    static void Main()
    {
        Team team = new Team("Команда пса патрона");
        team.ShowInfo();
        team.ShowDetailedInfo();

        Manager man1 = new Manager("Олег Олегович");
        Developer dev1 = new Developer("Ілля Іванович");
        Developer dev2 = new Developer("Григорій Григорович");

        team.AddWorker(man1);
        team.ShowInfo();
        team.ShowDetailedInfo();
        Console.WriteLine();

        man1.FillWorkDay();
        team.ShowInfo();
        team.ShowDetailedInfo();
        Console.WriteLine();


        team.AddWorker(dev1);
        team.AddWorker(dev2);
        Console.WriteLine();

        dev1.FillWorkDay();
        dev1.FillWorkDay();
        dev2.FillWorkDay();
        Console.WriteLine();

        team.ShowInfo();
        team.ShowDetailedInfo();
        Console.WriteLine();

        team.AddWorker(work);
        team.ShowInfo();
        team.ShowDetailedInfo();
        Console.WriteLine();


    }
}
