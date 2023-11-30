using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    Animator anim;
    Interurptor interurptor;
    float Horizontal;
    bool olhandoDireita = true;
    bool noChao = false;
    GameObject Interruptor;
    [SerializeField] LayerMask camadaChao;
    [SerializeField] float forcaPulo = 350f;
    [SerializeField] Transform detectaChao;
    [SerializeField] LayerMask pisavel;
    [SerializeField] GameObject respawn;


    void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        interurptor = GetComponent<Interurptor>();
    }

    void Update()
    {
        noChao = Physics2D.OverlapCircle(detectaChao.position, 0.2f, camadaChao);
        anim.SetBool("noChao", noChao);
        if (Input.GetButtonDown("Jump") && noChao)
        {
            rbPlayer.AddForce(Vector2.up * forcaPulo);
        }
        anim.SetFloat("Horizontal", Horizontal);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Interruptor.CompareTag("Switch"))
            {
                Interruptor.GetComponent<Interurptor>().Destrancar();
            }
        }
    }

    private void FixedUpdate()
    {
        Horizontal = Input.GetAxis("Horizontal");
        rbPlayer.velocity = new Vector2(Horizontal * 8, rbPlayer.velocity.y);
        GerenciarFlip();
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
        if (collision.gameObject.CompareTag("Switch"))
        {
            Debug.Log("Funcionou");
            Interruptor = collision.gameObject;
        }
        else
        {
            Interruptor = null;
        }
    }
    void InstanciarRobo()
    {
        Instantiate(respawn);
    }
}