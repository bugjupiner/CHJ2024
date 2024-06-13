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

    [Space(10)]
    public SpriteRenderer parentSprite;
    public SpriteRenderer thisSprite;
    public int sortingDifference = 1;

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

        if(parentSprite != null)
        {
            thisSprite.sortingOrder = parentSprite.sortingOrder + sortingDifference;
        }
    }

    void FindAndSet()
    {
        GameObject targetObj = GameObject.Find(targetName);
        if(targetObj == null) return;
        target = targetObj.transform;
        SetNodes(target);
    }
}
