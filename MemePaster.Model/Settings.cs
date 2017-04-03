using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemePaster.Model
{
    [Serializable]
    public class Settings
    {
        public Settings()
        {
            this.MemeCells = GenerateDefaultMemes();
            this.WindowHeight = 300;
            this.WindowWidth = 400;
            MemeImageHeight = 150;
            MemeImageWidth = 150;
        }
        public static List<MemeCell> GenerateDefaultMemes()
        {
            var memeCells = new List<MemeCell>();
            //
            return memeCells;
        }
        public List<MemeCell> MemeCells { get; set; }
        public double WindowWidth { get; set; }
        public double WindowHeight { get; set; }
        public short MemeImageHeight { get; set; }
        public short MemeImageWidth { get; set; }
    }
}
