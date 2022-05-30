using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputCollection
{
    public class InputPackage : IInputPackage
    {
        private KeyCode _key;
        private IInputMap _input;

        public KeyCode Key
        {
            get => _key;
        }

        public IInputMap Input
        {
            get => _input;
        }

        public InputPackage(KeyCode key, IInputMap input)
        {
            _key = key;
            _input = input;
        }
    }
}
