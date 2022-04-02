using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStars : MonoBehaviour
{
    public GameObject star;
    public GameObject star2;
    public GameObject star3;
    void Start()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn ()
    {
        while (true)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3 (Random.Range(0f, Screen.width), Random.Range(0f, Screen.height), Camera.main.farClipPlane / 2));
            Vector3 pos2 = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height), Camera.main.farClipPlane / 2));
            Vector3 pos3 = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height), Camera.main.farClipPlane / 2));
            Instantiate(star, pos, Quaternion.Euler(0,0,Random.Range(0f, 360f)));
            Instantiate(star2, pos2, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
            Instantiate(star3, pos3, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
            yield return new WaitForSeconds(5.01f);
        }
       
    }

    void Update()
    {
        
    }
}
