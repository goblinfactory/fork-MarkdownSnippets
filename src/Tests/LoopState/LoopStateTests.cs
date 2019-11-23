using System;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;
using Xunit.Abstractions;

public class LoopStateTests :
    VerifyBase
{
    [Fact]
    public Task TrimIndentation()
    {
        var loopState = new LoopState("key", s => throw new Exception(), 1);
        loopState.AppendLine("   Line1");
        loopState.AppendLine("    Line2");
        loopState.AppendLine("   Line2");
        return Verify(loopState.GetLines());
    }

    [Fact]
    public Task ExcludeEmptyPaddingLines()
    {
        var loopState = new LoopState("key", s => throw new Exception(), 1);
        loopState.AppendLine("   ");
        loopState.AppendLine("    Line2");
        loopState.AppendLine("   ");
        return Verify(loopState.GetLines());
    }

    [Fact]
    public Task TrimIndentation_with_mis_match()
    {
        var loopState = new LoopState("key", s => throw new Exception(), 1);
        loopState.AppendLine("      Line2");
        loopState.AppendLine("   ");
        loopState.AppendLine("     Line4");
        return Verify(loopState.GetLines());
    }

    [Fact]
    public Task ExcludeEmptyPaddingLines_empty_list()
    {
        var loopState = new LoopState("key", s => throw new Exception(), 1);
        return Verify(loopState.GetLines());
    }

    [Fact]
    public Task ExcludeEmptyPaddingLines_whitespace_list()
    {
        var loopState = new LoopState("key", s => throw new Exception(), 1);
        loopState.AppendLine("");
        loopState.AppendLine("  ");
        return Verify(loopState.GetLines());
    }

    [Fact]
    public Task TrimIndentation_no_initial_padding()
    {
        var loopState = new LoopState("key", s => throw new Exception(), 1);
        loopState.AppendLine("Line1");
        loopState.AppendLine("    Line2");
        loopState.AppendLine("   Line2");
        return Verify(loopState.GetLines());
    }

    public LoopStateTests(ITestOutputHelper output) :
        base(output)
    {
    }
}