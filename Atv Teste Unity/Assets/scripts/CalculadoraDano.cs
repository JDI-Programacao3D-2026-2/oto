using UnityEngine;

public class CalculadoraDano : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int ataque = 25;
        int defesa = 10;
        float multiplicador = 1.5f;
        float danoReal = (ataque - defesa) * multiplicador;
        if (ataque <= 20)
        {
            Debug.Log("dano crítico!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }    
}
