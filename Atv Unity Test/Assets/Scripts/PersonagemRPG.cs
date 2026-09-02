using UnityEngine;
using System.Collections;

public class PersonagemRPG : MonoBehaviour
{
    [Header("Atributos")]
    public string nome;
    public int vida, nivel;
    public float velocidade;
    public bool estaVivo;

    private const int VIDA_MAXIMA = 100;
    private const float GRAVIDADE = 9.8f;

    void Start()
    {
        nome = "Leon";
        nivel = 3;
        vida = 100;
        velocidade = 7.5f;
        estaVivo = true;

        Debug.Log("=== Ficha do Personagem ===\nNome: " + nome + " | Nível: " + nivel + " Vida: " + vida + "/" + VIDA_MAXIMA + " | Velocidade: " + velocidade + " Status: " + (estaVivo ? "Vivo" : "Morto"));

        vida -= 50;

        Debug.Log("=== Ficha do Personagem ===\nNome: " + nome + " | Nível: " + nivel + " Vida: " + vida + "/" + VIDA_MAXIMA + " | Velocidade: " + velocidade + " Status: " + (estaVivo ? "Vivo" : "Morto"));
    }
}