using System.Collections;
using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    public Material material1; // Primeiro material
    public Material material2; // Segundo material

    private Renderer rend;
    private bool usingFirstMaterial = true;
    public float switchInterval = 20f;

    void Start()
    {
        rend = GetComponent<Renderer>();

        if (material1 != null && material2 != null)
        {
            rend.material = material1;
            StartCoroutine(SwitchMaterialRoutine());
        }
        else
        {
            Debug.LogWarning("Atribua os dois materiais no Inspector.");
        }
    }

    IEnumerator SwitchMaterialRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(switchInterval);

            if (usingFirstMaterial)
                rend.material = material2;
            else
                rend.material = material1;

            usingFirstMaterial = !usingFirstMaterial;
        }
    }
}
