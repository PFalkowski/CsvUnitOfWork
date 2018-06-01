using CsvUnitOfWork.Model;
using Stocks.Data.Csv.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xunit;

namespace CsvUnitOfWork.Test
{
    public class CsvUnitOfWorkTest
    {
        [Theory]
        [ClassData(typeof(_11BitMock))]
        public void UnitOfWorkCommitsChanges(Company company)
        {
            // Arrange

            var fileName = Path.GetRandomFileName();
            var outputFile = new FileInfo(Path.ChangeExtension(fileName, "csv"));
            CsvContext<StockQuote> csvContext = null;
            CsvRepo<StockQuote> repository = null;
            CsvUnitOfWork<StockQuote> tested = null;
            try
            {
                csvContext = new StockCsvContext(outputFile) { Culture = CultureInfo.InvariantCulture };
                repository = new CsvRepo<StockQuote>(csvContext);
                tested = new CsvUnitOfWork<StockQuote>(csvContext);

                // Act

                tested.Repo.AddRange(company.Quotes);
                tested.Complete();

                var received = File.ReadAllText(outputFile.FullName);

                // Assert

                var actual = received.Split(Environment.NewLine).Length;
                var expected = company.Quotes.Count + 2;
                Assert.Equal(expected, actual);
            }
            finally
            {
                tested?.Dispose();
                repository?.Dispose();
                outputFile.Delete();
            }
        }
    }
}
