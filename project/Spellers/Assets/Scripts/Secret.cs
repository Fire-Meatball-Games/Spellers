using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime;
using CustomEventSystem;
using PlayerManagement;

public class Secret : MonoBehaviour
{
    private void OnEnable()
    {
        Events.OnSecretActivated.AddListener(UnlockAllLevels);
    }

    private void OnDisable()
    {
        Events.OnSecretActivated.RemoveListener(UnlockAllLevels);
    }

    public void UnlockAllLevels()
    {
        Debug.Log("Todos los niveles desbloqueados");
        Player.instance.LastLevelUnlocked = 15;
    }
}
