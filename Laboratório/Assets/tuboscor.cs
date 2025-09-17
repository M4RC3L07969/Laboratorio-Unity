using UnityEngine;

public class tuboscor : MonoBehaviour
{
    public Material matBase;
    public Material matAcido;
    private Renderer rend;
    private bool usandoMatBase = true;

    void Start()
    {
        rend = GetComponent<Renderer>();

        if (matBase != null && matAcido != null)
        {
            rend.material = matBase;
        }
        else
        {
            Debug.LogWarning("Atribua os dois materiais no Inspector.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bala ácido") && usandoMatBase)
        {
            rend.material = matAcido;
            usandoMatBase = false;
        }
        else if (collision.gameObject.CompareTag("bala base") && !usandoMatBase)
        {
            rend.material = matBase;
            usandoMatBase = true;
        }
    }
}
