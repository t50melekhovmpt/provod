using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prov
{
    internal class Class1
    {
        public int position;
        int min, max;

        public Class1(int max)
        {
            min = 0;
            this.max = max;
        }

        public void Down()
        {
            if (position + 1 < max)
            {
                EraseArrow();
                DrawArrow(++position);
            }
        }

        public void Up()
        {
            if (position > min)
            {
                EraseArrow();
                DrawArrow(--position);
            }
        }

        public void DrawArrow(int line)
        {
            position = line;
            Console.SetCursorPosition(0, line);
            Console.WriteLine("->");
        }

        private void EraseArrow()
        {
            Console.SetCursorPosition(0, position);
            Console.Write("  ");
        }
    }
}
