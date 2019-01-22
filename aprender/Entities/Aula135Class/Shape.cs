using aprender.Entities.enums;

namespace aprender.Entities.Aula135Class
{
    abstract class Shape
    {
        public Color Color { get; set; }

        public Shape(Color color)
        {
            Color = color;
        }

        public abstract double Area();
    }
}
