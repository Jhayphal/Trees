using System;

namespace Trees
{
  public readonly struct GenericRecordSet<TSource, TKey, TValue> : IRecordSet<TSource, TKey, TValue>
    where TKey : IEquatable<TKey>, IComparable<TKey>
  {
    private readonly TSource source;
    private readonly Func<TSource, TKey> readKey;
    private readonly Func<TSource, TValue> readValue;
    private readonly Action<TSource> moveNext;
    private readonly Func<TSource, bool> eof;

    public GenericRecordSet(
      TSource source,
      Func<TSource, TKey> readKey,
      Func<TSource, TValue> readValue,
      Action<TSource> moveNext,
      Func<TSource, bool> eof)
    {
      if (ReferenceEquals(source, null))
      {
        throw new ArgumentNullException(nameof(source));
      }

      this.source = source;

      if (ReferenceEquals(readKey, null))
      {
        throw new ArgumentNullException(nameof(readKey));
      }

      this.readKey = readKey;

      if (ReferenceEquals(readValue, null))
      {
        throw new ArgumentNullException(nameof(readValue));
      }

      this.readValue = readValue;

      if (ReferenceEquals(moveNext, null))
      {
        throw new ArgumentNullException(nameof(moveNext));
      }

      this.moveNext = moveNext;

      if (ReferenceEquals(eof, null))
      {
        throw new ArgumentNullException(nameof(eof));
      }

      this.eof = eof;
    }

    public TKey ReadKey() => readKey(source);

    public TValue ReadValue() => readValue(source);

    public void MoveNext() => moveNext(source);

    public bool EOF => eof(source);
  }
}