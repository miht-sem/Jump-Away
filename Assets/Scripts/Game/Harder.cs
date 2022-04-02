using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harder : MonoBehaviour
{
    private bool hard;

    void Update()
    {

        if (CubeJump.count_blocks > 0) 
        {  
            if (CubeJump.count_blocks % 3 == 0 && !hard)
            {
                print("Harder");
                Camera.main.GetComponent <Animation> ().Play ("Harder");
                hard = true;
            }
            else if ((CubeJump.count_blocks % 3) - 1 == 0 && hard)
            {
                print("Easier");
                hard = false;
                Camera.main.GetComponent <Animation> ().Play ("Easier");
            }
        }
    }
}
