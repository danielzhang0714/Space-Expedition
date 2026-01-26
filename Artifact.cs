using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Expedition {
    internal class Artifact {
        public string EncodedName { get; set; }
        public string Planet { get; set; }
        public string DiscoveryDate { get; set; }
        public string StorageLocation { get; set; }
        public string Description { get; set; }
        public Artifact(string name, string planet, string date, string location, string description) {
            EncodedName = name;
            Planet = planet;
            DiscoveryDate = date;
            StorageLocation = location;
            Description = description;
        }
    }
}
