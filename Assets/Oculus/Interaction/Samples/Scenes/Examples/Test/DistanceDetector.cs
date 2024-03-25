using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Untested code, run for testing after get the cord!!!
/// </summary>
public class DistanceDetector : MonoBehaviour
{
    //public GameObject Hand;
    public GameObject targetObject;
    public float maxDistance;
    public float minDistance;
    //private SkinnedMeshRenderer skinnedMeshRenderer;
    public OVRHand leftHand;

    //private OVRInput.Hand OVRHand;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //float distance = Vector3.Distance(Hand.transform.localPosition, targetObject.transform.position);
        //Debug.Log("Hand" + Hand.transform.localPosition);

        
        float distance = Vector3.Distance(leftHand.PointerPose.position, targetObject.transform.position);
        Debug.Log("Hand" + leftHand.PointerPose.position);
        Debug.Log("distance" + distance);
        
        
        //add same component to the right hand after testing lefthand successfully

        if (distance < maxDistance & distance > minDistance)
        {
            float diff = distance - minDistance;
            float rangeDistance = maxDistance - minDistance;
            float keyValue = (1 - diff / rangeDistance) * 100;
            Debug.Log("keyvalue" + keyValue);
            //skinnedMeshRenderer.SetBlendShapeWeight(0, keyValue));
            
            GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0,keyValue);

        }
        else if (distance >= maxDistance)
        {
            GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0,0);
        }
        else if (distance < minDistance)
        {
            GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0,100);
        }

    }
}
