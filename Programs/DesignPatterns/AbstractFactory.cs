// Program: AbstractFactory
// Difficulty: High
// Description: Abstract Factory pattern for creating families of related objects.
using System;

interface IButton  { void Render(); }
interface ITextBox { void Render(); }

class WindowsButton  : IButton  { public void Render() => Console.WriteLine("Windows Button"); }
class WindowsTextBox : ITextBox { public void Render() => Console.WriteLine("Windows TextBox"); }
class MacButton      : IButton  { public void Render() => Console.WriteLine("Mac Button"); }
class MacTextBox     : ITextBox { public void Render() => Console.WriteLine("Mac TextBox"); }

interface IUIFactory { IButton CreateButton(); ITextBox CreateTextBox(); }

class WindowsFactory : IUIFactory
{
    public IButton  CreateButton()  => new WindowsButton();
    public ITextBox CreateTextBox() => new WindowsTextBox();
}

class MacFactory : IUIFactory
{
    public IButton  CreateButton()  => new MacButton();
    public ITextBox CreateTextBox() => new MacTextBox();
}

class AbstractFactory
{
    static void RenderUI(IUIFactory factory)
    {
        factory.CreateButton().Render();
        factory.CreateTextBox().Render();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Windows UI:");
        RenderUI(new WindowsFactory());
        Console.WriteLine("Mac UI:");
        RenderUI(new MacFactory());
    }
}
