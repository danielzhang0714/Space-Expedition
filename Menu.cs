using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Expedition {
    internal class Menu {
        public Readfile readfile = new Readfile();
        public int count;
        public int move = 0;
        public Artifact[] artifacts;
        public string[] decodeartilist;
        public List<string> moves = new List<string>();
        public static void Run() {
            Menu menu = new Menu();
            menu.Start();
        }
        public void Start() {
            readfile.Read("galactic_vault.txt", out artifacts, out count);
            decodeartilist = readfile.AddToArr(artifacts, count);
            readfile.selectionSort(decodeartilist, count);
            Selections();
        }
        public void Selections() {

        }
        public void AddNewArti() {
            Console.Write("Please enter the artifact you want to add: ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) {
                Console.WriteLine("Invalid input, please retry");
                CountMove();
                RecordMove("Entered invalid input when adding new artifact");
                return;
            }
            try {
                readfile.OrderedInsertion(decodeartilist, input, count);
                CountPlus();
                CountMove();
                Console.WriteLine($"New artifact: {input} successfully added");
                RecordMove($"Adding new artifact {input} into the list");
            } catch (ArgumentException e) {
                Console.WriteLine("Invalid artifact input: " + e.Message);
            } catch (Exception e) {
                Console.WriteLine("Unexpected error while adding artifact: " + e.Message);
            }
        }
        public void CountPlus() {
            count++;
        }
        public void CountMove() {
            move++;
        }
        public void RecordMove(string step) {
            if (!string.IsNullOrWhiteSpace(step))
                moves.Add(step);
        }
        public void MakeSummary(string path) {
            using (StreamWriter summary = new StreamWriter("expedition_summary.txt")) {
                foreach (string move in moves) {
                    summary.WriteLine(move);
                }
            }
        }
    }
}
