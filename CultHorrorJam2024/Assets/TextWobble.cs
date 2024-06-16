using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWobble : MonoBehaviour
{
    // from Madalaski https://www.youtube.com/watch?v=FgWVW2PL1bQ
    public TMP_Text textMesh;
    public float fps = 15;

    private Mesh mesh;
    private Vector3[] vertices;

    private float t = 0f;


    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if(t < 1/fps) return;
        else t = 0;

        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;

        for(int i= 0; i < textMesh.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo c = textMesh.textInfo.characterInfo[i];
            int index = c.vertexIndex;

            Vector3 offset = Wobble(Time.time + i);
            
            vertices[index] += offset;
            vertices[index + 1] += offset;
            vertices[index + 2] += offset;
            vertices[index + 3] += offset;
        }

        mesh.vertices = vertices;
        textMesh.canvasRenderer.SetMesh(mesh);
    }

    Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time*3.3f), Mathf.Cos(time*1.8f));
    }
}
