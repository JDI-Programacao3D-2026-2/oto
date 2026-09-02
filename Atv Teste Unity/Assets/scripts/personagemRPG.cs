using UnityEngine;

public class personagemRPG : MonoBehaviour
{

     //Start is called once before the first execution of Update after the MonoBehaviour is created
     void Start()
    {
        string nome = "Huguinho";
        int vida = 10;
        float velocidade = 7.5f;
        int nivel = 3;
        bool estaVivo = true;

        const int VIDA_MAXIMA = 100;

        Debug.Log( $"=== Ficha do Personagem == Nome: {nome} |Nivel: {nivel} |Vida: {vida}/{VIDA_MAXIMA} | Velocidade {velocidade} | {estaVivo}");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
