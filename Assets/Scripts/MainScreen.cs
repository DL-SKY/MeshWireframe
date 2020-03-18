using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649

public class MainScreen : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Text trianglesLabel;
    #endregion

    #region Unity methods
    private void OnEnable()
    {
        CustomEventHelper.OnUpdateUITriangles += OnUpdateUITrianglesHandler;
    }

    private void OnDisable()
    {
        CustomEventHelper.OnUpdateUITriangles -= OnUpdateUITrianglesHandler;
    }
    #endregion

    #region Public methods
    #endregion

    #region Private methods
    private void OnUpdateUITrianglesHandler(int _value)
    {
        trianglesLabel.text = string.Format("Triangles: {0}", _value);
    }
    #endregion

    #region Coroutines
    #endregion
}
