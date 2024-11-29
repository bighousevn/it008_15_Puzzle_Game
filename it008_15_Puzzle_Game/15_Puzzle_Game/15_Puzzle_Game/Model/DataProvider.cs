using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Puzzle_Game.Model
{
    public class DataProvider
    {
       private static DataProvider instance;
       public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
            set { instance = value; }
        }
        public PuzzleGameDBEntities2 DB { get; set; }
        private DataProvider()
        {
            DB= new PuzzleGameDBEntities2 ();  
        }
    }
}
