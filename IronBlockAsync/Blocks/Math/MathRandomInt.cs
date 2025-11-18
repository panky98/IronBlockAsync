using System;
using System.Threading.Tasks;


namespace IronBlock.Blocks.Math
{
  public class MathRandomInt : IBlock
  {
    static Random rand = new Random();

    public override async Task<object> Evaluate(Context context)
    {
      var from = (double)(await this.Values.Evaluate("FROM", context));
      var to = (double)(await this.Values.Evaluate("TO", context));
      return (double)rand.Next((int)System.Math.Min(from, to), (int)System.Math.Max(from, to));
    }

  }
}