using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerHealthbar : MonoBehaviour
{
    public Image bar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAmount(float amount)
    {
        bar.fillAmount = amount;
    }
}
