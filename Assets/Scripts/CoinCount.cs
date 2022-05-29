using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    public TextMeshProUGUI coinCount;
    public int coin = 0;

    // Update is called once per frame
    void Update()
    {
        coinCount.text = coin.ToString();
    }

    public void increaseCoinCount()
    {
        coin++;
    }
}
