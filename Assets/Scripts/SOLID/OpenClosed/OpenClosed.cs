using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClosed : MonoBehaviour
{
    // Entities (classes, modules, components etc.) should be open for extension but closed for modification.
    // This means we should be able to add new functionality without changing existing code.
    // Instead of modifying a ShapeAreaCalculator class for new shapes, each shape should have its own GetArea()
    private void Start()
    {
        Square square = new Square(4);
        Circle circle = new Circle(10);

        Debug.Log("Area = " + square.GetArea());
        Debug.Log("Area = " + circle.GetArea());
    }
}

public abstract class Shape
{
    public abstract float GetArea();
}

public class Square : Shape
{
    private float _length;

    public Square(float length)
    {
        _length = length;
    }

    public override float GetArea()
    {
        return Mathf.Pow(_length, 2);
    }
}

public class Circle : Shape
{
    private float _radius;

    public Circle(float radius)
    {
        _radius = radius;
    }

    public override float GetArea()
    {
        return Mathf.PI * Mathf.Pow(_radius, 2);
    }
}