﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    internal class Asteroid : ImageObject, ICollision
    {        
        public int Power { get; set; } = 3;

        public Asteroid(Point Position, Point Direction, int ImageSize)
            : base(Position, Direction, new Size(ImageSize, ImageSize), Properties.Resources.Ast)
        {
        }

        public Rectangle Rect => new Rectangle(_Position, _Size);

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);
    }
}
