using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpellController : NetworkBehaviour {
    public List<GameObject> spellStages;
    public int currentStage = 0;

    [Server]
    public void TriggerNextStage()
    {
        if (currentStage+1 < spellStages.Count)
        {
            RpcTriggerNextStage();
        }
        else
        {
            RpcDestroySpell();
        }
    }

    [ClientRpc]
    public void RpcTriggerNextStage()
    {
        if (currentStage+1 < spellStages.Count)
        {
            spellStages[currentStage].SetActive(false);
            currentStage++;
            spellStages[currentStage].SetActive(true);
        }
    }

    [ClientRpc]
    public void RpcSetCurrentStage(int stage)
    {
        currentStage = stage;
        foreach (GameObject currStage in spellStages)
        {
            currStage.SetActive(false);
        }
        spellStages[stage].SetActive(true);
    }

    [ClientRpc]
    public void RpcDestroySpell()
    {
        Destroy(gameObject);
    }
}
