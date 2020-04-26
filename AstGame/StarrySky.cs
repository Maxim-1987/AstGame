using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame
{
    class StarrySky: VisualObject
    {
        public StarrySky(Point Position, Point Direction, int Size)
            : base(Position, Direction, new Size(Size, Size))
        {

        }
        public override void Draw(Graphics g)
        {
            g.DrawLine(Pens.Red, _Position.X, _Position.Y, _Position.X + _Size.Width, _Position.Y + _Size.Height);
            g.DrawLine(Pens.Red, _Position.X + _Size.Width, _Position.Y, _Position.X, _Position.Y + _Size.Height);          
        }

        public override void Update()
        {
            _Position.Y += _Direction.Y;
            if (_Position.Y < 0)
                _Position.Y = Game.Height + _Size.Height;
        }        
    }
}
