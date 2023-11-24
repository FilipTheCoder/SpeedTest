using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


internal class SpeedTest
{
    public uint Errors { get; set; } = 0;
    public readonly string Sentence;
    public readonly ConsoleColor errorColor = ConsoleColor.Red;
    public readonly ConsoleColor correctColor = ConsoleColor.Green;
    internal string[] sentences = ["In these two examples, the character becomes a friend and helper to the hero.", "Patients will receive information through their computers on how to manage their disease.", "The laws were designed to prosecute people who hack into computers and steal information."];
    private char key;
    internal string exceptedKeys = "QWERTZUIOPLKJHGFDSAYXCVBNMqwertzuioplkjhgfdsayxcvbnm!?., 1234567890";
    private int row = 0;
    private int col = 0;
    private Stopwatch timer = new();


    public SpeedTest(string sentence) 
    { 
        this.Sentence = sentence;
    }
    public SpeedTest()
    {
        int index = RandomNumberGenerator.GetInt32(sentences.Length);
        this.Sentence = this.sentences[index];
    }

    public TestInfo Test()
    {
        this.timer.Start();
        for (; this.col < this.Sentence.Length; this.col++)
        {
            UserInputWithChecks();
            if (this.key != this.Sentence[this.col])
            {
                WriteCharWithColor(this.errorColor, Console.CursorLeft , Console.CursorTop);
                this.Errors++;
            }
            else 
            {
                WriteCharWithColor(this.correctColor, Console.CursorLeft, Console.CursorTop); ;
            }



        }

        this.timer.Stop();
        Console.WriteLine();
        return new(this.Errors, this.timer.Elapsed, this.Sentence.Length);


    }
    
    public void WriteCharWithColor(ConsoleColor color, int endColumn, int endRow)
    {
        Console.CursorTop = this.row;
        Console.CursorLeft = this.col;
        Console.ForegroundColor = color;
        Console.Write(this.Sentence[this.col]);
        Console.ResetColor();
        Console.CursorLeft = endColumn;
        Console.CursorTop = endRow;
    }

    private void UserInputWithChecks()
    {

        do
        {
            this.key = Console.ReadKey().KeyChar;
        } while (!this.exceptedKeys.Contains(this.key));

    }

}

