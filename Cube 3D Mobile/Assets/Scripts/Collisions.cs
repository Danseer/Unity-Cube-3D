using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collisions : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro[] texts;

    [SerializeField]
    private List<MaterialSetPoint> materialSetPoint = new List<MaterialSetPoint>();

    [SerializeField]
    private MeshRenderer rend;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cube") {

            int thisCubePoint = gameObject.GetComponent<Point>().Points;
            int enemyPoint = collision.gameObject.GetComponent<Point>().Points;

            if (thisCubePoint == enemyPoint)
            {
                GameObject e = collision.gameObject;
                GameObject m = gameObject;

                int newPoint = thisCubePoint * 2;

               

                MaterialSetPoint found = materialSetPoint.Find(item => item.points == newPoint);
               
                if (m.transform.localPosition.x > e.transform.localPosition.x)
                {
                    Destroy(e);

                    Score.intScore += newPoint;
                    Debug.Log("Count=" + Score.intScore.ToString());

                    GameObject.Find("Score").GetComponent<Text>().text = Score.intScore.ToString();

                    m.GetComponent<Point>().Points = newPoint;

                    foreach (var text in texts)
                    {
                        text.text = newPoint.ToString();

                        if (found == null)
                            rend.material = default;
                        else
                            rend.material = found.material;
                    }

                    m.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
                    audioSource.Play();
                }
                
            }

        }

    }
}




