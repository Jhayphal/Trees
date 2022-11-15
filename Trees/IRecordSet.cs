using System;

namespace Trees
{
    public interface IRecordSet<TSource, TKey, TValue>
    where TKey : IEquatable<TKey>, IComparable<TKey>
  {
    bool EOF { get; }
    bool MoveNext();
    TKey ReadKey();
    TValue ReadValue();
  }
}