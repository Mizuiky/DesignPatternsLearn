using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : CommandBase
{
    public AttackCommand()
    {
        base._name = "Attack";
    }

    public override void Execute()
    {
        Debug.Log("Attack Executed");
    }

    public override void Undo()
    {
        
    }
}
