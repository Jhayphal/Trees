namespace Trees.Builders
{
  public class PrefixTreeBuilder<TSource, TValue> : RecordSetTreeBuilder<TSource, string, TValue>
  {
    protected override bool IsChild(string parent, string maybeChild)
      => maybeChild?.StartsWith(parent) ?? false;
  }
}