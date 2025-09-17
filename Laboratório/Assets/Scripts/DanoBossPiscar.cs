using System.Collections;
using UnityEngine;

public class EnemyFlashMPB : MonoBehaviour
{
    Renderer rend;
    MaterialPropertyBlock mpb;

    public Color hitColor = Color.red;
    public float flashDuration = 0.15f;

    private Color originalColor;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        mpb = new MaterialPropertyBlock();

        // pega a cor base original do material
        originalColor = rend.sharedMaterial.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bala ácido"))
        {
            Flash();
        }
    }

    public void Flash()
    {
        // para flashes anteriores para não travar
        StopCoroutine("FlashRoutine");
        StartCoroutine("FlashRoutine");
    }

    IEnumerator FlashRoutine()
    {
        float t = 0f;

        while (t < flashDuration)
        {
            float lerp = Mathf.Sin((t / flashDuration) * Mathf.PI);

            rend.GetPropertyBlock(mpb);
            // mistura original -> hitColor
            mpb.SetColor("_Color", Color.Lerp(originalColor, hitColor, lerp));
            rend.SetPropertyBlock(mpb);

            t += Time.deltaTime;
            yield return null;
        }

        // garante que volta à cor original
        rend.GetPropertyBlock(mpb);
        mpb.SetColor("_Color", originalColor);
        rend.SetPropertyBlock(mpb);
    }
}
