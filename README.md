# IronBlock (Async Fork)

**IronBlock** --- a .NET interpreter for Blockly‑style block programs,
reworked for asynchronous execution.

## 📦 What is IronBlock

IronBlock allows you to parse and execute Blockly‑style block
definitions --- defined as XML --- from within .NET. This fork builds on
the original IronBlock by adding support for asynchronous evaluation and
modern .NET workloads, making it easier to embed Blockly‑style scripting
in ASP.NET, Blazor, serverless or any async‑heavy environment.

It's useful for:

-   Running Blockly‑generated logic on the server side.
-   Embedding Blockly scripting in .NET backends or desktop apps.
-   Allowing client‑side Blockly editing + server‑side execution.

## 🔧 Getting Started

### Installation

``` bash
dotnet add package IronBlockAsync
```

### Prerequisites

-   .NET Standard 2.0 or newer
-   Async/await support

## 🚀 Basic Usage

``` csharp
using IronBlock;
using IronBlock.Blocks;
using System.Threading.Tasks;

async Task RunBlockAsync(string xml)
{
    var parser = new Parser();
    parser.AddStandardBlocks();
    var workspace = parser.Parse(xml);

    var result = await workspace.Evaluate();
    Console.WriteLine(result);
}
```

## 🧩 Custom Blocks

``` csharp
public class MyCustomBlock : IBlock
{
    public override Task<object> Evaluate(Context context)
    {
        // Your custom logic
    }
}
```

## 🎯 What's New / Differences from Upstream

-   Added asynchronous execution (`EvaluateAsync`)
-   Improved extensibility

## 📚 Documentation & Links

-   Original project: https://github.com/richorama/IronBlock

## 👍 Contributing

Pull requests and issues are welcome.

## 📝 License

MIT License.
