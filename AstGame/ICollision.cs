﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    internal interface ICollision
    {
        Rectangle Rect { get; }
        bool CheckCollision(ICollision obj);
    }
}
