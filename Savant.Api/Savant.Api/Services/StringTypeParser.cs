using System;
using System.Collections.Generic;
using System.Linq;

namespace Savant.Api.Services
{
    public class StringTypeParser : IStringTypeParser
    {
        private readonly IEnumerable<DataType> _dataTypes;

        public StringTypeParser()
        {
            _dataTypes = FillDataTypes();
        }

        public (DataType type, object value) FromString(string stringValue, DataType heuristic = DataType.Unknown)
        {
            if (heuristic != DataType.Unknown && TryParseAs(heuristic, out var value))
                return (heuristic, value);

            foreach (var dataType in _dataTypes)
                if (TryParseAs(dataType, out value))
                    return (dataType, value);

            return (DataType.Unknown, stringValue);
        }

        private static bool TryParseAs(DataType dataType, out object value)
        {
            switch (dataType)
            {
                // todo
            }

            value = null;
            return false;
        }

        private IEnumerable<DataType> FillDataTypes()
        {
            return Enum.GetValues(typeof(DataType))
                        .Cast<DataType>()
                        .Where(x => x != DataType.Unknown)
                        .ToList();
        }
    }
}
