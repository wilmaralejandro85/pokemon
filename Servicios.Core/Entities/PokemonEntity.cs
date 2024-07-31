using System;
using System.Collections.Generic;

namespace Servicios.Core.Entities
{

    public class Ability
    {
        public string name { get; set; }
        public string url { get; set; }

        
    }
    public class Abilities
    {
        public Ability ability { get; set; }
        public bool is_hidden { get; set; }
        public int slot { get; set; }

    }

    public class Pokemon
    {
        public string response { get; set; }
        public string error { get; set; }
        public IList<Abilities> abilities { get; set; }
    }
  

}
