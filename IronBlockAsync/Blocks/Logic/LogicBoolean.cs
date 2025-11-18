using System;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace IronBlock.Blocks.Logic
{
  public class LogicBoolean : IBlock
  {
    public override Task<object> Evaluate(Context context)
    {
      return Task.FromResult<object>(bool.Parse(this.Fields.Get("BOOL")));
    }

    public override SyntaxNode Generate(Context context)
    {
      bool value = bool.Parse(this.Fields.Get("BOOL"));
      if (value)
        return LiteralExpression(SyntaxKind.TrueLiteralExpression);

      return LiteralExpression(SyntaxKind.FalseLiteralExpression);
    }
  }
}