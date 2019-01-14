using JetBrains.Annotations;

namespace BowlingTest
{
    public static class SourceTemplate
    {
        [SourceTemplate]
        [Macro(Target = "expected", Expression = "suggestVariableName()")]
        public static void ae(this object source)
        {
            /*$ Assert.AreEqual( $expected$ , source);*/
        }
    }
}