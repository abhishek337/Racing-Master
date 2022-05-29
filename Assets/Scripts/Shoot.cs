using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject carBullet;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public GameObject flash;
    private AudioSource gunFireSound;

    private void Awake()
    {
        gunFireSound = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shoot());
        flash.SetActive(false);
    }

    void fire()
    {
        Instantiate(carBullet, spawnPoint1.position, Quaternion.identity);
        Instantiate(carBullet, spawnPoint2.position, Quaternion.identity);
    }

    IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            fire();
            gunFireSound.Play();
            flash.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            flash.SetActive(false);
        }
    }

}
