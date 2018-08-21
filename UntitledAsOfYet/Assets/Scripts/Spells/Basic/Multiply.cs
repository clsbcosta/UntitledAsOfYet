using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Multiply : SpellStage {
    public int multiplyNumber;

    public void Update()
    {
        if (spellController.isServer)
        {
            for (int i = 0; i < multiplyNumber; i++)
            {
                GameObject newSpell = Instantiate(transform.parent.gameObject,
                    transform.parent.position,
                    Quaternion.AngleAxis(360 * i / multiplyNumber, Vector3.up));
                NetworkServer.Spawn(newSpell);
                SpellController newController = newSpell.GetComponent<SpellController>();
                newController.RpcSetCurrentStage(spellController.currentStage + 1);
            }
            spellController.RpcDestroySpell();
        }
    }
}
