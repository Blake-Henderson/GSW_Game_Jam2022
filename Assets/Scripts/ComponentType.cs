using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentType : MonoBehaviour
{
    public enum types
    {
        element,
        attack,
        effect,
        spell
    }
    public types type;
}
