using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ShootingGame
{
    public class HighScores
    {
        string file;                                        // File path
        string fileData;                                    // Contains the whole file as a string
        List<string> fileLines;                             // Array of individual lines in the file
        List<string[]> fileEntries;  // 3D List of entries in the file split
        StreamReader sr;

        // Constructor
        public HighScores(string filePath)
        {
            file = filePath;
            fileLines = new List<string>();
            fileEntries = new List<string[]>();

            string line;
            int counter = 0;
            sr = new StreamReader("high_scores.txt");
            while ((line = sr.ReadLine()) != null)
            {
                fileLines.Add(line);
                counter++;
            }

            for (int i = 0; i < fileLines.Count; i++)
            {
                if (fileLines[i] == "")
                {
                    fileLines.RemoveAt(i);
                }
            }

            foreach (string ent in fileLines)
            {
                string tempLine = ent.TrimEnd('\r');
                string[] tempEntries = tempLine.Split(',');
                fileEntries.Add(tempEntries);
            }
        }

        public void chkHighScore(string name, int score)
        {
            for (int i = 0; i < fileEntries.Count; i++)
            {
                int currScore = Convert.ToInt32(fileEntries[i][1]);
                if (score > currScore)
                {
                    string[] newScore = { name, "" + score };
                    fileEntries.Add(newScore);
                    removeSmallest();
                }
            }
        }

        public void removeSmallest()
        {
            if (fileEntries.Count > 5)
            {
                int smallest = int.MaxValue;
                int smlIndex = 0;

                for (int i = 0; i < fileEntries.Count; i++)
                {
                    int currScore = Convert.ToInt32(fileEntries[i][1]);
                    if (currScore < smallest)
                    {
                        smallest = currScore;
                        smlIndex = i;
                    }
                }

                fileEntries.RemoveAt(smlIndex);
            }
        }

        // Override method to convert List of entries into a string.
        public override string ToString()
        {
            string ret = "";

            // Loop through the List and add each string to the string that is to be returned.
            for (int i = 0; i < fileEntries.Count; i++)
            {
                for (int j = 0; j < fileEntries[i].Length; j++)
                {
                    ret = ret + fileEntries[i][j];
                    if (j < (fileEntries[i].Length - 1))
                    {
                        ret = ret + ",";
                    }
                }
                ret = ret + "\r\n";         // \r\n characters are required because windows does not recognize \n alone as newline (at least my copy of windows does this).
            }

            return ret;
        }

        public void closeFile()
        {
            sr.Close();
        }
    }
}
