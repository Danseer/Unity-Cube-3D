using System.Collections;
using System.Collections.Generic;
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

        crigidbody.AddForce(crigidbody.transform.forward * 30f, ForceMode.Impulse);
        StartCoroutine(StartScene());
    }

    IEnumerator StartScene()
    {
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main");
    }

}


