using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3 = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = transform.position;
        pos.x = mousePos3.x;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject colldedWith = coll.gameObject;
        if (colldedWith.tag == "Apple")
        {
            Destroy(colldedWith);
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
