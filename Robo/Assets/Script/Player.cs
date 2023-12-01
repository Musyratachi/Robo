using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    Animator anim;
    float Horizontal;
    bool olhandoDireita = true;
    bool noChao = false;
    int contagemDePulo = 0;
    GameObject Interagir;
    [SerializeField] LayerMask camadaChao;
    [SerializeField] float forcaPulo = 350f;
    [SerializeField] Transform detectaChao;
    [SerializeField] LayerMask pisavel;
    [SerializeField] GameObject respawn;


    void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        noChao = Physics2D.OverlapCircle(detectaChao.position, 0.2f, camadaChao);
        if (noChao)
        {
            contagemDePulo = 2;
        }
        anim.SetBool("noChao", noChao);
        if (Input.GetButtonDown("Jump") && contagemDePulo > 0)
        {
            rbPlayer.AddForce(Vector2.up * forcaPulo);
            contagemDePulo--;
        }
        anim.SetFloat("Horizontal", Horizontal);
        Horizontal = Input.GetAxis("Horizontal");
        GerenciarFlip();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Interagir.CompareTag("Switch"))
            {
                Interagir.GetComponent<Interurptor>().Destrancar();
            }
            if (Interagir.CompareTag("Placa"))
            {
                Interagir.GetComponent<Placa>().Interagir();
            }
            if (Interagir.CompareTag("Porta"))
            {
                Interagir.GetComponent<Porta>().Teleportar(this.transform);
            }
        }
    }

    private void FixedUpdate()
    {
        rbPlayer.velocity = new Vector2(Horizontal * 8, rbPlayer.velocity.y);
    }

    void Flip()
    {
        olhandoDireita = !olhandoDireita;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    void GerenciarFlip()
    {
        if (Horizontal > 0 && !olhandoDireita)
            Flip();
        if (Horizontal < 0 && olhandoDireita)
            Flip();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Morte"))
        {
            Destroy(this.gameObject);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Switch") || collision.gameObject.CompareTag("Placa") || collision.gameObject.CompareTag("Porta"))
        {
            Interagir = collision.gameObject;
        }
        else
        {
            Interagir = null;
        }
    }
    void InstanciarRobo()
    {
        Instantiate(respawn);
    }
}