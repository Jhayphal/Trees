using System;
using System.Collections.Generic;

namespace Trees.Builders
{
  public abstract class RecordSetTreeBuilder<TSource, TKey, TValue> : ITreeBuilder<TSource, TKey, TValue>,
    IForestBuilder<TSource, TKey, TValue>
    where TKey : IEquatable<TKey>, IComparable<TKey>
  {
    public IEnumerable<INode<TKey, TValue>> BuildForest(IRecordSet<TSource, TKey, TValue> recordSet)
    {
      INode<TKey, TValue> root;
      while ((root = Build(recordSet)) != null)
      {
        yield return root;
      }
    }

    public INode<TKey, TValue> Build(IRecordSet<TSource, TKey, TValue> recordSet)
    {
      if (recordSet == null)
      {
        throw new ArgumentNullException(nameof(recordSet));
      }

      if (recordSet.EOF)
      {
        return null;
      }

      Node<TKey, TValue> root = Read(recordSet);
      recordSet.MoveNext();
      Walk(root, recordSet);
      return root;
    }

    protected abstract bool IsChild(TKey parent, TKey maybeChild);

    private bool IsChild(Node<TKey, TValue> parent, Node<TKey, TValue> maybeChild)
      => IsChild(parent.Key, maybeChild.Key);

    private void Walk(Node<TKey, TValue> parent, IRecordSet<TSource, TKey, TValue> recordSet)
    {
      if (recordSet.EOF)
      {
        return;
      }

      Node<TKey, TValue> maybeChild;
      while (IsChild(parent, maybeChild = Read(recordSet)))
      {
        parent.AddChild(maybeChild);
        recordSet.MoveNext();
        Walk(maybeChild, recordSet);
      }
    }

    private static Node<TKey, TValue> Read(IRecordSet<TSource, TKey, TValue> recordSet)
      => new Node<TKey, TValue>(recordSet.ReadKey(), recordSet.ReadValue());
  }
}