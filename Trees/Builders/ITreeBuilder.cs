using System;

namespace Trees.Builders
{
  public interface ITreeBuilder<TSource, TKey, TValue>
    where TKey : IEquatable<TKey>, IComparable<TKey>
  {
    INode<TKey, TValue> Build(IRecordSet<TSource, TKey, TValue> recordSet);
  }
}