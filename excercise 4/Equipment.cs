using System;
using System.Collections.Generic;
using System.Text;

namespace excercise_4
{
    class Equipment
    {
        public string name { get; set; }
        public string description { get; set; }
        public double distance { get; set; } = 0;
        public double maintenance { get; set; } = 0;
        public double parameter { get; set; }
        //public enum type { Mobile, Immobile }

        public Equipment() { }
        
        public Equipment(string name, string description, double distance, double maintenance, double parameter)
        {
            this.name = name;
            this.description = description;
            this.maintenance = maintenance;
            this.distance = distance;
            this.parameter = parameter;
        }

        public void moveBy()
        {
            double value = 0;
            this.distance = distance + value;
        }

        public void maintenanceCost()
        {
            this.maintenance = maintenance + (parameter * distance);
        }

    }

    class Mobile : Equipment
    {
        
        public Mobile(string name, string description, double distance, double maintenance, double parameter)
            : base(name, description, distance, maintenance, parameter)
        {
            //this.parameter = wheels;
        }

        public int wheels { get; set; }

        

    }

    class Immobile : Equipment
    {
        public Immobile(string name, string description, double distance, double maintenance, double parameter)
            : base(name, description, distance, maintenance, parameter)
        {
            //this.parameter = weight;

        }
        public int weight { get; set; }
    }
}
