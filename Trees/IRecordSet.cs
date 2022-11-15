using System;

namespace Trees
{
  public interface IRecordSet<TSource, TKey, TValue>
    where TKey : IEquatable<TKey>, IComparable<TKey>
  {
    TKey ReadKey();
    TValue ReadValue();
    void MoveNext();
    bool EOF { get; }
  }
}