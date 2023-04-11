using ReadAndWriteDatabase.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ReadAndWriteDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public  List<string> ReadWriteExcel(string path)
        {
            string sourceName = path;
            string destenationName = path;

            // reading varibles
            Excel.Application xlReadApp = new Excel.Application();
            Excel.Workbook xlReadbook = xlReadApp.Workbooks.Open(sourceName);
            Excel._Worksheet xlReadsheet = xlReadbook.Sheets[1];
            Excel.Range xlReadRange = xlReadsheet.UsedRange;

            //writing varibles
            //Excel.Application xlWriteApp = new Excel.Application();
            //Excel.Workbook xlWritebook = xlWriteApp.Workbooks.Open(destenationName);
            //Excel._Worksheet xlWritesheet = xlWritebook.Sheets[1];
            //Excel.Range xlWriteRange = xlWritesheet.UsedRange;

            List<RooftopACCost> cost = new List<RooftopACCost>();
            List<string> result = new List<string>();
            ExcelToDbEntities ef = new ExcelToDbEntities();
            string str = "";
            int count = 0,countRow=0;
            // loop to read and insert * after each cell
            for (int i = 2; i <= xlReadRange.Cells.Rows.Count; i++)
            {
                RooftopACCost ac = new RooftopACCost();
                for (int j = 2; j < 8; j++)
                {
                    str = xlReadRange.Cells[i, j].Value2.ToString();
                    if (j == 2)
                    {
                        ac.RooftopUnitId = Convert.ToInt32(str);
                    }
                    else if (j == 3)
                    {
                        ac.RooftopUnitType = str;
                    }
                    else if (j == 4)
                    {
                        ac.Pressure = Convert.ToDouble(str);
                    }
                    else if (j == 5)
                    {
                        ac.Price = Convert.ToDecimal(str);
                    }
                    else if (j == 6)
                    {
                        ac.UnitType = str;
                    }
                    else if (j == 7)
                    {
                        ac.WorkingPreference = str;
                    }
                    count++;
                    result.Add(str);
                }
                count++;
                LblCountRow.Text = count.ToString();
                cost.Add(ac);
            }
            ef.RooftopACCost.AddRange(cost);
            ef.BulkSaveChanges();


            //xlWritebook.Save();

            //xlWritebook.Close();
            //Marshal.ReleaseComObject(xlWritebook);

            ////quit and release
            //xlWriteApp.Quit();
            //Marshal.ReleaseComObject(xlWriteApp);

            xlReadbook.Close();
            Marshal.ReleaseComObject(xlReadbook);

            //quit and release
            //xlReadApp.Quit();
            //Marshal.ReleaseComObject(xlReadApp);
            return result;

        }
        string path = "";
        public void BtnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası |*.xls";
            file.Title = "Excel Dosyası Seç";
            if(file.ShowDialog () == DialogResult.OK)
            {
                path= file.FileName;
            }
        }
        public void BtnSave_Click(object sender, EventArgs e)
        {
            var list = ReadWriteExcel(path);
            MessageBox.Show("Veriler Eklendi");
        }

    }
}
