using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace Wujian.Tech.Helper
{
    internal class Excel
    {
        private const string _fileName = "Showcase.xlsx";

        private static void Clear()
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
        }

        internal static void Test()
        {
            Clear();

            /*
             https://closedxml.codeplex.com/wikipage?title=Showcase&referringTitle=Home
             */

            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Contacts");

            //Title
            ws.Cell("B2").Value = "Contacts";

            //First Names
            ws.Cell("B3").Value = "FName";
            ws.Cell("B4").Value = "John";
            ws.Cell("B5").Value = "Hank";
            ws.Cell("B6").SetValue("Dagny"); // Another way to set the value

            //Last Names
            ws.Cell("C3").Value = "LName";
            ws.Cell("C4").Value = "Galt";
            ws.Cell("C5").Value = "Rearden";
            ws.Cell("C6").SetValue("Taggart"); // Another way to set the value

            // Boolean
            ws.Cell("D3").Value = "Outcast";
            ws.Cell("D4").Value = true;
            ws.Cell("D5").Value = false;
            ws.Cell("D6").SetValue(false); // Another way to set the value

            //DateTime
            ws.Cell("E3").Value = "DOB";
            ws.Cell("E4").Value = new DateTime(1919, 1, 21);
            ws.Cell("E5").Value = new DateTime(1907, 3, 4);
            ws.Cell("E6").SetValue(new DateTime(1921, 12, 15)); // Another way to set the value

            //Numeric
            ws.Cell("F3").Value = "Income";
            ws.Cell("F4").Value = 2000;
            ws.Cell("F5").Value = 40000;
            ws.Cell("F6").SetValue(10000); // Another way to set the value

            //From worksheet
            var rngTable = ws.Range("B2:F6");

            //From another range
            var rngDates = rngTable.Range("D3:D5"); // The address is relative to rngTable (NOT the worksheet)
            var rngNumbers = rngTable.Range("E3:E5"); // The address is relative to rngTable (NOT the worksheet)

            //Using a OpenXML's predefined formats
            rngDates.Style.NumberFormat.NumberFormatId = 15;

            //Using a custom format
            rngNumbers.Style.NumberFormat.Format = "$ #,##0";

            rngTable.FirstRow().Merge(); // We could've also used: rngTable.Range("A1:E1").Merge() or rngTable.Row(1).Merge()

            var rngHeaders = rngTable.Range("A2:E2"); // The address is relative to rngTable (NOT the worksheet)
            rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rngHeaders.Style.Font.Bold = true;
            rngHeaders.Style.Font.FontColor = XLColor.DarkBlue;
            rngHeaders.Style.Fill.BackgroundColor = XLColor.Aqua;

            var rngData = ws.Range("B3:F6");
            var excelTable = rngData.CreateTable();

            // Add the totals row
            excelTable.ShowTotalsRow = true;
            // Put the average on the field "Income"
            // Notice how we're calling the cell by the column name
            excelTable.Field("Income").TotalsRowFunction = XLTotalsRowFunction.Average;
            // Put a label on the totals cell of the field "DOB"
            excelTable.Field("DOB").TotalsRowLabel = "Average:";

            //Add thick borders to the contents of our spreadsheet
            ws.RangeUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

            // You can also specify the border for each side:
            // contents.FirstColumn().Style.Border.LeftBorder = XLBorderStyleValues.Thick;
            // contents.LastColumn().Style.Border.RightBorder = XLBorderStyleValues.Thick;
            // contents.FirstRow().Style.Border.TopBorder = XLBorderStyleValues.Thick;
            // contents.LastRow().Style.Border.BottomBorder = XLBorderStyleValues.Thick;

            ws.Columns().AdjustToContents(); // You can also specify the range of columns to adjust, e.g.
            // ws.Columns(2, 6).AdjustToContents(); or ws.Columns("2-6").AdjustToContents();

            /*
             If want save in ASP.NET to download file, please see 
             https://closedxml.codeplex.com/wikipage?title=How%20do%20I%20deliver%20an%20Excel%20file%20in%20ASP.NET%3f&referringTitle=Documentation
             */
            wb.SaveAs(_fileName);
        }
    }

}
