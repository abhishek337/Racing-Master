using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform Bar;

    // Start is called before the first frame update
    void Start()
    {
        //setSize(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSize(float size)
    {
        Bar.localScale = new Vector2(size, 0.6f);
    }
}
