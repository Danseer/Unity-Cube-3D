using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchControl : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public GameObject mainCube;
    private GameObject cloneCube;
    private Rigidbody cloneRigidbody;
    public int limitForADS;
    int countfForAds = 0;



    void Start()
    {
        StartCoroutine(Spawn());
    }

  

    IEnumerator Spawn()
    {
        countfForAds++;
        cloneCube = null;
        yield return new WaitForSeconds(1.5f);
        cloneCube = SpawnCube();
        cloneRigidbody = cloneCube.GetComponent<Rigidbody>();

        if (countfForAds == limitForADS)
        {
            AdsCore.ShowAdsVideo("Interstitial_Android");
            countfForAds = 0;
        }
    }

    private GameObject SpawnCube()
    {
        Debug.Log(" SpawnCube");
        return Instantiate(mainCube, new Vector3(0, 1, -11), Quaternion.identity);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        Vector3 position = cloneCube.transform.position;
        position.x += eventData.delta.x * Time.deltaTime;

        if (Mathf.Abs(eventData.delta.x)>Mathf.Abs(eventData.delta.y)) {
            if (eventData.delta.x > 0)
            {
                if (position.x > 3f) position.x = 3f;
            }

            else
            {
                if (position.x < -3.3f) position.x = -3.3f;
            }
                

            cloneCube.transform.position = position;

        }

    }

    void Update()
    {
#if UNITY_ANDROID
if (Input.touchCount > 0 && cloneCube)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                cloneRigidbody.AddForce(cloneRigidbody.transform.forward * 30f, ForceMode.Impulse);
                StartCoroutine(Spawn());
            }
        }
#endif

    }


    public void OnEndDrag(PointerEventData eventData)
    {
        
        Debug.Log("OnEndDrag");

#if UNITY_EDITOR
        cloneRigidbody.AddForce(cloneRigidbody.transform.forward * 30f, ForceMode.Impulse);
        StartCoroutine(Spawn());
#endif

    }

    public void OnBeginDrag(PointerEventData eventData)

    {
        Debug.Log("OnBeginDrag");
    }

  



}
