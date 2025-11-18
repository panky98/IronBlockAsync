using System;
using System.Linq;
using System.Threading.Tasks;

namespace IronBlock.Blocks.Procedures
{
  public class ProceduresCallReturn : ProceduresCallNoReturn
  {
    public override async Task<object> Evaluate(Context context)
    {
      var name = this.Mutations.GetValue("name");

      if (!context.Functions.ContainsKey(name)) throw new MissingMethodException($"Method '{name}' not defined");

      var statement = (IFragment)context.Functions[name];

      var funcContext = new Context() { Parent = context };
      funcContext.Functions = context.Functions;

      var counter = 0;
      foreach (var mutation in this.Mutations.Where(x => x.Domain == "arg" && x.Name == "name"))
      {
        var value = await this.Values.Evaluate($"ARG{counter}", context);
        funcContext.Variables.Add(mutation.Value, value);
        counter++;
      }

      return await statement.Evaluate(funcContext);
    }
  }
}