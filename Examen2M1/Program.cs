using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examen2M1.Poco;

namespace Examen2M1
{
    static class Program
    {
        public static int ID = 0;
        public static List<Prestamo> Prestamos;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDIPrestamos());
        }
    }
}
