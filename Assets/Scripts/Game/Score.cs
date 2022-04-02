using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text record;
    private Text txt;
    private bool gameStart;

    // Start is called before the first frame update
    void Start()
    {
        record.text = "TOP: " + PlayerPrefs.GetInt ("Record").ToString ();
        txt = GetComponent <Text> ();
        CubeJump.count_blocks = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (txt.text == "0")
            gameStart = true;
        if (gameStart)
        {
            txt.text = CubeJump.count_blocks.ToString ();
            if (PlayerPrefs.GetInt ("Record") < CubeJump.count_blocks)
            {
                PlayerPrefs.SetInt ("Record", CubeJump.count_blocks);
                record.text = "TOP: " +  PlayerPrefs.GetInt ("Record").ToString ();
            }
        }
    }
}
