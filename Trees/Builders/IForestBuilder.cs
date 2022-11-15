using System;
using System.Collections.Generic;

namespace Trees.Builders
{
  public interface IForestBuilder<TSource, TKey, TValue>
    where TKey : IEquatable<TKey>, IComparable<TKey>
  {
    IEnumerable<INode<TKey, TValue>> BuildForest(IRecordSet<TSource, TKey, TValue> recordSet);
  }
}