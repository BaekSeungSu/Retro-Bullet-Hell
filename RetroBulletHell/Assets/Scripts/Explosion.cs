using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    Animator anim;

    private AudioSource audioSource;
    void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        Invoke("Disable", 2f);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    public void startExplosion(string target)
    {
        anim.SetTrigger("OnExplosion");
        audioSource.Play();
        switch (target)
        {
            case "P":
                transform.localScale = Vector3.one * 1f;
                break;
            case "S":
                transform.localScale = Vector3.one * 0.7f;
                break;
            case "M":
                transform.localScale = Vector3.one * 1f;
                break;
            case "L":
                transform.localScale = Vector3.one * 2f;
                break;
            case "SS":
                transform.localScale = Vector3.one * 0.7f;
                break;
            case "MM":
                transform.localScale = Vector3.one * 1f;
                break;
            case "LL":
                transform.localScale = Vector3.one * 2.5f;
                break;
            case "Boss1":
                transform.localScale = Vector3.one * 4f;
                break;
            case "Boss2":
                transform.localScale = Vector3.one * 4.2f;
                break;
        }
    }
}
