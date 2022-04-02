using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubes : MonoBehaviour
{
    private bool moved = true;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(-2.88f, 4.88f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(CubeJump.nextBlock){
            if(transform.position != target && !CubeJump.lose){
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime *8f);
            }
            else if(transform.position == target && !moved)
            {
                target = new Vector3(transform.position.x - 2.5f, transform.position.y + 4f, transform.position.z);
                CubeJump.jump = false;
                moved = true;
            }
        
        if(CubeJump.jump)
            moved = false;  
        }
    }
}
