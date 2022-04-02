using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameArrengment : MonoBehaviour
{
    public GameObject[] cubesM;
    public Text playTxt, gameName, record;
    public GameObject buttons, cube, cubes, block, spawnBlocks;
    private bool clicked;
    public new Light light;

    private void Update()
    {
        if(clicked && light.intensity != 0)
        {
            light.intensity -= 0.03f;
        }
    }
    private void OnMouseDown()
    {
        if (!clicked)
        {
            StartCoroutine(DelCubes());
            StartCoroutine(CubeToBlock());
            clicked = true;
            playTxt.gameObject.SetActive(false);
            record.gameObject.SetActive(true);
            gameName.text = "0";
            buttons.GetComponent<ScrollObjects>().speed = -5f;
            buttons.GetComponent<ScrollObjects>().checkPos = -300f;
            cube.GetComponent<Animation>().Play("PlayAnim");
            cubes.GetComponent<Animation>().Play("CubesPosition");
        
        }
    }
    IEnumerator DelCubes()
    {
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.38f);
            cubesM[i].GetComponent<FallCube>().enabled = true;
        }
      spawnBlocks.GetComponent<SpawnBlocks>().enabled = true;
    }
    IEnumerator CubeToBlock ()
    {
        yield return new WaitForSeconds(cubes.GetComponent<Animation>().clip.length);
        block.GetComponent<Animation>().Play("CubeToBlock");

        cube.AddComponent<Rigidbody>();
    }
}
