using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Model
{
    class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public Category() { }
        public override string ToString() => $"{CategoryName}";
    }
}
