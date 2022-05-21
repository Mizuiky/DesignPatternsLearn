using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : CommandBase
{
    public override void Execute()
    {
        Debug.Log("Jump Executed");
    }

    public JumpCommand()
    {
        Name = "Jump";
    }

    public override void SetEntity(IGameEntity gameEntity)
    {
        base.SetEntity(gameEntity);
    }

    public override void Undo()
    {

    }
}
