using System;
using System.Collections.Generic;

public static class CustomEventHelper
{
    public static Action<int> OnUpdateUITriangles;
    public static Action<Stack<int>> OnChangesStackCommands;
}
