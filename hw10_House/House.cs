using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace hw10_House
{
    interface IPart //часть дома
    {
        void Act(House house);
    }

    class House //дом
    {
        public Basement basement; //фундамент 1
        public List<Walls> walls; //стен 4
        public Door door; //дверь 1
        public List<Window> windows; //окон 4
        public Roof roof; // кровля 1

        public void DrawingOfAHouse(TeamLeader teamLeader)
        {
            if (teamLeader.report.Count == 11)
            {
                WriteLine(printHouse);
            }
            else WriteLine("Дом еще строится");
        }

        public string printHouse = @"
                                 _________________ 
                                /\_________________\
                               /  \_________________\
                              /    \_________________\
                             /  __  \_________________\
                            /  I  I  \_________________\
                           /   I__I   \_________________\
                          /____________\_________________\
                          |            |                 |
                          |  __        |  __         __  |
                          | I  I  ____ | I  I       I  I |
                          | I__I I    I| I__I       I__I |
                          |      I    I|                 |
                          |      I    I|                 |
                          |______I____I|_________________|";
    
    }

    class Basement : IPart //фундамент
    {
        public void Act(House house)
        {
            house.basement = new Basement();
        }
    }

    class Walls : IPart //Стены
    {
        public void Act(House house)
        {
            house.walls.Add(new Walls());
        }
    }

    class Door : IPart //Дверь
    {
        public void Act(House house)
        {
            house.door = new Door();
        }
    }

    class Window : IPart //окно
    {
        public void Act(House house)
        {
            house.windows.Add(new Window());
        }
    }

    class Roof : IPart //крыша
    {
        public void Act(House house)
        {
            house.roof = new Roof();
        }
    }


}
