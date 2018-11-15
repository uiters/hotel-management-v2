using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System;

namespace HotelManager.DAO
{
    public enum ModeExportToExcel
    {
        XLS = 0,
        XLSX = 1,
        PDF = 2
    }
    public class ExportToExcel
    {
        private static ExportToExcel instance;
        public static ExportToExcel Instance
        {
            get
            {
                if (instance == null)
                    instance = new ExportToExcel();
                return instance;
            }
        }
        private ExportToExcel() { }
        Action<Excel.Workbook , string, Excel.XlFileFormat> saveFile;
        public bool Export(DataGridView dataGridView, string path, ModeExportToExcel mode = ModeExportToExcel.XLS)
        {
            saveFile = ToExcel;
            Excel.Application appExcel = null;
            Excel.Workbook bookExcel = null;
            Excel.Worksheet sheetExcel = null;
            object misValue = Missing.Value;
            Excel.XlFileFormat fileFormat = Excel.XlFileFormat.xlWorkbookNormal;
            switch (mode)
            {
                case ModeExportToExcel.XLSX:
                    fileFormat = Excel.XlFileFormat.xlOpenXMLWorkbook;
                    break;
                case ModeExportToExcel.PDF:
                    saveFile = ToPDF;
                    break;
                default:
                    break;
            }          
            try
            {
                appExcel = new Excel.Application();
                appExcel.DisplayAlerts = false;
                appExcel.Visible = false;

                bookExcel = appExcel.Workbooks.Add();
                sheetExcel =(Excel.Worksheet) bookExcel.Worksheets[1];

                int currentColumn = 0;
                int currentRow = 1;
                System.Collections.Generic.List<int> listColumn = new System.Collections.Generic.List<int>();
                foreach (DataGridViewTextBoxColumn column in dataGridView.Columns)
                {
                    if (column.Visible == false) continue;
                    listColumn.Add(column.DisplayIndex);
                    sheetExcel.Cells[currentRow, ++currentColumn] = column.HeaderText != "" ? column.HeaderText : column.Name; // [1 , x] name table
                }
                
                for (int i = 0; i < dataGridView.Rows.Count; i++)//row
                {
                    if (dataGridView.Rows[i].IsNewRow) continue;
                    ++currentRow;
                    currentColumn = 0;
                    foreach (int j in listColumn)//column
                    {
                        sheetExcel.Cells[currentRow, ++currentColumn] = dataGridView[j, i].Value.ToString();
                    }
                }
                sheetExcel.Columns.AutoFit();
                sheetExcel.Columns.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                sheetExcel.Rows[1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                sheetExcel.Rows[1].Font.Bold = true;
                sheetExcel.Rows[1].Font.Size = 12;
                saveFile(bookExcel, path, fileFormat);
                appExcel.Quit();
                Marshal.ReleaseComObject(appExcel);
                Marshal.ReleaseComObject(bookExcel);
                Marshal.ReleaseComObject(sheetExcel);


                sheetExcel = null;
                bookExcel = null;
                sheetExcel = null;
                GC.Collect();
                return true;
            }
            catch
            {
                if (bookExcel != null)
                    bookExcel.Close(false);
                if (appExcel != null)
                    appExcel.Quit();
                Marshal.ReleaseComObject(appExcel);
                Marshal.ReleaseComObject(bookExcel);
                Marshal.ReleaseComObject(sheetExcel);
                sheetExcel = null;
                bookExcel = null;
                sheetExcel = null;
                GC.Collect();
                return false;
            }
        }

        private void ToExcel(Excel.Workbook bookExcel, string path, Excel.XlFileFormat fileFormat)
        {
            object misValue = Missing.Value;
            bookExcel.SaveAs(path, fileFormat, misValue, misValue, false, false, Excel.XlSaveAsAccessMode.xlExclusive, Excel.XlSaveConflictResolution.xlLocalSessionChanges, misValue, misValue, misValue, misValue);
            bookExcel.Close(true);
        }
        private void ToPDF(Excel.Workbook bookExcel, string path, Excel.XlFileFormat fileFormat)
        {
            bookExcel.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, path, Excel.XlFixedFormatQuality.xlQualityStandard);
            bookExcel.Saved = false;
            bookExcel.Close();
        }
    }
}
