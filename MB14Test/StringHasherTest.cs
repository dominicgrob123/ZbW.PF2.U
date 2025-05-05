using MB14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB14Test
{
  [TestClass]
  public class StringHasherTest
  {
    [TestMethod]
    public void Execute_All_For_Foo()
    {
      // arrange
      var foo = "foo";

      // act
      var additive = StringHasher.AdditiveHash(foo);
      var djb2 = StringHasher.Djb2(foo);
      var folding = StringHasher.FoldingHash(foo);

      // assert

      Console.WriteLine($"Additive: {additive}");
      Console.WriteLine($"Folding:  {folding}");
      Console.WriteLine($"DJB2:     {djb2}");
    }

    [TestMethod]
    public void ExecuteAll_For_Oof()
    {
      // arrange
      var foo = "oof";

      // act
      var additive = StringHasher.AdditiveHash(foo);
      var djb2 = StringHasher.Djb2(foo);
      var folding = StringHasher.FoldingHash(foo);

      // assert

      Console.WriteLine($"Additive: {additive}");
      Console.WriteLine($"Folding:  {folding}");
      Console.WriteLine($"DJB2:     {djb2}");
    }
  }
}
