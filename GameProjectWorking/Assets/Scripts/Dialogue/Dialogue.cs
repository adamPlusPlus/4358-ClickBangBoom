using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    public string playerName;
    [TextArea(3,20)]
    public string[] sentences;
}
