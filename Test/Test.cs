using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Test
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Col { get; set; }
        public Test(string name, string desc, int col)
        {
            Name = name;
            Description = desc;
            Col = col;
        }
        public Test() { }
    }
}
