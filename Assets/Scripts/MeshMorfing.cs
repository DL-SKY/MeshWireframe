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
    #endregion

    #region Public methods
    public int GetMaxTriangles()
    {
        return originTriangles?.Length / 3 ?? 0;
    }

    public int GetCurrentTriangles()
    {
        return triangles;
    }

    public void OnChangeTriangles(int _delta, bool _updateMesh = true)
    {
        triangles = Mathf.Clamp(triangles + _delta, 1, originTriangles.Length / 3);

        if (_updateMesh)
            UpdateMesh();
    }

    public void OnUpdateMesh()
    {
        UpdateMesh();
    }
    #endregion

    #region Private methods
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
}
