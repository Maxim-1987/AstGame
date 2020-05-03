using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    class MedicineChest: ImageObject, ICollision
    {
        public MedicineChest(Point Position, Point Direction, Size Size)
            : base(Position, Direction, Size, Properties.Resources.Apteka1)
        {
        }

        public int Power { get; internal set; } = 10;

        public bool CheckCollision(ICollision obj)
        {
            return Rect.IntersectsWith(obj.Rect);
        }

        public override void Update()
        {
            _Position = new Point(
                _Position.X + _Direction.X,
                _Position.Y + _Direction.Y);

            if (_Position.X < 0)
                _Position = new Point(Game.Width, _Position.Y + _Direction.Y);
        }
    }
}
