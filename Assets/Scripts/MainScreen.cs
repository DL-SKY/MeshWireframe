using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649

public class MainScreen : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Text trianglesLabel;
    [SerializeField]
    private Text commands;
    #endregion

    #region Unity methods
    private void Start()
    {
        commands.text = "";
    }

    private void OnEnable()
    {
        CustomEventHelper.OnUpdateUITriangles += OnUpdateUITrianglesHandler;
        CustomEventHelper.OnChangesStackCommands += OnChangesStackCommandsHandler;
    }

    private void OnDisable()
    {
        CustomEventHelper.OnUpdateUITriangles -= OnUpdateUITrianglesHandler;
        CustomEventHelper.OnChangesStackCommands -= OnChangesStackCommandsHandler;
    }
    #endregion

    #region Private methods
    private void OnUpdateUITrianglesHandler(int _value)
    {
        trianglesLabel.text = string.Format("Triangles: {0}", _value);
    }

    private void OnChangesStackCommandsHandler(Stack<int> _stack)
    {
        commands.text = "";

        var count = _stack.Count;
        for (int i = 0; i < count; i++)
            commands.text += string.Format("{0}\n", _stack.Pop());
    }
    #endregion
}
