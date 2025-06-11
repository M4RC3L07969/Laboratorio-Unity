using UnityEngine;

public class InimigoMorrer : MonoBehaviour
{
    public int vidaInimigo = 5;
    public int vidaMaxima = 10;
    public float tamanhoInicial = 46f;
    public float aumentoTamanho = 1.5f;

    private int contadorAumentos = 0;
    private float tamanhoAtual;

    private void Start()
    {
        tamanhoAtual = tamanhoInicial;
        transform.localScale = Vector3.one * tamanhoInicial;
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tagBala = collision.gameObject.tag;

        if (tagBala == "bala ácido")
        {
            vidaInimigo -= 1;
            AumentarTamanhoInimigo();
        }
        else if (tagBala == "bala base" && vidaInimigo < vidaMaxima)
        {
            vidaInimigo += 1;
        }

        if (vidaInimigo <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void AumentarTamanhoInimigo()
    {
        if (contadorAumentos < 5)
        {
            tamanhoAtual *= aumentoTamanho;
            contadorAumentos++;
            transform.localScale = Vector3.one * tamanhoAtual;
        }
    }
}
