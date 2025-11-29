using System;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class UIM : MonoBehaviour
{
    //Singleton
    public static UIM instance;
    public TMP_Text scoreText;
    public TMP_Text hpText;
    private int score = 0;
    public int hp = 100;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText.text = "Score : " + score;
        hpText.text = "Health: " + hp;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score : " + score;
    }
    public void hpdwn(int damage)
    {
        hp -= damage;
        hpText.text = "Health: " + hp;
    }
}