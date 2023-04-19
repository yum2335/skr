using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedCmdChecker
{
    class mouse
    {
        private int x = System.Windows.Forms.Cursor.Position.X;
        private int y = System.Windows.Forms.Cursor.Position.Y;

        public int X
        {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }




    }
}
