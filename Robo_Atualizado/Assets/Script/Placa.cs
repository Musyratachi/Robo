using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa : MonoBehaviour
{
    [SerializeField] GameObject painel;
    public void Interagir()
    {
        painel.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            painel.SetActive(false);
        }
    }
}
