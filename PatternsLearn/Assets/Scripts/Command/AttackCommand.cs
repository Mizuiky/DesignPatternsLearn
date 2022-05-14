using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand
{
    private IGameEntity _gameActor;

    public AttackCommand(IGameEntity gameActor)
    {
        _gameActor = gameActor;
    }

   public virtual void Execute()
   {
       
   }
    public void Undo()
    {
        
    }
}
