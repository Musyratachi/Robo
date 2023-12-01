using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacaoAutomatica : MonoBehaviour
{
    [SerializeField] float velocidadeRotacao = 1.6f;

    void Update()
    {
        Vector3 rotacaoAtual = transform.rotation.eulerAngles;
        rotacaoAtual.z += velocidadeRotacao;
        transform.rotation = Quaternion.Euler(rotacaoAtual);
    }
}
