using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeMaterial : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer rend;
    [SerializeField]
    private TextMeshPro[] texts;
    [SerializeField]
    private List<MaterialSetPoint> materialSetPoint = new List<MaterialSetPoint>();

    int points;
   

    internal void SetMaterials()
    {
        points = GetComponent<CubePoint>().Points;

        MaterialSetPoint found = materialSetPoint.Find(item => item.points == points);

        foreach (var text in texts)
        {
            text.text = points.ToString();

            if (found == null)
                rend.material = default;
            else
                rend.material = found.material;
        }
    }
}

[System.Serializable]
public class MaterialSetPoint
{
    public int points;
    public Material material;
}
