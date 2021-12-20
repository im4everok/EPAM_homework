using System.Linq;
using System.Collections.Generic;

namespace Class
{
    public class Rectangle
    {
        private double sideA;
        private double sideB;

        public Rectangle(double a, double b)
        {
            sideA = a;
            sideB = b;
        }
        
        public Rectangle(double a)
        {
            sideA = a;
            sideB = 5;
        }
        
        public Rectangle()
        {
            sideA = 4;
            sideB = 3;
        }

        public double GetSideA() => sideA;

        public double GetSideB() => sideB;

        public double Area() => sideA * sideB;

        public double Perimeter() => 2 * (sideA + sideB);

        public bool IsSquare() => sideA == sideB;

        public void ReplaceSides()
        {
            double temp;
            temp = sideA;
            sideA = sideB;
            sideB = temp;
        }
       
    }
    public class ArrayRectangles
    {
        private readonly Rectangle[] rectangle_array;
        public ArrayRectangles(int n) => rectangle_array = new Rectangle[n];
        public ArrayRectangles(IEnumerable<Rectangle> rectangles)
        {
            rectangle_array = (Rectangle[])rectangles;
        }

        public bool AddRectangle(Rectangle rect)
        {
            for (int i = 0; i < rectangle_array.Length; i++)
            {
                if(rectangle_array[i] == null)
                {
                    rectangle_array[i] = rect;
                    return true;
                }
            }
            return false;

        }

        public int NumberMaxArea()
        {
            int maxIndex = 0;
            if(rectangle_array == null)
            {
                return 0;
            }
            for (int i = 0; i < rectangle_array.Length; i++)
            {
                for (int j = rectangle_array.Length - 1; j > 0; j--)
                {
                    if (rectangle_array[i].Area() > rectangle_array[j].Area())
                    {
                        maxIndex = i;
                    }
                    else
                    {
                        maxIndex = j;
                    }
                }
            }
            return maxIndex;
        }

        public int NumberMinPerimeter()
        {
            int minPerimIndex = 0;
            double minPerim = double.MaxValue;
            if (rectangle_array != null)
            {
                for (int i = 0; i < rectangle_array.Length; i++)
                {
                    if (rectangle_array[i] != null)
                    {
                        if (rectangle_array[i].Perimeter() < minPerim)
                        {
                            minPerim = rectangle_array[i].Perimeter();
                            minPerimIndex = i;
                        }
                    }
                }
            }
            return minPerimIndex;
        }
 
        public int NumberSquare()
        {
            int count = 0;
            if (rectangle_array != null && rectangle_array.Any())
            {
                foreach (var rectangle in rectangle_array)
                {
                    if (rectangle.IsSquare())
                    {
                        count++;
                    }
                }
                return count;
            }
            return 0;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
