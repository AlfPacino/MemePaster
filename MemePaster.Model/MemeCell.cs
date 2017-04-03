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
        public MemeCell(byte[] imageBytes)
        {
            this.Image = imageBytes;
        }
        public byte[] Image { get; set; }
    }
}
