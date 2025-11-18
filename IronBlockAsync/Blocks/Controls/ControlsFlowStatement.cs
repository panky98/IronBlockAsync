using System;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace IronBlock.Blocks.Controls
{
  public class ControlsFlowStatement : IBlock
  {
    public override Task<object> Evaluate(Context context)
    {
      var flow = this.Fields.Get("FLOW");
      if (flow == "CONTINUE")
      {
        context.EscapeMode = EscapeMode.Continue;
        return Task.FromResult<object>(null);
      }

      if (flow == "BREAK")
      {
        context.EscapeMode = EscapeMode.Break;
        return Task.FromResult<object>(null);
      }

      throw new NotSupportedException($"{flow} flow is not supported");
    }

    public override SyntaxNode Generate(Context context)
    {
      var flow = this.Fields.Get("FLOW");
      if (flow == "CONTINUE")
      {
        return ContinueStatement();
      }

      if (flow == "BREAK")
      {
        return BreakStatement();
      }

      throw new NotSupportedException($"{flow} flow is not supported");
    }
  }

}