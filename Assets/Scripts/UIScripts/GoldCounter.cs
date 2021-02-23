﻿using UnityEngine;
using UnityEngine.UI;


public class GoldCounter : MonoBehaviour
{
    private Text scoreText;
    private int countGold = 0;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = countGold.ToString();
    }

    public void increaseTheScore(int value)
    {
        countGold+= value;
    }

    public void decreaseTheScore(int value)
    {
        countGold -= value; ;
    }
}
