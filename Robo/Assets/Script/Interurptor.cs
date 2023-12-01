using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interurptor : MonoBehaviour
{
    Animator anim;
    [SerializeField] GameObject Porta;
    [SerializeField] float cronograma;
    bool destrancar = false;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Porta.GetComponent<Porta>().EstouTrancada(destrancar);
        if (destrancar)
        {
            cronograma += Time.deltaTime;
        }
        if (cronograma > 3f)
        {
            anim.SetBool("destrancar", false);
            destrancar = false;
            cronograma = 0;
        }
    }

    public void Destrancar()
    {
        anim.SetBool("destrancar", true);
        destrancar = true;
        Porta.GetComponent<Porta>().destrancada();
    }
}