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

            //g.DrawLine(Pens.Red, _Position.X, _Position.Y, _Position.X + _Size.Width / 2, _Position.Y + _Size.Height / 2);
            //g.DrawLine(Pens.Red, _Position.X + _Size.Width / 2, _Position.Y + _Size.Height / 2, _Position.X, _Position.Y + _Size.Height / 2);
            //g.DrawLine(Pens.Red, _Position.X, _Position.Y, _Position.X, _Position.Y + _Size.Height);
        }

        public override void Update()
        {
            //_Position.X += _Direction.X;
            //_Position.Y += _Direction.Y;
            //if (_Position.Y < 0)
            //    _Direction.Y = -_Direction.Y;
            //if (_Position.X < 0)
            //    _Direction.X = -_Direction.X;
            //if (_Position.Y > Game.Height)
            //    _Direction.Y = -_Direction.Y;
            //if (_Position.X > Game.Width)
            //    _Direction.X = -_Direction.X;

            _Position.Y += _Direction.Y;
            if (_Position.Y < 0)
                _Position.Y = Game.Height + _Size.Height;
        }        
    }
}
