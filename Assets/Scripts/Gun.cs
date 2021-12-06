using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bullet;

    public float bulletSpeed;

    public GameManager gameManager;

    public AudioClip gunmusic;


    public void Shoot(Transform firePos)
    {
        GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);

        b.GetComponent<Rigidbody2D>().AddForce(firePos.position * bulletSpeed, ForceMode2D.Impulse);

        Destroy(b, 3);

        gameManager.PlaySoundFX(gunmusic,1f);
    }
   
}
