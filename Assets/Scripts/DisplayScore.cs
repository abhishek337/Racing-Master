using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    public TextMeshProUGUI coinCount;
    public TextMeshProUGUI highScore;
    public CoinCount Coin;
    int highscore = 0;

    void Awake()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highScore.text = highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coinCount.text = Coin.coin.ToString();
        int score = Coin.coin;
    
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
