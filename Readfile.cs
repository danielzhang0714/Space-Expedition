using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Expedition {
    internal class Readfile {
        char[] origin = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        char[] map = new char[] { 'H', 'Z', 'A', 'U', 'Y', 'E', 'K', 'G', 'O', 'T', 'I', 'R', 'J', 'V', 'W', 'N', 'M', 'F', 'Q', 'S', 'D', 'B', 'X', 'L', 'C', 'P' };
        char[] reverse = new char[] { 'Z', 'Y', 'X', 'W', 'V', 'U', 'T', 'S', 'R', 'Q', 'P', 'O', 'N', 'M', 'L', 'K', 'J', 'I', 'H', 'G', 'F', 'E', 'D', 'C', 'B', 'A' };

        public void Read(string path, out Artifact[] artifacts, out int count) {
            artifacts = new Artifact[10];
            count = 0;
            try {
                using (StreamReader reader = new StreamReader(path)) {
                    string line;
                    while ((line = reader.ReadLine()) != null) {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        string[] temparr = line.Split(',');
                        if (temparr.Length < 5) {
                            continue;
                        }
                        Artifact arti = new Artifact(temparr[0].Trim(), temparr[1].Trim(), temparr[2].Trim(), temparr[3].Trim(), temparr[4].Trim());
                        CheckArr(ref artifacts, count + 1);
                        artifacts[count] = arti;
                        count++;
                    }
                }
            } catch (FileNotFoundException) {
                Console.WriteLine("File not found: " + path);
            } catch (Exception e) {
                Console.WriteLine("Error reading file: " + e.Message);
            }
        }
        private void CheckArr(ref Artifact[] arti, int maxnum) {
            if (maxnum <= arti.Length) return;
            int newsize = arti.Length * 2;
            if (newsize < maxnum) {
                maxnum = newsize;
            }
            Artifact[] newarti = new Artifact[newsize];
            for (int i = 0; i < arti.Length; i++) {
                newarti[i] = arti[i];
            }
            arti = newarti;
        }

        public void selectionSort(string[] decodeartilist, int count) {
            for(int i = 0; i < count; i++) {
                string target = decodeartilist[i];
                int j = i - 1;
                while (j >=0 && decodeartilist[j].CompareTo(target) > 0) {
                    decodeartilist[j + 1] = decodeartilist[j];
                    j--;
                }
                decodeartilist[j + 1] = target;
            }
        }
        public void OrderedInsertion(string[] decodeartilist,string input, int count) {
            if (decodeartilist == null) throw new ArgumentNullException(nameof(decodeartilist));
            if (count >= decodeartilist.Length)
                throw new IndexOutOfRangeException("Array capacity is insufficient.");
                int i = count - 1;
                while (i >= 0 && decodeartilist[i].CompareTo(input) > 0) {
                decodeartilist[i + 1] = decodeartilist[i];
                    i--;
                }
                if(i >= 0 && decodeartilist[i].ToUpper().CompareTo(input.ToUpper()) == 0) {
                throw new ArgumentException($"Already have existing artifact: {decodeartilist[i]}");
                }
            decodeartilist[i + 1] = input;
        }
        public int binarySearch(string[] decodeartilist,int count, string target) {
            if (decodeartilist == null) return -1;
            if (string.IsNullOrWhiteSpace(target)) return -1;
            int lo = 0;
            int hi = decodeartilist.Length - 1;
            while(lo <= hi) {
                int mid = lo + (hi - lo) / 2;
                int compare = decodeartilist[mid].Trim().CompareTo(target);
                if (compare == 0) {
                    return mid;
                } else if (compare > 0) {
                    return hi = mid - 1;
                } else {
                    lo = mid + 1;
                }
            }
            return -1;
        }
        //recursive -- return the full decoded name, passing full string into it
        private string decodeName(string encodename, int length) {
            if (length <= 0 || string.IsNullOrEmpty(encodename)) {
                return "";
            }
            if (encodename[0] == ' ') {
                length++;
                return ' ' + decodeName(encodename.Substring(1), length - 1);
            }
            int i = 0;
            while (i < encodename.Length && !char.IsLetter(encodename[i])) {
                i++;
            }
            if(i >= encodename.Length) {
                return "";
            }
            char currentchar = char.ToUpper(encodename[i]);
            int numstart = i + 1;
            if(numstart >= encodename.Length || !char.IsDigit(encodename[numstart])) {
                return "";
            }
            int numend = numstart;
            while (numend < encodename.Length && char.IsDigit(encodename[numend])){
                numend++;
            }
            int layers = int.Parse(encodename.Substring(numstart, numend - numstart));
            char decodechar = Currentdecodeandnumber(currentchar, layers);
            int nextstart = numend;
            if(nextstart < encodename.Length && encodename[nextstart] == '|') {
                nextstart++;
            }
            string remainingstring;
            if (nextstart < encodename.Length) {
                remainingstring = encodename.Substring(nextstart);
            } else {
                remainingstring = "";
            }
            return decodechar + decodeName(remainingstring, length - 1);
        }
        private char Currentdecodeandnumber(char character, int layers) {
            if(layers == 0) {
                return character;
            }
            char mapped = character;
            for(int i = 0; i < origin.Length; i++) {
                if(character == origin[i]) {
                    mapped = map[i];
                    break;
                }
            }
            if (layers == 1) {
                for (int j = 0; j < origin.Length; j++) {
                    if (character == origin[j]) {
                        mapped = reverse[j];
                        break;
                    }
                }
            }
            return Currentdecodeandnumber(mapped, layers - 1);
        }
        public string decodeName(string encodename) {
            if (string.IsNullOrEmpty(encodename)) return "";
            encodename = encodename.Trim();
            int tokencount = 1;
            for (int i = 0; i < encodename.Length; i++) {
                if (encodename[i] == '|') tokencount++;
                if (encodename[i] == ' ') tokencount++;
            }
            return decodeName(encodename, tokencount);
        }
        public string[] AddToArr(Artifact[] artifacts, int count) {
            string[] decodeartilist = new string[count];
            for (int i = 0; i < count; i++) {
                string singleencode = artifacts[i].EncodedName;
                string result = decodeName(singleencode);
                decodeartilist[i] = result;
            }
            return decodeartilist;
        }

        public void PrintArtiName(string[] decodeartilist, int count) {
            using (StreamWriter printlist  = new StreamWriter("Artifact List.txt")) {
                for(int i = 0; i < count; i++) {
                    printlist.WriteLine(decodeartilist[i]);
                    Console.WriteLine($"{decodeartilist[i]}");
                }
            }
        }
    }
}
