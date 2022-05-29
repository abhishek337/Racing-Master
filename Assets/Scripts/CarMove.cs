using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float speed;
    float moveSpeed = 3;
    public Rigidbody2D RB;
    public float plyerhealth = 10f;
    public playerHealthbar HealthBar;
    public GameObject explosionBlast;
    public GameObject damageEffect;
    public CoinCount coinCountobj;
    public GameController gamecontrol;
    private AudioSource gunFireSound;
    public AudioClip collideSound;
    public AudioClip destroySound;

    float barFillAmount = 1f;
    float damage = 0;
    float minX = -1.6f;
    float maxX = 1.6f;

    private void Awake()
    {
        gunFireSound = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {
        damage = barFillAmount / plyerhealth;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float posX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float newX = Mathf.Clamp( transform.position.x + posX, minX, maxX);

        transform.position = new Vector2(newX, transform.position.y);

        if (Input.GetMouseButtonUp(0))
        {
            RB.velocity = new Vector2(0, 0);
            Debug.Log("Button Released");
        }

        /* player movement 
        if (posX > 0)
        {
            Rb.velocity = new Vector2(speed, 0);
        }
        else if(posX < 0)
        {
            Rb.velocity = new Vector2(-speed, 0);
        }
        else if(posX == 0)
        {
            Rb.velocity = new Vector2(0, 0);
        }
        */
    }

    private void FixedUpdate()
    {
        touchInput();
    }

    void touchInput()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousepos.x > 2 && mousepos.y < -5)
            {
                //Debug.Log("right button");
                RB.velocity = new Vector2(moveSpeed, 0);
            }

            if (mousepos.x < -2 && mousepos.y < -5)
            {
                //Debug.Log("left button");
                RB.velocity = new Vector2(-moveSpeed, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            gunFireSound.PlayOneShot(collideSound, 0.5f);
            damgePlayerHealth();
            Destroy(collision.gameObject);
            GameObject damageeffect = Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(damageeffect, 0.2f);

            if (plyerhealth <= 0)
            {
                AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position, 0.5f);
                Destroy(gameObject);
                Time.timeScale = 0f;
                gamecontrol.gameOver();
            }
        }

        if(collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coinCountobj.increaseCoinCount();
        }

        if(collision.tag == "EnemyCar")
        {
            damgePlayerHealth();
        }
    }

    void damgePlayerHealth()
    {
        if(plyerhealth > 0)
        {
            plyerhealth -= 1;
            barFillAmount = barFillAmount - damage;
            HealthBar.setAmount(barFillAmount);
        }
    }
}
