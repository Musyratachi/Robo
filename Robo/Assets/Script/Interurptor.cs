using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interurptor : MonoBehaviour
{
    Animator anim;
    Porta porta;
    [SerializeField] GameObject Porta;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        porta = GetComponent<Porta>();
    }

    private void Update()
    {
        
    }

    public void Destrancar()
    {
        anim.SetBool("destrancar", true);
        Porta.GetComponent<Porta>().destrancada();
    }
}