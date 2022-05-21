using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand 
{ 
    public string Name { get; set; }

    public IGameEntity Entity { get; set; }

    public void Execute();

    public void SetEntity(IGameEntity gameEntity);

    public void Undo();
}
