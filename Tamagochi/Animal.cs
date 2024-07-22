using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi
{
    class Animal 
    {
        private int _happiness;
        private int _sleep;
        private int _cleanness;
        private int _hunger;
        private string _name;
        private string _animalType;

        public string AnimalType
        {
            get { return _animalType; }
            set { _animalType = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Happiness
        {
            get { return _happiness; }
            set { _happiness = value; }
        }

        public int Sleep
        {
            get { return _sleep; }
            set { _sleep = value; }
        }

        public int Cleanness
        {
            get { return _cleanness; }
            set { _cleanness = value; }
        }

        public int Hunger
        {
            get { return _hunger; }
            set { _hunger = value; }
        }

    }
}

