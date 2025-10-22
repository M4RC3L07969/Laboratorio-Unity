using UnityEngine;
using UnityEngine.Events; // Importante! Adicionar o namespace do UnityEvent

public class AreaTriggerActivator : MonoBehaviour
{
    [Header("Componente a Ativar")]
    [Tooltip("Arraste o objeto que contém o script de Spawner (Sala 2 ou Sala 3) aqui.")]
    public MonoBehaviour spawnerToActivate;

    [Tooltip("O nome do método a ser chamado no componente alvo. Deve ser público e sem parâmetros.")]
    public string activationMethodName = "AtivarSpawner";

    [Tooltip("A tag do objeto que deve ativar o trigger (ex: Player)")]
    public string tagDoAtivador = "Player";

    // NOVO: UnityEvent para configurar o que acontece no Power-Up Manager
    [Header("Ação do Power-Up Manager")]
    [Tooltip("Configure aqui qual método do PowerUpManager deve ser chamado (ex: MudarSpawnParaSala2).")]
    public UnityEvent OnPlayerEnter; // Cria a lista de eventos no Inspector

    private bool jaAtivou = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagDoAtivador) && !jaAtivou)
        {
            // 1. Ativa o Spawner (Lógica original)
            if (spawnerToActivate != null)
            {
                spawnerToActivate.Invoke(activationMethodName, 0f);
                Debug.Log($"Colisor '{gameObject.name}' ativado. Spawner '{spawnerToActivate.gameObject.name}' iniciado.");
            }
            else
            {
                Debug.LogWarning($"Referência 'spawnerToActivate' não está definida. Apenas a ação do Power-Up Manager será executada, se configurada.");
            }

            // 2. CHAMA O EVENTO CONFIGURADO NO INSPECTOR
            OnPlayerEnter.Invoke();
            Debug.Log($"Ação do PowerUp Manager executada via UnityEvent.");

            jaAtivou = true;
        }
    }
}