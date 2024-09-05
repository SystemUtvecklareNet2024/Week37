namespace Shapes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle newCircle = new Circle(5);

            float floatCircle = (float)(5 * 5 * Math.PI);

            Console.WriteLine(newCircle.CalculateArea());

            int number = 10000;
            while(number >= 0)
            {
                Circle floatCircle1 = new Circle(5);
                Circle floatCircle2 = new Circle(5);

                if (floatCircle1.CalculateArea() == floatCircle2.CalculateArea())
                {

                }
                else
                {
                    Console.WriteLine("Not the same!!");
                }
                number--;
            }

            Rectangle rectangle = new Rectangle(10, 50d);
            Console.WriteLine(rectangle.CalculateArea());
        }
    }
}
