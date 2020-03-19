using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class MainSceneController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private MeshMorfing morfer;

    private DoUndoStack commands = new DoUndoStack();
    #endregion

    #region Unity methods
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            ExecuteCommands(commands.GetDoDeltas());
        else if (Input.GetKeyDown(KeyCode.X))
            commands.GetUndoDeltas(1);
        else if (Input.GetKeyDown(KeyCode.C))
            commands.AddCommand(1);
        else if (Input.GetKeyDown(KeyCode.V))
            commands.AddCommand(-1);
    }
    #endregion

    #region Private methods
    private void ExecuteCommands(List<int> _commands)
    {
        foreach (var command in _commands)
            morfer.OnChangeTriangles(command);
    }
    #endregion
}
