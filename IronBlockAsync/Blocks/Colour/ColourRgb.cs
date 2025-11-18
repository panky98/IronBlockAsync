using System;
using System.Threading.Tasks;

namespace IronBlock.Blocks.Colour
{
  public class ColourRgb : IBlock
  {
    Random random = new Random();
    public override async Task<object> Evaluate(Context context)
    {
      var red = Convert.ToByte(await this.Values.Evaluate("RED", context));
      var green = Convert.ToByte(await this.Values.Evaluate("GREEN", context));
      var blue = Convert.ToByte(await this.Values.Evaluate("BLUE", context));

      return $"#{red:x2}{green:x2}{blue:x2}";
    }
  }
}