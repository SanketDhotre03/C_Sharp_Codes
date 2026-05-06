// Program: CommandPattern
// Difficulty: High
// Description: Command pattern encapsulates actions as objects (with undo support).
using System;
using System.Collections.Generic;

interface ICommand { void Execute(); void Undo(); }

class TextEditor
{
    string text = "";
    public string Text => text;
    public void InsertText(string t) => text += t;
    public void DeleteLast(int count) => text = text.Length > count ? text[..^count] : "";
}

class InsertCommand : ICommand
{
    TextEditor editor; string text;
    public InsertCommand(TextEditor e, string t) { editor = e; text = t; }
    public void Execute() => editor.InsertText(text);
    public void Undo() => editor.DeleteLast(text.Length);
}

class CommandHistory
{
    Stack<ICommand> history = new Stack<ICommand>();
    public void Execute(ICommand cmd) { cmd.Execute(); history.Push(cmd); }
    public void Undo() { if (history.Count > 0) history.Pop().Undo(); }
}

class CommandPattern
{
    static void Main(string[] args)
    {
        var editor = new TextEditor();
        var history = new CommandHistory();
        history.Execute(new InsertCommand(editor, "Hello"));
        Console.WriteLine(editor.Text);
        history.Execute(new InsertCommand(editor, " World"));
        Console.WriteLine(editor.Text);
        history.Undo();
        Console.WriteLine(editor.Text);
        history.Undo();
        Console.WriteLine($"Empty: '{editor.Text}'");
    }
}
