﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto2
{
    public class ClButtonInfo
    {
        public int GX { get; set; }
        public int GY { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int GW { get; set; }
        public int GH { get; set; }
        public int Command { get; set; }

        public ClButtonInfo()
        {
            this.GX = 0;
            this.GY = 0;
            this.X = 0;
            this.Y = 0;
            this.GW = 0;
            this.GH = 0;
            this.Command = 0;
        }

        public ClButtonInfo(ClButtonInfo input)
        {
            this.GX = input.GX;
            this.GY = input.GY;
            this.X = input.X;
            this.Y = input.Y;
            this.GW = input.GW;
            this.GH = input.GH;
            this.Command = input.Command;
        }
    }
}
