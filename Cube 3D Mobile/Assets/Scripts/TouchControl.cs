using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

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
        if (countfForAds == limitForADS)
        {
            AdsCore.ShowAdsVideo("Interstitial_Android");
            countfForAds = 0;
        }
        cloneCube = null;
        yield return new WaitForSeconds(1f);
        cloneCube = SpawnCube();
        cloneRigidbody = cloneCube.GetComponent<Rigidbody>();             
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





    public void OnEndDrag(PointerEventData eventData)
    {
        
        Debug.Log("OnEndDrag");
        cloneRigidbody.AddForce(cloneRigidbody.transform.forward * 30f, ForceMode.Impulse);
        StartCoroutine(Spawn());
    }

    public void OnBeginDrag(PointerEventData eventData)

    {
        Debug.Log("OnBeginDrag");
    }

  



}
