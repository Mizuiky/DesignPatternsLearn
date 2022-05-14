using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public Vector3 ReadInput()
    {
        float z = 0;

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            z = 1;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            z = -1;
        }

        float x = 0;
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            x = 1;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x = -1;
        }

        if(z != 0 || x != 0)
        {          
            return new Vector3(x, 0, z);
        }

        return Vector3.zero;  
    }

    public bool ReadUndo()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
