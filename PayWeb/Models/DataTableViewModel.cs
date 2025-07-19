using System.Collections.Generic;

namespace PayWeb.Models
{
    public class DataTableViewModel
    {
        public string? TableId { get; set; }
        public List<DataTableColumn>? Columns { get; set; }
        public List<object>? Data { get; set; }
        public string? FormId { get; set; }
        public string? EntityName { get; set; }
    }

    public class DataTableColumn
    {
        public string? Field { get; set; }
        public string? Title { get; set; }
        public bool Orderable { get; set; } = true;
        public string? Width { get; set; }
        public string DataType { get; set; } = "text";
        public bool Searchable { get; set; } = true;
    }
}