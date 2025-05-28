using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPorta3 : MonoBehaviour
{
    
    public Animator portaTresAnimaçao;
    public bool terceiroQuiz;

    // Start is called before the first frame update
    void Start()
    {
        terceiroQuiz = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DoorCollider");
        {
            terceiroQuiz = true;
            portaTresAnimaçao.SetBool("terceiroQuiz", terceiroQuiz);
        }
    }
}