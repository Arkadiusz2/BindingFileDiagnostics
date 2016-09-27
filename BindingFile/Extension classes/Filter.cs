using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile
{
    public enum FilterOperatorEnum
    {
        Unknown = -1,
        EqualTo = 0,
        LessThan = 1,
        LessThanOrEquals = 2,
        GreaterThan = 3,
        GreaterThanOrEquals = 4,
        NotEqual = 5,
        Exists = 6,
        BitwiseAnd = 7,
        IsLike = 8
    }

    public class FilterOperator
    {
        public string Value { get; private set; }
        private string _operatorString = null;

        public string OperatorString
        {
            get
            {
                if (_operatorString == null && this.Value != null)
                {
                    _operatorString = GetOperatorString(this.Value);
                }
                return _operatorString ?? "";
            }
        }

        public FilterOperator(string value)
        {
            this.Value = value;
        }

        private string GetOperatorString(string oper)
        {
            string result = "";
            int o;
            if (int.TryParse(oper, out o))
            {
                FilterOperatorEnum filterOperator = (FilterOperatorEnum)o;
                switch (filterOperator)
                {
                    case FilterOperatorEnum.EqualTo:
                        result = "==";
                        break;

                    case FilterOperatorEnum.LessThan:
                        result = "<";
                        break;

                    case FilterOperatorEnum.LessThanOrEquals:
                        result = "<=";
                        break;

                    case FilterOperatorEnum.GreaterThan:
                        result = ">";
                        break;

                    case FilterOperatorEnum.GreaterThanOrEquals:
                        result = ">=";
                        break;

                    case FilterOperatorEnum.NotEqual:
                        result = "!=";
                        break;

                    case FilterOperatorEnum.Exists:
                        result = "Exists";
                        break;

                    case FilterOperatorEnum.BitwiseAnd:
                        result = "&";
                        break;

                    case FilterOperatorEnum.IsLike:
                        result = "like";
                        break;
                }
            }
            return result;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FilterStatement
    {
        public string Property { get; set; }
        public FilterOperator Operator { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            string s = string.Format("{0} {1}", this.Property ?? "", this.Operator.OperatorString);
            if (this.Value != null)
            {
                s += " " + this.Value;
            }
            return s;
        }
    }

    public class FilterGroup
    {
        public List<FilterStatement> FilterStatements { get; private set; }

        public FilterGroup()
        {
            this.FilterStatements = new List<FilterStatement>();
        }
    }

    public class Filter
    {
        #region Parsing methods
        public static bool TryParse(string filterExpression, out Filter filter)
        {
            Exception exception;
            return TryParse(filterExpression, out filter, out exception);
        }

        public static bool TryParse(string filterExpression, out Filter filter, out Exception exception)
        {
            XmlDocument filterXml = new XmlDocument();

            if (XmlDocumentExtensions.TryLoadXml(filterExpression, out filterXml, out exception))
            {
                filter = new Filter(filterXml);
                return true;
            }
            else
            {
                filter = null;
                return false;
            }
        }
        #endregion

        public List<FilterGroup> FilterGroups { get; private set; }
        private XmlDocument FilterXml { get; set; }
        private Dictionary<string, Dictionary<string, string>> _propertyValues = new Dictionary<string, Dictionary<string, string>>();

        public Filter(XmlDocument filterXml)
        {
            this.FilterXml = filterXml;
            ParseFilter();
        }

        private void ParseFilter()
        {
            this.FilterGroups = new List<FilterGroup>();

            foreach (XmlNode group in this.FilterXml.SelectNodes("/Filter/Group"))
            {
                FilterGroup filterGroup = new FilterGroup();

                foreach (XmlNode statement in group.SelectNodes("Statement"))
                {
                    XmlAttribute property = statement.Attributes["Property"];
                    XmlAttribute oper = statement.Attributes["Operator"];
                    XmlAttribute value = statement.Attributes["Value"];

                    string propertyValue = (property != null) ? property.Value : null;
                    string operValue = (oper != null) ? oper.Value : null;
                    string valueValue = (value != null) ? value.Value : null;

                    FilterStatement filterStatement = new FilterStatement();
                    filterStatement.Property = propertyValue;
                    filterStatement.Operator = new FilterOperator(oper.Value);
                    filterStatement.Value = valueValue;

                    filterGroup.FilterStatements.Add(filterStatement);

                    AddPropertyValue(propertyValue, valueValue);
                }

                this.FilterGroups.Add(filterGroup);
            }
        }

        private void AddPropertyValue(string propertyName, string propertyValue)
        {
            if (propertyName != null && propertyValue != null)
            {
                if (_propertyValues.ContainsKey(propertyName))
                {
                    Dictionary<string, string> propertyValues = _propertyValues[propertyName];
                    if (!propertyValues.ContainsKey(propertyValue))
                    {
                        propertyValues.Add(propertyValue, null);
                    }
                }
                else
                {
                    Dictionary<string, string> propertyValues = new Dictionary<string,string>();
                    propertyValues.Add(propertyValue, null);

                    _propertyValues.Add(propertyName, propertyValues);
                }
            }
        }

        public IEnumerable<string> BTS_ReceivePortNames
        {
            get
            {
                return GetPropertyValues("BTS.ReceivePortName");
            }
        }

        public IEnumerable<string> ErrorReport_ReceivePortNames
        {
            get
            {
                return GetPropertyValues("ErrorReport.ReceivePortName");
            }
        }

        public IEnumerable<string> ErrorReport_SendPortNames
        {
            get
            {
                return GetPropertyValues("ErrorReport.SendPortName");
            }
        }

        public IEnumerable<string> GetPropertyValues(string propertyName)
        {
            if (_propertyValues.ContainsKey(propertyName))
            {
                return _propertyValues[propertyName].Keys;
            }
            return Enumerable.Empty<string>();
        }
    }
}
