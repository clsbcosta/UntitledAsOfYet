﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : Character
{
    // My Class and Race
    public PlayableClass myClass;
    public PlayableRace myRace;

    // Camera Settings
    private Transform head;
    [HideInInspector]
    public Vector3 lookPoint;
    private Vector3 camLockDirection;

    public override void Start()
    {
        if (isLocalPlayer)
        {
            transform.Find("Camera").gameObject.SetActive(true);
        }
        head = transform.Find("Head");
        base.Start();
    }

    public override void Update()
    {
        if (isLocalPlayer)
        {
            CheckInputs();
        }
        base.Update();
    }

    private void CheckInputs()
    {
        // Check movement keys
        CheckMovementInputs();
        CheckMouseLook();

        // Testing
        CheckCasts();
    }

    private void CheckCasts()
    {
        if (Input.GetKeyUp("1"))
            CmdCastSpell("Testing/Projectile", lookDirection);
        if (Input.GetKeyUp("2"))
            CmdCastSpell("Testing/Explosion", lookDirection);
        if (Input.GetKeyUp("3"))
            CmdCastSpell("Testing/Multiply", lookDirection);
    }

    private void CheckMovementInputs()
    {
        Vector3 moveDirection = Vector3.zero;
        float inputForward = Input.GetAxis("Vertical");
        float inputSide = Input.GetAxis("Horizontal");
        moveDirection += (inputForward * transform.forward).normalized;
        moveDirection += (inputSide * transform.right).normalized;
        // Have to implement movespeed attrib modifier
        transform.position += moveDirection * 0.1f;
    }

    private void CheckMouseLook()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        lookPoint = Physics.Raycast(camRay, out hitInfo, 100) ? hitInfo.point : camRay.GetPoint(25);
        lookDirection = lookPoint - head.position;
        Debug.DrawLine(head.position, lookPoint, Color.blue);
    }

    protected override void LoadMyAttributes()
    {
        baseAttributes = RaceData.PlayableRaces[myRace].baseAttributes; // Set base attributes from race
        baseAttribPercMods  = ClassData.PlayableClasses[myClass].baseAttributes; // Set base attribute percentage modifiers from class
    }

    protected override void LoadMySpells()
    {
        mySpells = ClassData.PlayableClasses[myClass].Spells;
    }
}
