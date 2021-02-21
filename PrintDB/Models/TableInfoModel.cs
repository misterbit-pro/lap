using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintDB.Models
{
    public class TableInfoModel
    {
        public string Field { get; set; }
        public string Type { get; set; }
        public string Null { get; set; }
        public string Key { get; set; }
        public string Default { get; set; }
        public string Extra { get; set; }

        public TableInfoModel(){ }

        public TableInfoModel(string field, string type, string @null, string key, string @default, string extra)
        {
            Field = field;
            Type = type;
            Null = @null;
            Key = key;
            Default = @default;
            Extra = extra;
        }
    }
}
