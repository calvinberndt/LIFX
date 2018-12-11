using System;

namespace LIFX.Controller
{
    public class LifxApiCallerProperties
    {
        public LifxApiCallerProperties()
        {
            var lifx = new GetLifx
            {
                UserName = LifxStruct.USERNAME,
                Password = LifxStruct.PASSWORD
            };
        }

        public class GetLifx
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Body { get; set; }
            public string URL { get; set; }
        }

        public class LifxAPICallerObject
        {
            public string Power { get; set; }
            public string Color { get; set; }
            public double Brightness { get; set; }
            public double Duration { get; set; }
        }
    }
}
