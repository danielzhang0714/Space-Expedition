using System;
using System.Collections.Generic;
using System.IO;
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
        bool isstopped = false;
        public static void Run() {
            Menu menu = new Menu();
            menu.Start();
        }
        public void Start() {
            File.WriteAllText("expedition_summary.txt", string.Empty);
            readfile.Read("galactic_vault.txt", out artifacts, out count);
            decodeartilist = readfile.AddToArr(artifacts, count);
            readfile.selectionSort(decodeartilist, count);
            Selections();
        }
        public void Selections() {
            while (isstopped == false) {
                Console.WriteLine("\n=== Space Expedition Menu ===\n1. Add new artifact\n2. Show all artifacts\n3. Save summary\n4. Save and Exit");
                string pick = Console.ReadLine();
                switch (pick) {
                    case "1":
                        AddNewArti();
                        break;
                    case "2":
                        DisplayList();
                        break;
                    case "3":
                        MakeSummary();
                        Console.WriteLine("Summary saved");
                        break;
                    case "4":
                        Console.WriteLine("Saved and Exit now");
                        isstopped = true;
                        return;
                    default:
                        Console.WriteLine("Invalid input, try again");
                        break;
                }
            }
        }
        public void AddNewArti() {
            Console.Write("Please enter the artifact you want to add: ");
            string input = Console.ReadLine();
            string path = $"{input}.txt";
            if (!readfile.ReadNewArti(path, out Artifact newArti)) {
                Console.WriteLine("Artifact not found");
                CountMove();
                return;
            }
            string decodename = readfile.decodeName(newArti.EncodedName);
            try {
                if(readfile.binarySearch(decodeartilist, count, decodename) != -1) {
                    throw new ArgumentException("This artifact is already existing");
                }
                artifacts[count] = newArti;
                readfile.OrderedInsertion(ref decodeartilist, input, ref count);
                count++;
                Console.WriteLine($"New artifact: {input} successfully added");
            } catch (ArgumentException e) {
                Console.WriteLine(e.Message);
            }
        }
        public void CountMove() {
            move++;
        }
        public void RecordMove(string step) {
            if (!string.IsNullOrWhiteSpace(step))
                moves.Add(step);
        }
        public void DisplayList() {
            readfile.PrintArtiName(artifacts, count);
            CountMove();
            RecordMove("Viewed artifact list");
        }
        public void MakeSummary() {
            using (StreamWriter summary = new StreamWriter("expedition_summary.txt")) {
                for (int i = 0; i < move; i++) {
                    summary.WriteLine($"{i + 1}:{moves[i]}");
                }
            }
        }
    }
}
