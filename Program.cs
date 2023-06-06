using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp99
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string userInput;
            bool isOpen = true;
            int tickets;

            Train train = new Train();

            while(isOpen)
            {
                Console.WriteLine("Выберите направление");
                train.ShowAllDirections();
                userInput= Console.ReadLine();
                train.Direction = userInput;
                Console.WriteLine("Ваше направление " + train.Direction);

                tickets = random.Next(5,500);

                Console.WriteLine("Количество билетов:" + tickets);

                Console.WriteLine("Количество вагонов:" + train.GetWagons(tickets));
                Console.WriteLine("Нажмите любую клавишу, чтобы поезд поехал.");
                Console.ReadKey();
            }
        }
    }

    class Train
    {
        private List<string> _directions = new List<string>();
        private List<Wagon> _wagons = new List<Wagon>();

        private string _currentDir;
        private int _includeWagons = 0;

        public Train()
        {
            _directions.Add("Москва - Питер");
            _directions.Add("Питер - Казань");
            _directions.Add("Казань - Волгоград");
            _directions.Add("Волгоград - Казань");
        }

        public string Direction
        {
            get
            {
                return _currentDir;
            }
            set
            {

                int number = 1;
                int.TryParse(value, out number);
                _currentDir = _directions[number];
            }
        }

        public int GetWagons(int tickets)
        {
            Random rand = new Random();

            bool isTicketsSold = false;
            int numberOfWagon = 0;

            while (!isTicketsSold)
            {
                _wagons.Add(new Wagon(rand.Next(10, 15)));

                int places = _wagons[numberOfWagon].GetPlaces();

                if (tickets >= places)
                {
                    tickets -= places;
                    isTicketsSold = true;
                }
                else
                {
                    numberOfWagon++;
                }
            }

            _includeWagons = _wagons.Count();
            return _includeWagons;
        }       
        
        public void ShowAllDirections()
        {
            for (int i = 0; i < _directions.Count; i++)
            {
                Console.WriteLine(i + " - " + _directions[i]);
            }
        }
   
        class Wagon
        {
            private int _places;

            public Wagon(int type)
            {
                switch (type)

                {
                    case 1:
                        _places = 25;
                        break;

                    case 2:
                        _places = 50;
                        break;

                    case 3:
                        _places = 70;
                        break;
                }
            }

            public int GetPlaces()
            {
                return _places;
            }
        }
    }
}
