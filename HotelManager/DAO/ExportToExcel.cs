using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System;
using Microsoft.Office.Interop.Excel;

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
                int currentRow = 0;

                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    if (dataGridView.Rows[i].IsNewRow) continue;
                    else
                    {
                        currentColumn = 0;
                        ++currentRow;
                        for (int j = 0; j < dataGridView.ColumnCount; j++)
                        {
                            if (dataGridView.Columns[j].Visible == false) continue;
                            else
                                sheetExcel.Cells[currentRow, ++currentColumn] = dataGridView[j, i].Value.ToString();
                        }
                    }
                }
                Range line = (Range)sheetExcel.Rows[1];
                currentColumn = 0;
                line.Insert();
                for (int i = 0; i < dataGridView.ColumnCount; i++)
                {
                    if (dataGridView.Columns[i].Visible == false) continue;
                    else
                        sheetExcel.Cells[1, ++currentColumn] = dataGridView.Columns[i].HeaderText;
                }


                //Excel.ChartObjects chartObjects = (Excel.ChartObjects)sheetExcel.ChartObjects();
                //Excel.ChartObject chart = (Excel.ChartObject)chartObjects.Add(400, 400, 400, 400);
                //Excel.Chart chartPage = chart.Chart;

                //Range range = sheetExcel.Range["A2,A3,A4,A5,C2,C3,C4,C5", Type.Missing];
                //range.DataSeries

                //chartPage.SetSourceData(range, Excel.XlRowCol.xlRows);
                //chartPage.ChartStyle = Excel.XlChartType.xlDoughnut;
                //chartPage.

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
            try
            {
                bookExcel.SaveAs(path, fileFormat, misValue, misValue, false, false, Excel.XlSaveAsAccessMode.xlExclusive, Excel.XlSaveConflictResolution.xlLocalSessionChanges, misValue, misValue, misValue, misValue);
            }
            catch
            {
                string[] vs = path.Split('.');
                path = string.Empty;
                for (int i = 0; i < vs.Length - 1; i++)
                {
                    path += vs[i];
                }
                path += " Mới ." +  vs[vs.Length - 1];
                bookExcel.SaveAs(path, fileFormat, misValue, misValue, false, false, Excel.XlSaveAsAccessMode.xlExclusive, Excel.XlSaveConflictResolution.xlLocalSessionChanges, misValue, misValue, misValue, misValue);
            }
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
