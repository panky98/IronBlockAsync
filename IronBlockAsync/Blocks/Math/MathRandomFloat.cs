using System;
using System.Threading.Tasks;

namespace IronBlock.Blocks.Math
{
  public class MathRandomFloat : IBlock
  {
    static Random rand = new Random();
    public override Task<object> Evaluate(Context context) => Task.FromResult<object>(rand.NextDouble());
  }
}