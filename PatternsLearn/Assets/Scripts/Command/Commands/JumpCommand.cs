using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : CommandBase
{
    public JumpCommand()
    {
        base._name = "Jump";
    }

    public override void Execute()
    {
        Debug.Log("Jump Executed");
    }

    public override void Undo()
    {

    }
}
