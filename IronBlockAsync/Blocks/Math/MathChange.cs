using System;
using System.Threading.Tasks;

namespace IronBlock.Blocks.Math
{
  public class MathChange : IBlock
  {
    public override async Task<object> Evaluate(Context context)
    {
      var variableName = this.Fields.Get("VAR");
      var delta = (double)(await this.Values.Evaluate("DELTA", context));

      if (context.Variables.ContainsKey(variableName))
      {
        var value = (double)context.Variables[variableName];
        value += delta;
        context.Variables[variableName] = value;
      }
      else
      {
        throw new ApplicationException($"variable {variableName} not declared");
      }

      return await base.Evaluate(context);
    }
  }

}