using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 offSet;
    void LateUpdate()
    {
        transform.position = PlayerController.Instance.transform.position + offSet;
    }
}
