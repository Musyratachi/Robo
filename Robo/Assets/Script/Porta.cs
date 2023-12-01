using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    Animator anim;
    [SerializeField] GameObject porta;
    bool Destrancada = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (!Destrancada) 
        {
            anim.SetBool("Abrindo", false);
        }
    }
    public void destrancada()
    {
        anim.SetBool("Destrancada", true);
    }
    public void EstouTrancada(bool destrancada)
    {
        Destrancada = destrancada;
        anim.SetBool("Destrancada", Destrancada);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Destrancada)
            {
                anim.SetBool("Abrindo", true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Destrancada)
        {
            anim.SetBool("Abrindo", false);
        }
    }
    public void Teleportar(Transform player)
    {
        player.position = porta.transform.position;
        //player.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
    }
}
