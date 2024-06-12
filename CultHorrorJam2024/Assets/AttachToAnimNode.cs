using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PowerTools;

public class AttachToAnimNode : MonoBehaviour
{

    public Transform target;
    public string targetName = "";
    public int nodeIndex = 0;
    protected SpriteAnimNodes nodes;

    void OnEnable()
    {
        if(target == null) FindAndSet();
        else SetNodes(target);
        
    }

    void SetNodes(Transform newTarget)
    {
        nodes = newTarget.GetComponent<SpriteAnimNodes>();
    }

    void LateUpdate()
    {
        if(nodes == null)
        {
            if(targetName != null) FindAndSet();
            else return;
        }
        transform.position = nodes.GetPosition(nodeIndex);
    }

    void FindAndSet()
    {
        GameObject targetObj = GameObject.Find(targetName);
        if(targetObj == null) return;
        target = targetObj.transform;
        SetNodes(target);
    }
}
