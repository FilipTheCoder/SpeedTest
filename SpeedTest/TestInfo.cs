using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class TestInfo
{
    public readonly uint Errors;
    public readonly TimeSpan time;
    private int keyCount;
    public readonly double Success;

    public TestInfo(uint errors, TimeSpan time, int keyCount)
    {
        Errors = errors;
        this.time = time;
        this.keyCount = keyCount;
        Success = 100 - ((keyCount / 100.0) * Errors);
    }

    public override string ToString()
    {
        return $"Time: {this.time.TotalSeconds} seconds\tErrors: {this.Errors}\t Succes: {this.Success}%";
    }
}

