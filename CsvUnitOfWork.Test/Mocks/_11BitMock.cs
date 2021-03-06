﻿using CsvUnitOfWork;
using CsvUnitOfWork.Model;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Extensions.Serialization;
using Xunit;

namespace Stocks.Data.Csv.Test.Mocks
{
    public class _11BitMock : TheoryData<Company>
    {
        private static Lazy<Company> Mock => new Lazy<Company>(() => new Company
        {
            Ticker = nameof(CsvUnitOfWork.Test.Properties.Resources._11BIT),
            Quotes = Encoding.UTF8.GetString(CsvUnitOfWork.Test.Properties.Resources._11BIT).DeserializeFromCsv(new StockQuoteCsvClassMap(), CultureInfo.InvariantCulture).ToList()
        });

        public _11BitMock()
        {
            Add(Mock.Value);
        }
    }
}
