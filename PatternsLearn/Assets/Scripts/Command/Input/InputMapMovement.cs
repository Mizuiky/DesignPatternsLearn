using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputCollection
{
    public class InputMapMovement : InputMap
    {
        private Vector3 _direction;
        public Vector3 Direction
        {
            get => _direction;
            set => _direction = value;
        }

        //needed to refer base constructor in this children class constructor using :base(name)
        public InputMapMovement(string name, float x, float y, float z) : base(name)
        {
            _name = name;
            _direction = new Vector3(x, y, z);
        }

        public override ICommand CreateNewCommand()
        {
            return new MoveCommand(_direction);
        }
    }
}
