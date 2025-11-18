using System;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace IronBlock.Blocks.Logic
{
  public class LogicNull : IBlock
  {
    public override Task<object> Evaluate(Context context)
    {
      return Task.FromResult<object>(null);
    }

    public override SyntaxNode Generate(Context context)
    {
      return ReturnStatement(
            LiteralExpression(
              SyntaxKind.NullLiteralExpression
            )
          );
    }
  }

}