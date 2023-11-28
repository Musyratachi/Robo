using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    Animator anim;
    Player player;
    [SerializeField] GameObject[] porta;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }
    public void destrancada()
    {
        Debug.Log("apertou");
        anim.SetBool("Destrancada", true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("Abrindo", true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //player.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                //Teleportar();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("Abrindo", false);
    }
    void Teleportar()
    {
        player.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
    }
}
