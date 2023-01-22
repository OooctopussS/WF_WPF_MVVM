using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3N1
{
    [Serializable]
    public class Exhibition
    {
        public List<Level> LevelList { get; set; } = new List<Level>();
        public Exhibition() { }
    }

    [Serializable]
    public class Level
    {
        public List<Hall> HallList { get; set; } = new List<Hall>();
        public string Number { get; set; }

        public Level() { }
    }

    [Serializable]
    public class Hall
    {
        public List<Exhibit> ExhibitList { get; set; } = new List<Exhibit>();
        public string Name { get; set; }

        public Hall() { }
    }

    [Serializable]
    public class Exhibit
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
        public string Author { get; set; }

        public Exhibit() { }

        public Exhibit(string name, string description, string year, string author)
        {
            this.Name = name;
            this.Description = description;
            this.Year = year;
            this.Author = author;
        }
    }
}
