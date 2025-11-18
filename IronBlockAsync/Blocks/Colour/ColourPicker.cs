using System.Threading.Tasks;

namespace IronBlock.Blocks.Colour
{
  public class ColourPicker : IBlock
  {
    public override Task<object> Evaluate(Context context)
    {
      return Task.FromResult<object>(this.Fields.Get("COLOUR") ?? "#000000");
    }
  }
}