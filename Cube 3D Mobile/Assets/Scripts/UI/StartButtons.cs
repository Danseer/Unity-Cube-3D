using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtons : MonoBehaviour
{
    [SerializeField]
    private Button start;
    [SerializeField]
    private Text text;
    [SerializeField]
    private GameObject cube;
    private Rigidbody crigidbody;

    void Start()
    {
        start.onClick.AddListener(StartButton);
        crigidbody = cube.GetComponent<Rigidbody>();
    }

    public void StartButton()
    {
        StartCoroutine(StartScene());
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                StartCoroutine(StartScene());
            }
        }
    }

    IEnumerator StartScene()
    {
        crigidbody.AddForce(crigidbody.transform.forward * 30f, ForceMode.Impulse);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main");
    }
}


