using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public float speed;
    [SerializeField]
    private int health;
    public Sprite[] sprites;

    [SerializeField]
    private float maxShotDelay;
    [SerializeField]
    private float curShotDelay;

    public GameObject bulletObjA;
    public GameObject bulletObjB;
    public GameObject player;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        Fire();
        Reload();
    }

    void Fire()
    {
        if (curShotDelay < maxShotDelay)
            return;

        if(enemyName == "S")
        {
            GameObject bulletAL = Instantiate(bulletObjA, transform.position + Vector3.right * 0.3f, transform.rotation);
            GameObject bulletAR = Instantiate(bulletObjA, transform.position + Vector3.left * 0.3f, transform.rotation);

            Rigidbody2D rigidAL = bulletAL.GetComponent<Rigidbody2D>();
            Rigidbody2D rigidAR = bulletAR.GetComponent<Rigidbody2D>();

            Vector3 dirVecL = player.transform.position - (transform.position + Vector3.right * 0.3f);
            Vector3 dirVecR = player.transform.position - (transform.position + Vector3.left * 0.3f);

            rigidAL.AddForce(dirVecL.normalized * 3, ForceMode2D.Impulse);
            rigidAR.AddForce(dirVecR.normalized * 3, ForceMode2D.Impulse);
        }
        else if(enemyName == "L")
        {
            GameObject bulletB = Instantiate(bulletObjB, transform.position, transform.rotation);
            Rigidbody2D rigidB = bulletB.GetComponent<Rigidbody2D>();
            Vector3 dirVec = player.transform.position - transform.position;
            rigidB.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
        }

        curShotDelay = 0;
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    void Onhit(int dmg)
    {
        health -= dmg;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            Onhit(bullet.dmg);
            Destroy(collision.gameObject);
        }
    }
}
