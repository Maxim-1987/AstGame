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
        public int Power { get; set; } = 10;

        public Asteroid(Point Position, Point Direction, int ImageSize)
            : base(Position, Direction, new Size(ImageSize, ImageSize), Properties.Resources.Ast)
        {
        }

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);

        public override void Update()
        {
            base.Update();
        }
        public static List<Asteroid> NewAsteroidCollection(Random random, int Width, int Height, int asteroid_max_speed, int asteroid_count, int asteroid_size)
        {
            var result = new List<Asteroid>();
            for (var i = 0; i < asteroid_count; i++)
            {
                result.Add(new Asteroid(
                                    new Point(random.Next(0, Width), random.Next(0, Height)),
                                    new Point(-1 * random.Next(1, asteroid_max_speed), 0),
                                    random.Next(10, asteroid_size)));
            }
            return result;
        }
    }
}
