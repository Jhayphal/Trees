using System;

namespace Trees
{
  public static class EqualityOperators<TValue> where TValue : class, IEquatable<TValue>
  {
    public static bool Equals(TValue a, TValue b)
      => ReferenceEquals(a, b) || !ReferenceEquals(a, null) && a.Equals(b);

    public static bool NotEquals(TValue a, TValue b)
      => !ReferenceEquals(a, b) && (ReferenceEquals(a, null) || !a.Equals(b));
  }
}