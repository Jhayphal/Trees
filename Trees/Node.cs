using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Trees
{

  [DebuggerDisplay("{Key}: {Value}")]
  public class Node<TKey, TValue> : INode<TKey, TValue>
    where TKey : IEquatable<TKey>, IComparable<TKey>
  {
    private readonly HashSet<INode<TKey, TValue>> children = new HashSet<INode<TKey, TValue>>();

    public Node(TKey key, TValue value)
    {
      Key = key;
      Value = value;
    }

    public TKey Key { get; }

    public TValue Value { get; }

    public IReadOnlyCollection<INode<TKey, TValue>> Children => children;

    public INode<TKey, TValue> Parent { get; protected set; }

    public virtual bool AddChild(Node<TKey, TValue> child)
    {
      child.Parent = this;
      return children.Add(child);
    }

    public override int GetHashCode() => Key.GetHashCode();

    public override bool Equals(object obj) => Equals(obj as INode<TKey, TValue>);

    public override string ToString() => Key.ToString();

    public int CompareTo(INode<TKey, TValue> other)
      => other is null
        ? 1
        : Key.CompareTo(other.Key);

    public bool Equals(INode<TKey, TValue> other) => !(other is null) && Key.Equals(other.Key);

    public static bool operator ==(Node<TKey, TValue> a, Node<TKey, TValue> b)
      => EqualityOperators<INode<TKey, TValue>>.Equals(a, b);

    public static bool operator !=(Node<TKey, TValue> a, Node<TKey, TValue> b)
      => EqualityOperators<INode<TKey, TValue>>.NotEquals(a, b);

    public static bool operator >=(Node<TKey, TValue> a, Node<TKey, TValue> b)
      => ComparisonOperators<INode<TKey, TValue>>.BiggerOrEqualThan(a, b);

    public static bool operator <=(Node<TKey, TValue> a, Node<TKey, TValue> b)
      => ComparisonOperators<INode<TKey, TValue>>.LessOrEqualThan(a, b);

    public static bool operator >(Node<TKey, TValue> a, Node<TKey, TValue> b)
      => ComparisonOperators<INode<TKey, TValue>>.BiggerThan(a, b);

    public static bool operator <(Node<TKey, TValue> a, Node<TKey, TValue> b)
      => ComparisonOperators<INode<TKey, TValue>>.LessThan(a, b);
  }
}