using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject block, allCubes;
    private GameObject instBlock;
    private float speed = 12f;
    private Vector3 blockPos;
    private bool onPlace;
    void Start()
    {
        spawn();
    }
    private void Update()
    {
        if (instBlock.transform.position != blockPos && !onPlace)
        {
            instBlock.transform.position = Vector3.MoveTowards(instBlock.transform.position, blockPos, Time.deltaTime * speed);
        }
        else if (instBlock.transform.position == blockPos)
        {
            onPlace = true;
        }
        if (CubeJump.jump && CubeJump.nextBlock)
        {
            spawn();

            onPlace = false;
        }
    }
    float RandScale()
    {
        float rand;
        if (Random.Range(0, 100) >= 80)
        {
            rand = Random.Range(1f, 1.5f);
        }
        else
        {
            rand = Random.Range(0.9f, 1.2f);
        }
        return rand;
    }
    void spawn(){
        blockPos = new Vector3(Random.Range(1f, 1.27f), Random.Range(0f, -3.4f), -0.85f);
        instBlock = Instantiate(block, new Vector3(5f, -6f, -0.85f), Quaternion.identity) as GameObject;
        instBlock.transform.localScale = new Vector3(RandScale(), instBlock.transform.localScale.y, instBlock.transform.localScale.z);
        instBlock.transform.parent = allCubes.transform;
    }
}
