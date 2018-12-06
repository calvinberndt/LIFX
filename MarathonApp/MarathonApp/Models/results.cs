using System;
namespace MarathonApp
{
    public class ResultsCollection
    {
        public result[] results
        {
            get;
            set; 
        }


        public class result
        {
            public string id
            {
                get;
                set;
            }
            public string race_id
            {
                get;
                set;
            }
            public string placement
            {
                get;
                set;
            }
            public string name
            {
                get;
                set;
            }
            public string time
            {
                get;
                set;
            }
            public string state
            {
                get;
                set;
            }
            public string detail
            {
                get
                {
                    return placement + " Place Time: " + time;
                }
            }
        }
    }
}
