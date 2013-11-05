using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShootingGame
{
    public class UpdateFile
    {
        private string updatedFilePath;
        private System.IO.StreamWriter updatedFileSW;  // Reference variable of type SW
        private int recordWrittenCount;

        // Constructor takes file path as parameter
        public UpdateFile
            (string filePath)
        {
            recordWrittenCount = 0;
            updatedFilePath = filePath;
            try
            {
                updatedFileSW = new System.IO.StreamWriter(updatedFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open file" + updatedFilePath + "Terminate Program." + ex,
                                "Input File Connection Error.",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Write a record to the updated file
        public void putNextRecord
            (string record)
        {
            try
            {
                updatedFileSW.WriteLine(record);
            }
            catch (Exception ex)
            {
                MessageBox.Show("IO error in file write. Terminate program." + ex,
                                "File Write Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            recordWrittenCount += 1;
        }

        // Get value of number of records written
        public int getRecordsWrittenCount()
        {
            return recordWrittenCount;
        }

        // Close the output (updated) file
        public void closeFile()
        {
            updatedFileSW.Close();
        }
    }
}
