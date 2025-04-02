using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleResponsibility : MonoBehaviour
{
    private void Start()
    {
        Square square = new Square(5);
        Circle circle = new Circle(3);

        AreaCalculator areaCalculator = new AreaCalculator();

        Debug.Log("Area = " + areaCalculator.CalculateArea(square));
        Debug.Log("Area = " + areaCalculator.CalculateArea(circle));
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

    public class AreaCalculator
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