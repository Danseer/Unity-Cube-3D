using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Point : MonoBehaviour
{
    [SerializeField]
    private int range;
    [SerializeField]
    private MeshRenderer rend;
    [SerializeField]
    private TextMeshPro[] texts;
    [SerializeField]
    private List<MaterialSetPoint> materialSetPoint = new List<MaterialSetPoint>();
    private int points;

     void Awake()
    {
        SetPointsAndWrite();
    }

     private void SetPointsAndWrite()
    {
        points = (int)Mathf.Pow(2, Random.Range(1, range));
        

        foreach (var text in texts)
        {
            text.text = points.ToString();

            MaterialSetPoint found = materialSetPoint.Find(item => item.points == points);

            if (found == null)
                rend.material = default;
            else
                rend.material = found.material;
        }
    }

    public int Points { get => points; set => points = value; }


}



[System.Serializable]
public class MaterialSetPoint
{
    public int points;
    public Material material;
}
