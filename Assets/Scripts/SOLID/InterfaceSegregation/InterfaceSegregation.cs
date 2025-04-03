using UnityEngine;

namespace SOLID.InterfaceSegregation
{
    // A class should not depend on a large interface that includes methods it does not use.
    // Instead of a large interface, smaller and more specific interfaces should be created.
    public class InterfaceSegregation : MonoBehaviour
    {
        private void Start()
        {
            Square square = new Square(10);
            Cube cube = new Cube(10);

            print("Area = " + square.GetArea());
            print("Volume = " + cube.GetVolume());
        }
    }

    public interface ITwoDimensionalShape
    {
        float GetArea();
    }

    public interface IThreeDimensionalShape
    {
        float GetVolume();
    }

    public class Square : ITwoDimensionalShape
    {
        private float _length;

        public Square(float length)
        {
            _length = length;
        }

        public float GetArea()
        {
            return Mathf.Pow(_length, 2);
        }
    }

    public class Cube : IThreeDimensionalShape
    {
        private float _length;

        public Cube(float length)
        {
            _length = length;
        }

        public float GetVolume()
        {
            return Mathf.Pow(_length, 3);
        }
    }
}