using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    private Animator bombAnimator;
    void Awake()
    {
        bombAnimator = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Explotado");
            bombAnimator.SetBool("Bomb", true);
            StartCoroutine(GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake(1f, 0.5f));
            GameManager.Instance.ContadorVida();
            AudioManager.Instance.SonidoExplosion();
            
        }
        Debug.Log("Explotado");
    }
    void Destroy()
    {
        Destroy(this.gameObject);
    }
}

