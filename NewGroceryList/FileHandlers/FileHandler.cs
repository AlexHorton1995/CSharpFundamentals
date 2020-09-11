using System;
using System.Data;

namespace NewGroceryList.FileHandlers
{
    public interface IFileHandler
    {
        string SetHeader(DateTime pDate);
        string WriteDetailLine(DataRow row);
        string WriteSaveDetailLine(DataRow row);
    }

    public class FileHandler : IFileHandler
    {
        public string SetHeader(DateTime pDate)
        {
            string header = string.Format(
                //          1         2         3         4         5         6         7         8
                //012345678901234567890123456789012345678901234567890123456789012345678901234567890
                @"Date: {0}                                                  Time: {1}",
                pDate.Date.ToString("d").PadLeft(10, '0'), pDate.ToString("HH:mm:ss"));
            header += "\r\n\r\n";
            header += @"---------------------------------------------------------------------------------";
            header += "\r\n\r\n";
            header += @"                              Today's Shopping List!                    ";
            header += "\r\n";
            header += @"_________________________________________________________________________________";
            header += "\r\n";
            header += @"ITEMS        ITEM NAME                         ITEM PRICE                TAXABLE?";
            header += "\r\n";
            header += @"_________________________________________________________________________________";

            return header;
        }

        public string WriteDetailLine(DataRow row)
        {
            decimal.TryParse(row["ItemPrice"].ToString(), out decimal price);

            string detail = string.Format(@"{0}{1}{2:$C}{3}",
                row["ItemQuantity"].ToString().PadRight(13), 
                row["ItemName"].ToString().PadRight(33), 
                price.ToString("$#.00").PadLeft(11),
                row["IsTaxable"].ToString().PadLeft(20));

            return detail;
        }

        public string WriteSaveDetailLine(DataRow row)
        {
            decimal.TryParse(row["ItemPrice"].ToString(), out decimal price);

            string detail = string.Format(@"{0},{1},{2:$C},{3}",
                row["ItemQuantity"].ToString(),
                row["ItemName"].ToString(),
                price.ToString("$#.00"),
                row["IsTaxable"].ToString());

            return detail;
        }

    }
}
