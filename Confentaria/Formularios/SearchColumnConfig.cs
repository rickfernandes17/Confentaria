using System;
using System.Linq.Expressions;

namespace Confentaria.Formularios
{
    public enum SearchColumnType
    {
        String,
        Number,
        Date,
        Enum,
        Boolean
    }

    public class SearchColumnConfig<T>
    {
        public string PropertyName { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public SearchColumnType ColumnType { get; set; }
        public Expression<Func<T, object>>? PropertyExpression { get; set; }
        public Type? EnumType { get; set; }
        public bool IsNullable { get; set; }

        public SearchColumnConfig(string propertyName, string displayName, SearchColumnType columnType, Expression<Func<T, object>>? propertyExpression = null)
        {
            PropertyName = propertyName;
            DisplayName = displayName;
            ColumnType = columnType;
            PropertyExpression = propertyExpression;
        }
    }
}

