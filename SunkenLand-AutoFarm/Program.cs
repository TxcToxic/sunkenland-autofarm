using System;
using System.Runtime.InteropServices;
using System.Threading;


class Farms
{
    [DllImport("user32.dll")]
    public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

    private const byte VK_F = 0x46;  // F
    private const byte VK_C = 0x43;  // C
    private const int KEYEVENTF_KEYDOWN = 0x0;
    private const int KEYEVENTF_KEYUP = 0x2;

    public static void SteelFurance()
    {
        int cfKeyPressCount = 0;

        while (true)
        {
            if (cfKeyPressCount < 6)
            {
                PressKey(VK_F);
                PressKey(VK_C);
                PressKey(VK_C);
                cfKeyPressCount++;
            }
            else
            {
                Thread.Sleep(91000);
                cfKeyPressCount = 0;
            }
        }
    }

    public static void IronFurance()
    {
        while (true)
        {
            PressKey(VK_F);
            PressKey(VK_F);
            PressKey(VK_C);
            PressKey(VK_C);
            Thread.Sleep(31000);
        }
    }

    public static void CopperFurance()
    {
        while (true)
        {
            PressKey(VK_F);
            PressKey(VK_F);
            PressKey(VK_C);
            PressKey(VK_C);
            Thread.Sleep(31000);
        }
    }

    internal static void PressKey(byte keyCode, int lenght = 35)
    {
        keybd_event(keyCode, 0, KEYEVENTF_KEYDOWN, 0);
        Thread.Sleep(lenght);
        keybd_event(keyCode, 0, KEYEVENTF_KEYUP, 0);
    }
}

namespace SunkenlandAutoFarm
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("[1] Steel Furance    [2] Iron Furance    [3] Coppper Furance");
            ConsoleKeyInfo key = Console.ReadKey();
            int timer = 5;
            while (timer > 0)
            {
                Console.Write($"\rStarting in {timer} seconds...");
                Thread.Sleep(1000);
                timer--;
            }
            
            if (key.Key == ConsoleKey.D1)
            {
                Farms.SteelFurance();
            }
            else if (key.Key == ConsoleKey.D2) 
            { 
                Farms.IronFurance();
            }
            else if (key.Key == ConsoleKey.D3)
            {
                Farms.CopperFurance();
            }
        }
        
    }
}