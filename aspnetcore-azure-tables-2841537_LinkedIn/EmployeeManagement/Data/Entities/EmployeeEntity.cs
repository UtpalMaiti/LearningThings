using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Data.Entities
{
    public class EmployeeEntity:TableEntity
    {
        public EmployeeEntity()
        {
            PartitionKey = Guid.NewGuid().ToString();
            RowKey = Guid.NewGuid().ToString();
        }

        public EmployeeEntity(string department)
        {
            PartitionKey = department;
            RowKey = Guid.NewGuid().ToString();
        }

        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
