using System;
using System.Collections.Generic;

namespace Trees
{
  public interface INode<TKey, TValue> : IEquatable<INode<TKey, TValue>>, IComparable<INode<TKey, TValue>>
    where TKey : IEquatable<TKey>, IComparable<TKey>
  {
    TKey Key { get; }

    TValue Value { get; }

    IReadOnlyCollection<INode<TKey, TValue>> Children { get; }

    INode<TKey, TValue> Parent { get; }
  }
}
