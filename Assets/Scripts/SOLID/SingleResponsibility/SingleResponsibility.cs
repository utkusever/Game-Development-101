using UnityEngine;

namespace SOLID.SingleResponsibility
{
    public class SingleResponsibility : MonoBehaviour
    {
        // A class should have one and only one reason to change
        // Each class should have a single responsibility and focus on only one functionality.
        private void Start()
        {
            Square square = new Square(4);
            Circle circle = new Circle(10);

            ShapeAreaCalculator shapeAreaCalculator = new ShapeAreaCalculator();

            print("Area = " + shapeAreaCalculator.CalculateArea(square));
            print("Area = " + shapeAreaCalculator.CalculateArea(circle));
        }
    }

    public abstract class Shape
    {
    }

    public class Square : Shape
    {
        private float _length;

        public Square(float length)
        {
            _length = length;
        }

        public float GetLength()
        {
            return _length;
        }
    }

    public class Circle : Shape
    {
        private float _radius;

        public Circle(float radius)
        {
            _radius = radius;
        }

        public float GetRadius()
        {
            return _radius;
        }
    }

    public class ShapeAreaCalculator
    {
        public float CalculateArea(Shape shape)
        {
            return shape switch
            {
                Square square => Mathf.Pow(square.GetLength(), 2),
                Circle circle => Mathf.PI * Mathf.Pow(circle.GetRadius(), 2),
                _ => 0
            };
        }
    }
}