using UnityEngine;

#pragma warning disable 0649

public class MainSceneController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private MeshMorfing morfer;    
    #endregion

    #region Unity methods
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            OnChangeTriangles(1);
        else if (Input.GetKeyDown(KeyCode.X))
            OnChangeTriangles(-1);
    }
    #endregion

    #region Public methods
    #endregion

    #region Private methods
    private void OnChangeTriangles(int _delta)
    {
        CustomEventHelper.OnChangeTriangles?.Invoke(_delta);
    }    
    #endregion

    #region Coroutines
    #endregion
}
