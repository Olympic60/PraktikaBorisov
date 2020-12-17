using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace practica_6
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeam team = new ResearchTeam();
             Console.WriteLine("Ту шорт стринг)) " + team.ToShortString());
             Console.WriteLine("Индекс год " + team[TimeFrame.Year]);
             Console.WriteLine("Индекс два года " + team[TimeFrame.TwoYears]);
             Console.WriteLine("Индекс давно " + team[TimeFrame.Long]);
             team.Theme_of_res = "Dota 2";
             team.Name_of_org = "Valve";
             team.Number_of_reg = 222222228;
             team.duration = TimeFrame.Year;
             team._publications.Add(new Paper());
            Console.WriteLine("Данные объекта " + team.ToString());
             team.AddPapers(new Paper("Pudge", new Person("Gabe", "Newell", new DateTime(1963, 7, 20)), new DateTime(2020, 10, 10)),
                            new Paper("Sven", new Person("Gaben", "Newellich", new DateTime(1961, 8, 18)), new DateTime(2020, 12, 9)));
             Console.WriteLine("Данные объекта 2 " + team.ToString());
             Console.WriteLine("Последняя публикация " + team.LastPublic.ToString());

            int start,end,time;
            Paper one = new Paper("Pudge", new Person("Gabe", "ewell", new DateTime(1963, 7, 20)), new DateTime(2020, 10, 10));
            Paper two = new Paper("Sven", new Person("Gaben", "Nwellich", new DateTime(1961, 8, 28)), new DateTime(2020, 10, 10));
            Paper three = new Paper("Sve", new Person("Gben", "Newellih", new DateTime(1661, 8, 18)), new DateTime(2020, 12, 09));
            Paper four = new Paper("Svn", new Person("aben", "Neellich", new DateTime(1971, 8, 3)), new DateTime(2020, 12, 09));
            Paper five = new Paper("ven", new Person("Gabn", "Newelich", new DateTime(1261, 8, 8)), new DateTime(2020, 12, 09));
            Paper six = new Paper("Sen", new Person("Gaen", "Newelich", new DateTime(1963, 8, 28)), new DateTime(2020, 12, 09));
            Paper[] linear = new Paper[] { one, two, three, four, five, six };
            Paper[,] matrix = new Paper[2,3] { {one, two, three }, {four, five, six } };
            Paper[][] rank = new Paper[3][];
            rank[0] = new Paper[1] { one };
            rank[1] = new Paper[2] { two, three };
            rank[2] = new Paper[3] { four, five, six };
            //Для линейного
            start = Environment.TickCount;
            for (int i=0;i<linear.Length;i++)
            {
                for (int j = 0; j < 1000000; j++)
                {
                    linear[i].ToString();
                    linear[i].Author.ToShortString();
                    linear[i].NameP.ToString();
                }
            }
            end = Environment.TickCount;
            time = end - start;
            Console.WriteLine("Время для линейного массива: " + time);
           
            //для зубчатого массива
            start = Environment.TickCount;
            for(int i = 0; i < rank.Length; i++)
            {
                for(int j=0;j<rank[i].Length;j++)
                {
                    for (int k = 0; k < 1000000; k++)
                    {
                        rank[i][j].ToString();
                        rank[i][j].Author.ToShortString();
                        rank[i][j].NameP.ToString();
                    }
                }
            }
            end = Environment.TickCount;
            time = end - start;
            Console.WriteLine("Время для зубчатого массива: " + time);
            // для матрицы
            start = Environment.TickCount;
            for (int i = 0; i < matrix.GetUpperBound(0)+1; i++)
            {
                for (int j = 0; j < matrix.Length/(matrix.GetUpperBound(0)+1); j++)
                {
                    for(int k=0;k< 1000000; k++)
                    {
                        matrix[i,j].ToString();
                        matrix[i,j].Author.ToShortString();
                        matrix[i,j].NameP.ToString();
                    }
                }
                
            }
            end = Environment.TickCount;
            time = end - start;
            Console.WriteLine("Время для матрицы: " + time);
        }
    }

    class Person
    {
        private string name;
        private string surname;
        private System.DateTime birthdate;       
        public Person(string _name,string _surname, DateTime _birthdate)
        {
            name = _name;
            surname = _surname;
            birthdate = _birthdate;
        }
        public Person()
        {
            name = "Chel";
            surname = "Tbl";
            birthdate = DateTime.Now;
        }
        public string person_name
        {
            get
            {
                return name;
            }
        }
        public string person_surname
        {
            get
            {
                return surname;
            }
        }
        public DateTime Birthdate
        {
            get
            {
                return birthdate;
            }
        }
        public int Get_set_date
        {
            get
            {
                return birthdate.Year;
            }
            set
            {
                birthdate = new DateTime(value, birthdate.Month, birthdate.Day);
            }

        }
        public override string ToString()
        {
            return name + " " + surname + " " + birthdate.Date.ToString();
        }
        public string ToShortString()
        {
            return name + " " + surname;
        }
    }
    enum TimeFrame { Year, TwoYears, Long }
     class Paper
    {
        public string NameP
        { 
          get; 
          set; 
        }
        public Person Author 
        { 
            get;
            set;
        } 
        public DateTime Data 
        {
            get; 
            set; 
        }

        public Paper(string _NameP, Person _Author, DateTime _Data)
        {
            NameP = _NameP;
            Author = _Author;
            Data = _Data;
        }
        public Paper()
        {
            NameP = "Cheeeel";
            Author = new Person();
            Data = new DateTime(2020, 01, 01);
        }
        public override string ToString()
        {
            return NameP + " " + Author + " " + Data;
        }
    }
    class ResearchTeam
    {
        public string Theme_of_res; 
        public string Name_of_org; 
        public int Number_of_reg; 
        public TimeFrame duration; 
        public List<Paper> _publications = new List<Paper>(); 
        public ResearchTeam(string _Theme_of_res, string _nameoforg, int _numberofreg, TimeFrame _duration)
        {
            Theme_of_res = _Theme_of_res;
            Name_of_org = _nameoforg;
            Number_of_reg = _numberofreg;
            duration = _duration;
        }
        public ResearchTeam()
        {
            Theme_of_res = "Tema";
            Name_of_org = "Ceeeeeeeeeeeeeeeeeb";
            Number_of_reg = -1;
            duration = new TimeFrame();
            _publications = new List<Paper>();
        }
        public string theme
        {
            get
            {
                return Theme_of_res;
            }
            set
            {
                Theme_of_res = value;
            }
        }
        public string name_of_ogr
        {
            get
            {
                return Name_of_org;
            }
            set
            {
                Name_of_org = value;
            }
        }
        public int numberofreg
        {
            get
            {
                return Number_of_reg;
            }
            set
            {
                Number_of_reg = value;
            }
        }
        public TimeFrame Dur
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
            }
        }
        public IReadOnlyList<Paper> Publications 
        {
            get
            {
                return _publications.AsReadOnly();
            }
            set
            {
                _publications = new List<Paper>(value);
            }
        }
        public Paper LastPublic
        {
            get
            {
                if (_publications.Count == 0)
                {
                    return null;
                }
                else
                {
                    Paper last_pub = _publications[0];
                    for (int i=1;i<_publications.Count;i++)
                    {
                        if(_publications[i].Data>last_pub.Data)
                        {
                            last_pub = _publications[i];
                        }
                    }
                    return last_pub;
                }
            }
        }
        public bool this[TimeFrame rez_prov]
        {
            get
            {
                if (Dur == rez_prov)
                    return true;
                else 
                    return false;
            }
        }
        public void AddPapers(params Paper[] papers)
        {
            for(int i=0;i<papers.Length;i++)
            {
                _publications.Add(papers[i]);
            }
        }
        public override string ToString()
        {
            return Theme_of_res + " " + Name_of_org + " " + Number_of_reg + " " + duration + " " + _publications;
        }
        public string ToShortString()
        {
            return Theme_of_res + " " + Name_of_org + " " + Number_of_reg + " " + duration;
        }


    }

}
