using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    internal class Asteroid : ImageObject, ICollision
    {        
        public Asteroid(Point Position, Point Direction, int ImageSize)        
        : base(Position, Direction, new Size(ImageSize, ImageSize), Properties.Resources.Ast)
        {
        }
        public Rectangle Rect => new Rectangle(_Position, _Size);
        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);
        public override void Update()
        {
            _Position.X += _Direction.X;
            _Position.Y += _Direction.Y;
            if (_Position.X < 0)
                _Direction.X *= -1;
            if (_Position.Y < 0)
                _Direction.Y *= -1;
            if (_Position.X > Game.Width)
                _Direction.X *= -1;
            if (_Position.Y > Game.Height)
                _Direction.Y *= -1;
        }
    }
}
