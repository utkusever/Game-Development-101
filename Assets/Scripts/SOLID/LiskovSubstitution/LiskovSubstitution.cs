using System.Collections.Generic;
using UnityEngine;

namespace SOLID.LiskovSubstitution
{
    //Subclasses should be substitutable for their base classes without any issues.

    public class LiskovSubstitution : MonoBehaviour
    {
        private void Start()
        {
            // square is not substitutable to its Base Rectangle, square doesnt have width and height
            // we should create another base class like Shape 

            Rectangle rectangle = new Rectangle();
            Square square = new Square();

            List<Rectangle> rectangles = new List<Rectangle> { rectangle, square };

            foreach (var r in rectangles)
            {
                r.SetHeight(10);
                r.SetWidth(7);

                print("Area = " + r.GetArea());
            }

            // Shape rectangle = new Rectangle(3,5);
            // Shape square = new Square(5);
            // List<Shape> shapes = new List<Shape> { rectangle, square };
            //
            // foreach (var shape in shapes)
            // {
            //     print("Area = " + shape.GetArea());
            // }
        }
    }

    public class Rectangle
    {
        protected float Height;
        protected float Width;

        public virtual void SetHeight(float height)
        {
            Height = height;
        }

        public virtual void SetWidth(float width)
        {
            Width = width;
        }

        public float GetArea()
        {
            return Width * Height;
        }
    }

    public class Square : Rectangle
    {
        public override void SetHeight(float height)
        {
            Height = height;
            Width = height;
        }

        public override void SetWidth(float width)
        {
            Width = width;
            Height = width;
        }
    }
    // Should be like 

    // public abstract class Shape
    // {
    //     public abstract float GetArea();
    // }
    //
    // public class Rectangle : Shape
    // {
    //     private float _height;
    //     private float _width;
    //
    //     public Rectangle(float height, float width)
    //     {
    //         _height = height;
    //         _width = width;
    //     }
    //
    //     public override float GetArea()
    //     {
    //         return _width * _height;
    //     }
    // }
    //
    // public class Square : Shape
    // {
    //     private float _side;
    //
    //     public Square(float side)
    //     {
    //         _side = side;
    //     }
    //
    //     public override float GetArea()
    //     {
    //         return _side * _side;
    //     }
    // }
}