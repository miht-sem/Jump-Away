using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeBackground : MonoBehaviour
{
    public int i;
    public Gradient obj;
    private void Start()
    {
        obj = GetComponent<Gradient>() as Gradient;
    }
    private void Update()
    {
        
    }
}
