using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] Transform[] pontos;
    [SerializeField] GameObject saw;
    [SerializeField] float velocidade = 1f;
    public int direcao = 1;

    void Update()
    {
        if (direcao == 1)
        {
            saw.transform.position = Vector3.MoveTowards(saw.transform.position, pontos[1].position, velocidade * Time.deltaTime);
            if(Vector3.Distance(saw.transform.position, pontos[1].position) < 0.01f)
            {
                direcao = -1;
            }
        }
        else
        {
            saw.transform.position = Vector3.MoveTowards(saw.transform.position, pontos[0].position, velocidade * Time.deltaTime);
            if (Vector3.Distance(saw.transform.position, pontos[0].position) < 0.01f)
            {
                direcao = 1;
            }
        }
   
    }
}
