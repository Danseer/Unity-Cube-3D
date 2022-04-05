using UnityEngine;

public class CubePoint : MonoBehaviour
{
    [SerializeField]
    private int range;
    private int points;

     void Awake()
    {
        SetPoints();
    }

    void SetPoints()
    {
        points = (int)Mathf.Pow(2, Random.Range(1, range));
        SetMaterial();
    }

    void SetMaterial()
    {
        GetComponent<CubeMaterial>().SetMaterials();
    }

    public int Points { get => points; set => points = value; }
}
