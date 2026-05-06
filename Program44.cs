using System;

class Program44
{
    public delegate void Notify(string message);

    static void Main()
    {
        Notify notifier = ShowMessage;
        notifier("Event triggered using delegate");
    }

    static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}
