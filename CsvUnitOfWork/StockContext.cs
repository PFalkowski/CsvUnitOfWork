using System.IO;
using CsvUnitOfWork.Model;

namespace CsvUnitOfWork
{
    public class StockCsvContext : CsvContext<StockQuote>
    {
        public StockCsvContext(FileInfo file) : base(file)
        {
            CustomMapping = new StockQuoteCsvClassMap();
        }

        public StockCsvContext(string filePath) : this(new FileInfo(filePath))
        {
        }
    }
}
