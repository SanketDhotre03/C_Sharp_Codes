// Program: FacadePattern
// Difficulty: Medium
// Description: Facade pattern simplifies a complex subsystem with a single interface.
using System;

class CPU        { public void Process() => Console.WriteLine("CPU processing"); }
class Memory     { public void Load()    => Console.WriteLine("Memory loading"); }
class HardDrive  { public void Read()    => Console.WriteLine("HardDrive reading"); }
class GPU        { public void Render()  => Console.WriteLine("GPU rendering"); }

class ComputerFacade
{
    CPU cpu = new CPU(); Memory mem = new Memory();
    HardDrive hd = new HardDrive(); GPU gpu = new GPU();

    public void Start()
    {
        Console.WriteLine("Starting computer...");
        mem.Load(); hd.Read(); cpu.Process(); gpu.Render();
        Console.WriteLine("Computer started.");
    }

    public void Shutdown()
    {
        Console.WriteLine("Shutting down...");
        Console.WriteLine("Computer off.");
    }
}

class FacadePattern
{
    static void Main(string[] args)
    {
        var computer = new ComputerFacade();
        computer.Start();
        computer.Shutdown();
    }
}
