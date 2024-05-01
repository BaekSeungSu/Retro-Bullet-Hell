using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private int life;

    public int score;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float maxShotDelay;

    [SerializeField]
    private float curShotDelay;

    [SerializeField]
    private int power;

    [SerializeField]
    private int boom;

    [SerializeField]
    private int maxPower;

    [SerializeField]
    private int maxBoom;

    private bool isTouchTop;
    private bool isTouchBottom;
    private bool isTouchRight;
    private bool isTouchLeft;

    public GameObject bulletObjA;
    public GameObject bulletObjB;
    public GameObject bulletObjC;
    public GameObject bulletObjD;
    public GameObject bulletObjE;
    public GameObject boomEffect;

    public GameManager gameManager;
    public ObjectManager objectManager;
    public bool isHit;
    public bool isBoomTime;

    public bool isRespawnTime;

    Animator anim;
    SpriteRenderer spriteRenderer;

    private AudioSource audioSource;


    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        Unbeatable();
        Invoke("Unbeatable", 3);
    }


    //�����ð�
    void Unbeatable()
    {
        isRespawnTime = !isRespawnTime;
        if (isRespawnTime)
        { 
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }
    void Update()
    {
        Move();
        Fire();
        Boom();
        Reload();
    }

    void Move()
    {

        float h = Input.GetAxisRaw("Horizontal"); //���� �� ����
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h = 0;

        float v = Input.GetAxisRaw("Vertical"); //���� �� ����
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            v = 0;

        Vector3 curPos = transform.position; //���� ��ġ
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime; //���� �̵� ��ġ

        transform.position = curPos + nextPos; 

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
            anim.SetInteger("Input", (int)h);
        }
    }

    void Fire()
    {
        if (!Input.GetButton("Fire1"))
            return;
        if (curShotDelay < maxShotDelay)
            return;

        switch (power)
        {
            case 1:
                GameObject bulletA = objectManager.MakeObj("BulletPlayerA");
                bulletA.transform.position = transform.position;
                Rigidbody2D rigidA = bulletA.GetComponent<Rigidbody2D>();
                rigidA.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            case 2:
                GameObject bulletB = objectManager.MakeObj("BulletPlayerB");
                bulletB.transform.position = transform.position;
                Rigidbody2D rigidB = bulletB.GetComponent<Rigidbody2D>();
                rigidB.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            case 3:
                GameObject bulletC = objectManager.MakeObj("BulletPlayerC");
                bulletC.transform.position = transform.position;
                Rigidbody2D rigidC = bulletC.GetComponent<Rigidbody2D>();
                rigidC.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            case 4:
                GameObject bulletD = objectManager.MakeObj("BulletPlayerD");
                bulletD.transform.position = transform.position;
                Rigidbody2D rigidD = bulletD.GetComponent<Rigidbody2D>();
                rigidD.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            case 5:
                GameObject bulletE = objectManager.MakeObj("BulletPlayerE");
                bulletE.transform.position = transform.position;
                Rigidbody2D rigidE = bulletE.GetComponent<Rigidbody2D>();
                rigidE.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
        }
        audioSource.Play();

        curShotDelay = 0;
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    void Boom()
    {
        // �ʻ�� ��ư�� �������� üũ
        if (!Input.GetButton("Fire2"))
            return;
        // �ʻ�⸦ ������� �������� üũ
        if (isBoomTime)
            return;
        // �ʻ���� ������ 0�� �ƴ��� üũ
        if (boom == 0)
            return;


        boom--;
        isBoomTime = true;
        gameManager.UpdateBoomIcon(boom);

        //Effect visible
        boomEffect.SetActive(true);
        Invoke("OffBoomEffect", 4f);
        //Remove Enemy
        GameObject[] enemiesL = objectManager.GetPool("EnemyL");
        GameObject[] enemiesM = objectManager.GetPool("EnemyM");
        GameObject[] enemiesS = objectManager.GetPool("EnemyS");
        GameObject[] enemiesLL = objectManager.GetPool("EnemyLL");
        GameObject[] enemiesMM = objectManager.GetPool("EnemyMM");
        GameObject[] enemiesSS = objectManager.GetPool("EnemySS");
        for (int index = 0; index < enemiesL.Length; index++)
        {
            if (enemiesL[index].activeSelf)
            {
                Enemy enemyLogic = enemiesL[index].GetComponent<Enemy>();
                enemyLogic.Onhit(1000);
            }
        }
        for (int index = 0; index < enemiesM.Length; index++)
        {
            if (enemiesM[index].activeSelf)
            {
                Enemy enemyLogic = enemiesM[index].GetComponent<Enemy>();
                enemyLogic.Onhit(1000);
            }
        }
        for (int index = 0; index < enemiesS.Length; index++)
        {
            if (enemiesS[index].activeSelf)
            {
                Enemy enemyLogic = enemiesS[index].GetComponent<Enemy>();
                enemyLogic.Onhit(1000);
            }
        }
        for (int index = 0; index < enemiesLL.Length; index++)
        {
            if (enemiesLL[index].activeSelf)
            {
                Enemy enemyLogic = enemiesLL[index].GetComponent<Enemy>();
                enemyLogic.Onhit(1000);
            }
        }
        for (int index = 0; index < enemiesMM.Length; index++)
        {
            if (enemiesMM[index].activeSelf)
            {
                Enemy enemyLogic = enemiesMM[index].GetComponent<Enemy>();
                enemyLogic.Onhit(1000);
            }
        }
        for (int index = 0; index < enemiesSS.Length; index++)
        {
            if (enemiesSS[index].activeSelf)
            {
                Enemy enemyLogic = enemiesSS[index].GetComponent<Enemy>();
                enemyLogic.Onhit(1000);
            }
        }


        //Remove Enemy Bullet
        GameObject[] bulletsA = objectManager.GetPool("BulletEnemyA");
        GameObject[] bulletsB = objectManager.GetPool("BulletEnemyB");
        GameObject[] bulletsC = objectManager.GetPool("BulletEnemyC");
        GameObject[] bulletsD = objectManager.GetPool("BulletEnemyD");
        GameObject[] bulletsE = objectManager.GetPool("BulletEnemyE");
        GameObject[] bulletBossA = objectManager.GetPool("BulletBossA");
        GameObject[] bulletBossB = objectManager.GetPool("BulletBossB");
        GameObject[] bulletBossC = objectManager.GetPool("BulletBossC");
        GameObject[] bulletBossD = objectManager.GetPool("BulletBossD");
        GameObject[] bulletBossE = objectManager.GetPool("BulletBossE");
        GameObject[] bulletBossF = objectManager.GetPool("BulletBossF");
        for (int index = 0; index < bulletsA.Length; index++)
        {
            if (bulletsA[index].activeSelf)
            {
                bulletsA[index].SetActive(false);
            }
        }
        for (int index = 0; index < bulletsB.Length; index++)
        {
            if (bulletsB[index].activeSelf)
            {
                bulletsB[index].SetActive(false);
            }
        }
        for (int index = 0; index < bulletsC.Length; index++)
        {
            if (bulletsC[index].activeSelf)
            {
                bulletsC[index].SetActive(false);
            }
        }
        for (int index = 0; index < bulletsD.Length; index++)
        {
            if (bulletsD[index].activeSelf)
            {
                bulletsD[index].SetActive(false);
            }
        }
        for (int index = 0; index < bulletsE.Length; index++)
        {
            if (bulletsE[index].activeSelf)
            {
                bulletsE[index].SetActive(false);
            }
        }
        for (int index = 0; index < bulletBossA.Length; index++)
        {
            if (bulletBossA[index].activeSelf)
            {
                bulletBossA[index].SetActive(false);
            }
        }
        for (int index = 0; index < bulletBossB.Length; index++)
        {
            if (bulletBossB[index].activeSelf)
            {
                bulletBossB[index].SetActive(false);
            }
        }
        for (int index = 0; index < bulletBossC.Length; index++)
        {
            if (bulletBossC[index].activeSelf)
            {
                bulletBossC[index].SetActive(false);
            }
        }
        for (int index = 0; index < bulletBossD.Length; index++)
        {
            if (bulletBossD[index].activeSelf)
            {
                bulletBossD[index].SetActive(false);
            }
        }
        for (int index = 0; index < bulletBossE.Length; index++)
        {
            if (bulletBossE[index].activeSelf)
            {
                bulletBossE[index].SetActive(false);
            }
        }
        for (int index = 0; index < bulletBossF.Length; index++)
        {
            if (bulletBossF[index].activeSelf)
            {
                bulletBossF[index].SetActive(false);
            }
        }

    }

    //Ʈ���ŷ� ����
    void OnTriggerEnter2D(Collider2D collision)
    {
        //���� �����Ұ��
        if(collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
            }
        }
        else if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            //���� �ð��� ���
            if (isRespawnTime)
                return;

            //�̹� ���� ������ ���
            if (isHit)
                return;

            isHit = true;
            life--;
            //�Ŀ��� ��ź���� �ʱ�ȭ
            power = 1;
            boom = 2;
            //���� �Ŵ����� ���� �������� 
            gameManager.UpdateBoomIcon(boom);
            gameManager.UpdateLifeIcon(life);

            //�÷��̾� ��ġ�� ��������Ʈ
            gameManager.CallExplosion(transform.position, "P");

            if (life == 0)
            {
                gameManager.GameOver();
            }
            else
            {
                gameManager.RespawnPlayer();
            }
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
        //������ ����
        else if(collision.gameObject.tag == "Item")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            switch (item.type)
            {
                case "Score":
                    score += 1000;
                    break;
                case "Power":
                    if (power == maxPower)
                        score += 500;
                    else
                        power++;
                    break;
                case "Boom":
                    if (boom == maxBoom)
                        score += 1000;
                    else
                    {
                        boom+=1;
                        gameManager.UpdateBoomIcon(boom);
                    }
                    break;
            }
            collision.gameObject.SetActive(false);
        }
    }

    //��ź ����Ʈ ���� �Լ�
    void OffBoomEffect()
    {
        boomEffect.SetActive(false);
        isBoomTime = false;
    }

    //���� ���˵��� �ʾ��� ���
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
            }
        }
    }

}
