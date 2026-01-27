using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Expedition {
    internal class Menu {
        public static void Run() {
            Artifact[] artifacts;
            int count;
            Readfile readfile = new Readfile();
            readfile.Read("galactic_vault.txt", out artifacts, out count);
            Selections();
        }
        public static void Selections() {

        }
        public static void CountMove() {
            int move = 0;
            move++;
        }
    }
}
