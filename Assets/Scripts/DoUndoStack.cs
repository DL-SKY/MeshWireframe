using System.Collections.Generic;

public class DoUndoStack
{
    #region Variables
    private Stack<int> commandsDeltaStack = new Stack<int>();
    #endregion

    #region Public methods
    public void AddCommand(int _deltaChanges)
    {
        commandsDeltaStack.Push(_deltaChanges);

        CustomEventHelper.OnChangesStackCommands?.Invoke(new Stack<int>(commandsDeltaStack));
    }

    public List<int> GetUndoDeltas(int _count = 1)
    {
        var result = new List<int>();

        for (int i = 0; i < _count; i++)
            if (commandsDeltaStack.Count > 0)
                result.Add(commandsDeltaStack.Pop());

        CustomEventHelper.OnChangesStackCommands?.Invoke(new Stack<int>(commandsDeltaStack));

        return result;
    }

    public List<int> GetDoDeltas()
    {
        var result = new List<int>();

        var count = commandsDeltaStack.Count;
        for (int i = 0; i < count; i++)
            result.Insert(0, commandsDeltaStack.Pop());

        CustomEventHelper.OnChangesStackCommands?.Invoke(new Stack<int>(commandsDeltaStack));

        return result;
    }
    #endregion
}
