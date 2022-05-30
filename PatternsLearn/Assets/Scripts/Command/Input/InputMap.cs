using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputCollection
{
    public class InputMap : IInputMap
    {
        protected string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public InputMap(string name)
        {
            _name = name;
        }

        public virtual ICommand CreateNewCommand()
        {
            switch (_name)
            {
                case "Jump":
                    return new JumpCommand();
                case "Attack":
                    return new AttackCommand();
            }

            return null;
        }
    }
}
