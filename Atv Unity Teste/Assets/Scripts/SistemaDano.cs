using UnityEngine;

public class SistemaDano : MonoBehaviour
{
    public string tipoAtaque = "Fogo";
    public int danoBase = 20;
    private float multiplicador;

    void Start()
    {
        switch (tipoAtaque)
        {
            case "Fogo":
                multiplicador = 2f;
                break;
            case "Gelo":
                multiplicador = 1.5f;
                break;
            case "Raio":
                multiplicador = 3f;
                break;
        }

        Debug.Log("Dano final: " + (danoBase * multiplicador));
    }
}