using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader
{
  class Program
  {

    static ExcelRange FindCellByText(string textToFind, ExcelWorksheet sheet, int maxColumn, int maxRow)
    {

      for (int rowNumber = 1; rowNumber <= maxRow; rowNumber++)
      {
        for (int columnNumber = 1; columnNumber <= maxColumn; columnNumber++)
        {
          string text = sheet.Cells[rowNumber, columnNumber].Text;
          if (text == textToFind)
          {
            return sheet.Cells[rowNumber, columnNumber];
          }
        }
      }
      return null;

    }

    
    
    static void Main(string[] args)
    {
      

      System.Drawing.Color?[] dayColor = new System.Drawing.Color?[33];
      FileInfo fileInfo = new FileInfo(@"C:\Users\Asus\Desktop\Test.xlsx");
      using (
          ExcelPackage package = new ExcelPackage(
              fileInfo))
      {
        var sheet1 = package.Workbook.Worksheets[1];
        for (int day = 1; day <= 31; day++)
        {
          if (sheet1.Cells[2, day + 1].Style.Fill.BackgroundColor.Rgb != null)
          {
            var colorRgb = "#" + sheet1.Cells[2, day + 1].Style.Fill.BackgroundColor.Rgb;

            System.Drawing.Color s = System.Drawing.ColorTranslator.FromHtml(colorRgb);
            dayColor[day] = s;
          }
          else {
            dayColor[day] = null;
          }


        }
      }


      Dictionary<System.Drawing.Color, ExcelFillStyle> patternDict = new Dictionary<System.Drawing.Color, ExcelFillStyle>();

      FileInfo fileInfo2 = new FileInfo(@"C:\Users\Asus\Desktop\Test2.xlsx");
      using (
          ExcelPackage package = new ExcelPackage(
              fileInfo2))
      {
        var sheet1 = package.Workbook.Worksheets[1];

        for (int pattern=2; pattern<=5; pattern++)
        {
          var colorRgb = "#" + sheet1.Cells[24, pattern].Style.Fill.PatternColor.Rgb;
          if (colorRgb != "#")
          {
            System.Drawing.Color s = System.Drawing.ColorTranslator.FromHtml(colorRgb);
            if (sheet1.Cells[24, pattern].Style.Fill.PatternType != ExcelFillStyle.Solid)
            {
              patternDict.Add(s, sheet1.Cells[24, pattern].Style.Fill.PatternType);
            }
          }
        }

        for (int day = 1; day <= 31; day++)
        {
          
          var cell = FindCellByText("" + day, sheet1, 100, 100);
          if (cell != null && dayColor[day]!=null)
          {
            if (patternDict.ContainsKey(dayColor[day].Value))
            {
              cell.Style.Fill.PatternType = patternDict[dayColor[day].Value];
            }
            else
            {
              cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
              cell.Style.Fill.BackgroundColor.SetColor(dayColor[day].Value);
            }
            
          }
        }

        package.SaveAs(new FileInfo(@"C:\Users\Asus\Desktop\Test3.xlsx"));



      }

    }
  }
}
