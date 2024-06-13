using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderReset : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        Shader.SetGlobalFloat("_InvertColors", 0.0f);
    }
}
