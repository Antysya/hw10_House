using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace hw10_House
{
    internal class Program
    {
        static void Main(string[] args)
        {
            House house = new House();
            Team team = new Team();
            Random r = new Random();
            WriteLine(team);
            WriteLine();

            int tmp = r.Next(0, 11); // задаем количество работ, котрые успели сделать до промежуточной отчетной даты

            WriteLine("Промежуточный итог:\n");
            for (int i = 0; i < tmp; i++)
            {
                team.workers[r.Next(0, 3)].Build(house, team.teamLeader);
            }
            foreach (var item in team.teamLeader.report)
            {
                WriteLine(item);
            }
            team.teamLeader.Report();
            WriteLine();

            WriteLine("Конечный результат:\n");
            for (int i = 0; i < 11-tmp; i++)
            {
                team.workers[r.Next(0, 3)].Build(house, team.teamLeader);
            }

            foreach (var item in team.teamLeader.report)
            {
                WriteLine(item);
            }
            team.teamLeader.Report();

            house.DrawingOfAHouse(team.teamLeader);            
        }
    }
}
