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
        string[] fileLines;                                 // Array of individual lines in the file
        List<string[]> fileEntries = new List<string[]>();  // 3D List of entries in the file split
        bool fileExists;

        // Constructor
        public HighScores(string filePath)
        {
            file = filePath;
            // Read info from the file that was passed as an argument to the constructor.
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    fileData = sr.ReadToEnd();
                }

                // Split file into individual lines
                fileLines = fileData.Split('\n');
                // Split lines into individual entries and store in the List
                foreach (string line in fileLines)
                {
                    string tempLine = line.TrimEnd('\r');
                    string[] tempEntries = tempLine.Split(',');
                    fileEntries.Add(tempEntries);
                }

                fileExists = true;
            }
            catch
            {
                fileExists = false;
            }
        }

        public Boolean Exist()
        {
            return fileExists;
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

        public void printScores()
        {
            for (int i = 0; i < fileEntries.Count; i++)
            {
                string currScore = fileEntries[i][0] + " " + fileEntries[i][1];
                frmHighScores.lblScores[i].Text = currScore;
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

        // Write updated entries to a new file.
        public Boolean saveFile()
        {
            // Get the List as a string using the ToString method from above and write to newData.txt file.
            try
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.Write(this.ToString());
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
