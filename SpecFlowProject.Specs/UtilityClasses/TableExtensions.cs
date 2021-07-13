using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Specs.UtilityClasses
{
    class TableExtensions
    {
        public static DataTable ToDataTable(Table table)
        {
            var dataTable = new DataTable();
            foreach (var header in table.Header)
            {
                dataTable.Columns.Add(header, typeof(string));
            }

            foreach (var row in table.Rows)
            {
                var newRow = dataTable.NewRow();
                foreach (var header in table.Header)
                {

                    newRow.SetField(header, row[header]);
                }
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

    }
}
