using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    public GameObject enemyBullet;
    public Transform []spawnPoint;
    public GameObject enemyFlash;
    public GameObject explosionBlast;
    public EnemyHealthBar healthBar;
    public GameObject damageEffect;
    public GameObject Coin;
    private AudioSource gunFireSound;
    public AudioClip explosionSound;
    public float enemySpeed = -1f;
    public float Health = 2;

    float damage = 0f;
    float barSize = 1f;

    private void Awake()
    {
        gunFireSound = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bulletShoot());
        enemyFlash.SetActive(false);
        damage = barSize / Health;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * enemySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "playerCar")
        {
            Destroy(gameObject);
            GameObject carExplosion = Instantiate(explosionBlast, transform.position, Quaternion.identity);
            Destroy(carExplosion, 0.4f);
            //Time.timeScale = 0f;
        }

        if (collision.tag == "PlayerBullet")
        {
            damageHealthBar();
            Destroy(collision.gameObject);
            GameObject damegeeffect = Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(damegeeffect, 0.2f);

            if (Health <= 0)
            {
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                GameObject explosion = Instantiate(explosionBlast, transform.position, Quaternion.identity);
                Destroy(explosion, 0.4f);
                Instantiate(Coin, transform.position, Quaternion.identity);
            }
        }
    }

    void damageHealthBar()
    {
        if(Health > 0)
        {
            Health -= 1;
            barSize = barSize - damage;
            healthBar.setSize(barSize);
        }
    }

    void bulletFire()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Instantiate(enemyBullet, spawnPoint[i].position, Quaternion.identity);
        }
        //Instantiate(enemyBullet, spawnPoint1.position, Quaternion.identity);
        //Instantiate(enemyBullet, spawnPoint2.position, Quaternion.identity);
    }

    IEnumerator bulletShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.6f);
            bulletFire();
            enemyFlash.SetActive(true);
            yield return new WaitForSeconds(0.6f);
            enemyFlash.SetActive(false);
        }
    }
}
