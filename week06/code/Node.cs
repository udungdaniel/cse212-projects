public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        // Duplicate values are ignored so that the BST behaves
        // like a sorted set and only stores unique values.

        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            // Smaller values belong in the left subtree.
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            // Larger values belong in the right subtree.
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // Search the tree the same way values are inserted.
        // Each recursive call eliminates half of the remaining tree.

        if (value == Data)
        return true;

        if (value < Data)
        return Left != null && Left.Contains(value);

        return Right != null && Right.Contains(value);
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // The height of this node is one plus the larger
        // height of its left and right subtrees.

        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        return 1 + Math.Max(leftHeight, rightHeight); // Replace this line with the correct return statement(s)
    }
}