using UnityEngine;
using UnityEngine.Events;



public class Collisions : MonoBehaviour
{
    
    int newPoint;
    public static UnityEvent CollisionSound = new UnityEvent();
    public static UnityEvent AddScoreEvent = new UnityEvent();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cube") {

            GameObject enemy= collision.gameObject;
            int thisCubePoint = gameObject.GetComponent<CubePoint>().Points;
            int enemyPoint = enemy.GetComponent<CubePoint>().Points;

            if (thisCubePoint == enemyPoint)
            {
                newPoint = thisCubePoint * 2;

                if (transform.localPosition.x > enemy.transform.localPosition.x)
                {
                    Destroy(enemy);
                    SetPoint();
                    SetScore();
                    SetMaterial();
                    SetCubeImpulsUp();
                    SetBam();
                }
                
            }

        }

    }


    public void SetPoint()
    {
        GetComponent<CubePoint>().Points = newPoint;
    }

    public void SetScore()
    { 
         Score.intScore += newPoint;
         AddScoreEvent?.Invoke();
    }

    public void SetMaterial()
    {
        GetComponent<CubeMaterial>().SetMaterials();
    }

    public void SetBam()
    {
        CollisionSound?.Invoke();
    }

    public void SetCubeImpulsUp()
    {
       GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
    }
}




