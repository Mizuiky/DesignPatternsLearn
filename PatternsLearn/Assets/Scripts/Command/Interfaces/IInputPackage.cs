using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputCollection
{
    public interface IInputPackage
    {
        public KeyCode Key { get; }
        public IInputMap Input { get; }
    }
}
