using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace CsvFormatter
{
    /// <summary>
    /// Original code taken from
    /// https://damienbod.com/2016/06/17/import-export-csv-in-asp-net-core/
    /// Adapted for ASP.NET Core and uses ; instead of , for delimiters
    /// </summary>
    public class CsvOutputFormatter: OutputFormatter
    {
        private readonly CsvFormatterOptions csvOptions;
        public CsvOutputFormatter(CsvFormatterOptions csvFormatterOptions)
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            csvOptions = csvFormatterOptions ?? throw new ArgumentNullException(nameof(csvFormatterOptions));
        }

        protected override bool CanWriteType(Type type)
        {
            return true;
        }

        public async override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var response = context.HttpContext.Response;
            var streamWriter = new StreamWriter(response.Body, csvOptions.Encoding);
            foreach (var obj in (IEnumerable<object>)context.Object)
            {
                var values = obj.GetType().GetProperties().Select(x => new
                        {
                            Value = x.GetValue(obj, null)
                        });
                string valueLine = string.Empty;
                foreach (var val in values)
                {
                    if (val.Value != null)
                    {
                        var _val = val.Value.ToString();

                        //Escape quotas
                        _val = _val.Replace("\"", "\"\"");

                        //Check if the value contains a delimiter and place it in quotes if so
                        if (_val.Contains(csvOptions.CsvDelimiter))
                            _val = string.Concat("\"", _val, "\"");

                        //Replace any \r or \n special characters from a new line with a space
                        if (_val.Contains("\r"))
                            _val = _val.Replace("\r", " ");
                        if (_val.Contains("\n"))
                            _val = _val.Replace("\n", " ");

                        valueLine = string.Concat(valueLine, _val, csvOptions.CsvDelimiter);
                    }
                    else
                    {
                        valueLine = string.Concat(valueLine, string.Empty, csvOptions.CsvDelimiter);
                    }
                }
                await streamWriter.WriteLineAsync(valueLine.Remove(valueLine.Length - csvOptions.CsvDelimiter.Length));
            }
            await streamWriter.FlushAsync();
        }
    }
}
