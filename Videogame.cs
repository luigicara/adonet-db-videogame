using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class Videogame
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(null, "Il campo \"Nome\" non può essere vuoto!");
                }
                else
                {
                    _name = value;
                }
            }
        }
        private string _overview;
        public string Overview
        {
            get
            {
                return _overview;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(null, "Il campo \"Descrizione\" non può essere vuoto!");
                }
                else
                {
                    _overview = value;
                }
            }
        }
        public DateTime ReleaseDate { get; set; }
        public long SoftwareHouseId { get; set; }

        public Videogame(string name, string overview, DateTime release_date, long softwarehouse_id)
        {
            Name = name;
            Overview = overview;
            ReleaseDate = release_date;
            SoftwareHouseId = softwarehouse_id;
        }

        public override string ToString()
        {
            return $"Nome: {Name}\nDescrizione: {Overview}\nData di rilascio: {ReleaseDate.ToString()}";
        }
    }
}
