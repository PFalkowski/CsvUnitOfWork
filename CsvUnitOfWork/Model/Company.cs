using System.Collections.Generic;
using System.Linq;
using StandardInterfaces;

namespace CsvUnitOfWork.Model
{
    public sealed class Company : IValidatable
    {
        public string Ticker { get; set; }
        public List<StockQuote> Quotes { get; set; }

        public StockQuote FirstQuote => Quotes?.First();
        public StockQuote LastQuote => Quotes?.Last();

        public bool IsValid()
        {
            return (string.IsNullOrWhiteSpace(Ticker) || Quotes != null) && Quotes.All(q => q.IsValid());
        }

        public override string ToString()
        {
            return Ticker;
        }
    }
}
