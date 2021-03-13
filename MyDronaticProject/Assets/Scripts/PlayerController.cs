using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int score;
    public Text scoreText;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:\n" + score;
    }

    public void increaseScore(int value) // TODO can be changed to pickup
    {
        score += value;
    }

    

}
