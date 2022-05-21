using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : CommandBase
{
    public override void Execute()
    {
        Debug.Log("Attack Executed");
    }

    public AttackCommand()
    {
        Name = "Attack";
    }

    public override void SetEntity(IGameEntity gameEntity)
    {
        base.SetEntity(gameEntity);
    }

    public override void Undo()
    {
        
    }
}
