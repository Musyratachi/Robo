using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interurptor : MonoBehaviour
{
    Animator anim;
    Porta porta;
    [SerializeField] GameObject Porta;
    [SerializeField] float cronograma;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        porta = GetComponent<Porta>();
    }

    private void Update()
    {
        cronograma = Time.deltaTime;
        if (cronograma > 3f)
        {
            anim.SetBool("destrancar", false);
        }
    }

    public void Destrancar()
    {
        anim.SetBool("destrancar", true);
        Porta.GetComponent<Porta>().destrancada();
    }
}