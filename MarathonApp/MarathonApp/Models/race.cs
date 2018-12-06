using System;

namespace MarathonApp
{
    //This classes purpose is to store the race class into an array named races.
    public class RaceCollection
    {
        public race[] races
        {
            get;
            set; //The race class will be set here
        }
    }

    //The purpose of this class is to obtain the id and race_name from the RESTFUL API.
    public class race
    {
        public int id
        {
            get;
            set;
        }
        public string race_name
        {
            get;
            set;
        }
    }
}
