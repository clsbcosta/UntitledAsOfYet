using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    // My Class and Race
    public PlayableClass myClass;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        CheckInputs();
        base.Update();
    }

    private void CheckInputs()
    {
        // Check movement keys
        CheckMovementInputs();
    }

    private void CheckMovementInputs()
    {
        float inputForward = Input.GetAxis("Vertical");
        float inputSide = Input.GetAxis("Horizontal");
        Vector3 moveDirection = Vector3.zero;
        if (inputForward > 0)
        {
            moveDirection = Vector3.forward;
        }
        else if (inputForward < 0)
        {
            moveDirection = Vector3.back;
        }
        if (inputSide > 0)
        {
            moveDirection = moveDirection + Vector3.right;
        }
        else if (inputSide < 0)
        {
            moveDirection = moveDirection + Vector3.left;
        }
        transform.position = transform.position + moveDirection.normalized * attributes[AttributeType.MoveSpeed] * Time.deltaTime * 0.001f;
    }

    protected override void LoadMyAttributes()
    {
        baseAttributes = ClassData.PlayableClasses[myClass].baseAttributes;
    }

    protected override void LoadMySpells()
    {
        mySpells = ClassData.PlayableClasses[myClass].Spells;
    }
}
