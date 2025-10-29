using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPorta : MonoBehaviour
{
    public Animator portaoUmAnimaçao;
    public bool primeiroQuiz;

    public AudioSource somPortaSource;

    public AudioClip somPortaClip;
    public bool AudioTocou = false;

    void Start()
    {
        primeiroQuiz = false;
        if (somPortaSource == null)
            somPortaSource = gameObject.AddComponent<AudioSource>();

        somPortaSource.clip = somPortaClip;
        somPortaSource.playOnAwake = false;
        somPortaSource.volume = 0.2f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DoorCollider");
        {
            if (!AudioTocou)
            {
               somPortaSource.Play();
               AudioTocou = true;
            }

            primeiroQuiz = true;
            portaoUmAnimaçao.SetBool("primeiroQuiz", primeiroQuiz);
        }
    }
}