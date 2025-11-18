using System;
using System.Linq;
using System.Threading.Tasks;

namespace IronBlock.Blocks.Colour
{
  public class ColourRandom : IBlock
  {
    Random random = new Random();
    public override Task<object> Evaluate(Context context)
    {
      var bytes = new byte[3];
      random.NextBytes(bytes);

      return Task.FromResult<object>(string.Format("#{0}", string.Join("", bytes.Select(x => string.Format("{0:x2}", x)))));
    }
  }

}