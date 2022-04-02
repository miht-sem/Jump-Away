using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJump : MonoBehaviour
{
    public GameObject mCube, buttons, lose_buttons;
    private static bool animate;// jumped;
    private float speed = 1f, startTime;
    private int yPosCube;
    public static bool jump, nextBlock, lose;
    public static int count_blocks;

    private void Start()
    {
        nextBlock = false;
        jump = false;
        lose = false;
        animate = false;
        StartCoroutine(CanJump());
    }
    private void FixedUpdate()
    {
        if (mCube != null)
        {
            if (animate && mCube.transform.localScale.y > 0.5f)
            {
                PressCube(-speed);
            }
            else if (!animate)
            {
                if (mCube.transform.localScale.y < 1.2f)
                {
                    PressCube(speed * 3f);
                }
                else if (mCube.transform.localScale.y != 1.2f)
                {
                    mCube.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                }
            }
            if (mCube.transform.position.y < -14f)
            {
                Destroy(mCube, 0.5f);
                lose = true;
                print("Lose");
            }
            
            if (lose)
                PlayerLose ();
        }
    }

    void PlayerLose ()
    {
        buttons.GetComponent <ScrollObjects> ().speed = 15f;
        buttons.GetComponent <ScrollObjects> ().checkPos = -45;
        if (!lose_buttons.activeSelf)
            lose_buttons.SetActive (true);
        lose_buttons.GetComponent <ScrollObjects> ().speed = 20f;
        lose_buttons.GetComponent <ScrollObjects> ().checkPos = 60;
    }

    private void OnMouseDown()
    {
        if (mCube != null)
        {
            if (nextBlock && mCube.GetComponent<Rigidbody>() != null)
            {
                animate = true;
                startTime = Time.time;

                yPosCube = (int)mCube.transform.localPosition.y;

            }
        }
    }
    private void OnMouseUp()
    {
        if (mCube != null)
        {
            if (nextBlock && mCube.GetComponent<Rigidbody>() != null)
            {
                animate = false;
                jump = true;
                float force, diff;
                diff = Time.time - startTime;
                if (diff < 3f)
                 {
                    force = 190 * diff;
                 }
                 else
                 {
                     force = 280f;
                 }
                if (force < 60f)
                {
                    force = 60f;
                }
                mCube.GetComponent<Rigidbody>().AddRelativeForce(mCube.transform.up * force);
                mCube.GetComponent<Rigidbody>().AddRelativeForce(mCube.transform.right * -force);
                StartCoroutine(CheckCubPos());
                nextBlock = false;
            }
        }
    }
    private void PressCube(float force)
    {
        mCube.transform.localPosition += new Vector3(0f, force * Time.deltaTime, 0f);
        mCube.transform.localScale += new Vector3(0f, force * Time.deltaTime, 0f);
    }
    IEnumerator CheckCubPos()
    {
        yield return new WaitForSeconds(1.5f);
        
        if (mCube != null)
        {
            if (yPosCube == (int)mCube.transform.localPosition.y)
            {
                print("Lose");
                lose = true;
                nextBlock = false;
            }
            else
            {
                while (!mCube.GetComponent<Rigidbody>().IsSleeping())
                {
                    yield return new WaitForSeconds(0.05f);
                    if (mCube == null) break;
                }
                if (!lose)
                {
                    nextBlock = true;
                    count_blocks++;
                    print("Next");
                    mCube.transform.localPosition = new Vector3(-1.28f, mCube.transform.localPosition.y, mCube.transform.localPosition.z);
                    mCube.transform.eulerAngles = new Vector3(0f, mCube.transform.eulerAngles.y * 0f + 90f, 0f);
                    
                    
                }
            }
        }
    }
    IEnumerator CanJump()
    {
        while(!mCube.GetComponent<Rigidbody>())
            yield return new WaitForSeconds(0.05f);
        nextBlock = true;
    }
    IEnumerator suck()
    {
        yield return new WaitForSeconds(1f);

    }
}
