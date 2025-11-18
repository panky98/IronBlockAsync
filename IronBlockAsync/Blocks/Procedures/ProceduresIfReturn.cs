using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace IronBlock.Blocks.Procedures
{
  public class ProceduresIfReturn : IBlock
  {
    public override async Task<object> Evaluate(Context context)
    {
      var condition = await this.Values.Evaluate("CONDITION", context);
      if ((bool)condition)
      {
        return await this.Values.Evaluate("VALUE", context);
      }

      return await base.Evaluate(context);
    }

    public override SyntaxNode Generate(Context context)
    {
      var condition = this.Values.Generate("CONDITION", context) as ExpressionSyntax;
      if (condition == null) throw new ApplicationException($"Unknown expression for condition.");

      ReturnStatementSyntax returnStatement = ReturnStatement();

      if (this.Values.Any(x => x.Name == "VALUE"))
      {
        var statement = this.Values.Generate("VALUE", context) as ExpressionSyntax;
        if (statement == null) throw new ApplicationException($"Unknown expression for return statement.");

        returnStatement = ReturnStatement(statement);
      }

      var ifStatement = IfStatement(condition, returnStatement);
      return Statement(ifStatement, base.Generate(context), context);
    }
  }
}