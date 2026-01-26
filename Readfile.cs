using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Expedition {
    internal class Readfile {
        char[] origin = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        char[] map = new char[] { 'H', 'Z', 'A', 'U', 'Y', 'E', 'K', 'G', 'O', 'T', 'I', 'R', 'J', 'V', 'W', 'N', 'M', 'F', 'Q', 'S', 'D', 'B', 'X', 'L', 'C', 'P' };
        public static void Read() {

        }
        public static void selectionSort() {

        }
        //recursive -- return the full decoded name, passing full string into it
        private string decodeName(string encodename, int length) {
            string decodedname = "";
            string leftcode = encodename;
            if (length == 0) return "";
            for (int i = 0; i < encodename.Length; i++) {
                if (!char.IsLetter(encodename[i])) continue;
                char code = char.ToUpper(encodename[i]);
                if (i + 1 >= encodename.Length) continue;
                if (!char.IsDigit(encodename[i + 1])) continue;
                int k = i + 1;
                while (k < encodename.Length && char.IsDigit(encodename[k])) {
                    k++;
                }
                int number = int.Parse(encodename.Substring(i + 1, k - (i + 1)));
                for (int j = 0; j < origin.Length; j++) {
                    if (code == origin[j]) {
                        code = map[j];
                        break;
                    }
                }
                decodedname += new string(code, number);
                int removeLen = k - i;
                if (k < encodename.Length && encodename[k] == '|') {
                    removeLen++;
                }
                length--;
                leftcode = encodename.Remove(i, removeLen);
                return decodedname + decodeName(leftcode, length);
            }
            return decodedname;
        }
        public string decodeName(string encodename) {
            if (string.IsNullOrWhiteSpace(encodename)) return "";
            encodename = encodename.Trim().TrimEnd(',');

            int tokenCount = 1;
            for (int i = 0; i < encodename.Length; i++) {
                if (encodename[i] == '|') tokenCount++;
            }

            return decodeName(encodename, tokenCount);
        }

    }
}
