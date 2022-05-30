using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputCollection
{
    public interface IInputMap
    {
        public string Name { get; set; }

        public ICommand CreateNewCommand();
    }
}

