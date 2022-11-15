using System;
using System.Collections.Generic;

namespace Trees.Builders
{
  public class PrefixTreeBuilder<TSource, TValue> :
    ITreeBuilder<TSource, string, TValue>,
    IForestBuilder<TSource, string, TValue>
  {
    public IEnumerable<INode<string, TValue>> BuildForest(IRecordSet<TSource, string, TValue> recordSet)
    {
      INode<string, TValue> root;
      while ((root = Build(recordSet)) != null)
      {
        yield return root;
      }
    }

    public INode<string, TValue> Build(IRecordSet<TSource, string, TValue> recordSet)
    {
      if (recordSet == null)
      {
        throw new ArgumentNullException(nameof(recordSet));
      }

      if (recordSet.EOF)
      {
        return null;
      }

      Node<string, TValue> root = Read(recordSet);
      recordSet.MoveNext();
      Walk(root, recordSet);
      return root;
    }

    protected virtual bool IsChild(string parent, string maybeChild)
      => maybeChild?.StartsWith(parent) ?? false;

    private bool IsChild(Node<string, TValue> parent, Node<string, TValue> maybeChild)
      => IsChild(parent?.Key, maybeChild?.Key);

    private void Walk(Node<string, TValue> parent, IRecordSet<TSource, string, TValue> recordSet)
    {
      if (recordSet.EOF)
      {
        return;
      }

      Node<string, TValue> maybeChild;
      while (IsChild(parent, maybeChild = Read(recordSet)))
      {
        parent.AddChild(maybeChild);
        recordSet.MoveNext();
        Walk(maybeChild, recordSet);
      }
    }

    private static Node<string, TValue> Read(IRecordSet<TSource, string, TValue> recordSet)
      => new Node<string, TValue>(recordSet.ReadKey(), recordSet.ReadValue());
  }
}