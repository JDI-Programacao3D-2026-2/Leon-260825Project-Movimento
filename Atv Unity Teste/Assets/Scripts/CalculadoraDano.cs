using UnityEngine;

public class CalculadoraDano : MonoBehaviour
{
    public int ataque = 25, defesa = 10;
    public float multiplicador = 1.5f, vida = 100f;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("=== Turno " + (i+1) + " ===");
            float dano = CalcularDano();
            vida -= dano;
            Debug.Log("Dano real: " + dano + " | Dano " + (IsCritico(dano) ? "Crítico!" : "Normal.") + " | Vida restante: " + vida);
        }
    }
    public float CalcularDano()
    {
        float dano = (ataque - defesa) * multiplicador;
        return dano;
    }
    public bool IsCritico(float dano)
    {
        if (dano > 20f) return true;
        else return false;
    }
}