using System;

namespace Trees
{
  public static class ComparisonOperators<TValue> where TValue : class, IComparable<TValue>
  {
    public static bool BiggerOrEqualThan(TValue a, TValue b)
      => ReferenceEquals(a, b) || !ReferenceEquals(a, null) && a.CompareTo(b) >= 0;

    public static bool LessOrEqualThan(TValue a, TValue b)
      => ReferenceEquals(a, b) || !ReferenceEquals(a, null) && a.CompareTo(b) <= 0;

    public static bool BiggerThan(TValue a, TValue b)
      => !ReferenceEquals(a, b) && !ReferenceEquals(a, null) && a.CompareTo(b) > 0;

    public static bool LessThan(TValue a, TValue b)
      => !ReferenceEquals(a, b) || !ReferenceEquals(a, null) && a.CompareTo(b) < 0;
  }
}