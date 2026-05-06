// Program: BridgePattern
// Difficulty: High
// Description: Bridge pattern separates abstraction from implementation.
using System;

interface IRenderer { void RenderCircle(double r); void RenderSquare(double s); }

class VectorRenderer : IRenderer
{
    public void RenderCircle(double r) => Console.WriteLine($"Drawing circle (vector) r={r}");
    public void RenderSquare(double s) => Console.WriteLine($"Drawing square (vector) s={s}");
}

class RasterRenderer : IRenderer
{
    public void RenderCircle(double r) => Console.WriteLine($"Drawing circle (raster) r={r}");
    public void RenderSquare(double s) => Console.WriteLine($"Drawing square (raster) s={s}");
}

abstract class Shape
{
    protected IRenderer renderer;
    protected Shape(IRenderer renderer) => this.renderer = renderer;
    public abstract void Draw();
}

class Circle : Shape
{
    double radius;
    public Circle(IRenderer r, double rad) : base(r) => radius = rad;
    public override void Draw() => renderer.RenderCircle(radius);
}

class Square : Shape
{
    double side;
    public Square(IRenderer r, double s) : base(r) => side = s;
    public override void Draw() => renderer.RenderSquare(side);
}

class BridgePattern
{
    static void Main(string[] args)
    {
        Shape[] shapes = {
            new Circle(new VectorRenderer(), 5),
            new Square(new RasterRenderer(), 3),
            new Circle(new RasterRenderer(), 8)
        };
        foreach (var s in shapes) s.Draw();
    }
}
