using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemePaster.Model
{
    public class MemeCell
    {
        public MemeCell(){}
        public MemeCell(byte[] imageBytes, short posX, short posY)
        {
            this.Image = imageBytes;
            this.PosX = posX;
            this.PosY = posY;
        }
        public byte[] Image { get; set; }
        public short PosX { get; set; }
        public short PosY { get; set; }
    }
}
