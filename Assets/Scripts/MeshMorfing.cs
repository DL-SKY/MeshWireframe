using UnityEngine;

#pragma warning disable 0649

public class MeshMorfing : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private MeshFilter meshFilter;
    private int[] originTriangles;

    private int triangles = 1;
    #endregion

    #region Unity methods
    private void Start()
    {
        originTriangles = new int[meshFilter.mesh.triangles.Length];
        meshFilter.mesh.triangles.CopyTo(originTriangles, 0);

        UpdateMesh();
    }

    private void OnEnable()
    {
        CustomEventHelper.OnChangeTriangles += OnChangeTrianglesHandler;
    }

    private void OnDisable()
    {
        CustomEventHelper.OnChangeTriangles -= OnChangeTrianglesHandler;
    }
    #endregion

    #region Public methods
    #endregion

    #region Private methods
    private void OnChangeTrianglesHandler(int _delta)
    {
        triangles = Mathf.Clamp(triangles + _delta, 1, originTriangles.Length / 3);
        UpdateMesh();
    }

    private void UpdateMesh()
    {
        try
        {
            var indices = new int[triangles * 6];
            for (int i = 0; i < triangles * 3; i++)
            {
                indices[i * 2] = originTriangles[i];
                indices[i * 2 + 1] = originTriangles[i + (i % 3 == 2 ? -2 : 1)];
            }

            meshFilter.mesh.SetIndices(indices, MeshTopology.Lines, 0);

            CustomEventHelper.OnUpdateUITriangles?.Invoke(triangles);
        }
        catch { }
    }
    #endregion

    #region Coroutines
    #endregion
}
