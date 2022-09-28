using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace hw10_House
{
    interface IWorker //рабочий
    {
        string Name { get; set;}
        string Post { get; set; }
        
    }
    class Team : IWorker //Бригада строителей
    {
        string Name { get; set; }
        string Post { get; set; }

        public Team()
        {
            Name = "Дом Строй";
            Post = "Строительная бригада";
        }

        public override string ToString()
        {
            return $"{Post} {Name}";
        }
        string IWorker.Name
        {
            get { return Name; }
            set { Name = value; }
        }
        string IWorker.Post
        {
            get { return Post; }
            set { Post = value; }
        }
        public TeamLeader teamLeader = new TeamLeader("Иванов Иван Иванович", "Бригадир"); // бригадир 1
        public List<Worker> workers = new List<Worker> 
        { 
            new Worker("Петров Петр Петрович", "Строитель 1 категории"),
            new Worker("Михайлов Семен Романович", "Мастер"),
            new Worker("Сидоров Алексей Сергеевич", "Строитель 2 категории") 
        };
                
    }

    class Worker : IWorker //строитель
    {
        string Name { get; set; }
        string Post { get; set; }

        public Worker(string name, string post)
        {
            Name = name;
            Post = post;
        }

        string IWorker.Name
        {
            get { return Name; }
            set { Name = value; }
        }
        string IWorker.Post
        {
            get { return Post; }
            set { Post = value; }
        }

        public void Build(House house, TeamLeader teamLeader)
        {
            if (house.basement == null)
            {
                Basement basement = new Basement();
                basement.Act(house);
                teamLeader.report.Add($"{Name}({Post}): Фундамент построен!");
            }
            else if (house.walls == null || house.walls.Count < 4)
            {
                if (house.walls == null) 
                    house.walls = new List<Walls>();
                Walls wall = new Walls();
                wall.Act(house);
                teamLeader.report.Add($"{Name}({Post}): Построено стен - {house.walls.Count}!");
            }
            else if (house.door == null)
            {
                Door door = new Door();
                door.Act(house);
                teamLeader.report.Add($"{Name}({Post}): Дверь уже установлена!");

            }

            else if (house.windows == null || house.windows.Count < 4)
            {
                if (house.windows == null) 
                    house.windows = new List<Window>();
                Window windows = new Window();
                windows.Act(house);
                teamLeader.report.Add($"{Name}({Post}): Установлено окон - {house.windows.Count}!");

            }

            else if (house.roof == null)
            {
                Roof roof = new Roof();
                roof.Act(house);
                teamLeader.report.Add($"{Name}({Post}): Кровля готова!");
            }
        }
    }

    class TeamLeader : IWorker //бригадир
    {
        string Name { get; set; }
        string Post { get; set; }

        public List<string> report = new List<string>();

        public TeamLeader(string name, string post)
        {
            Name = name;
            Post = post;
        }

        string IWorker.Name
        {
            get { return Name; }
            set { Name = value; }
        }
        string IWorker.Post
        {
            get { return Post; }
            set { Post = value; }
        }

        public void Report()
        {
            double done = report.Count/11.0*100;
            WriteLine($"{Name}({Post}): Дом построен на {(int)done}%");
        }
    }
}
