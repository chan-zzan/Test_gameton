using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove_E : MonoBehaviour
{
    [SerializeField] Transform Target;

    private void LateUpdate()
    {
        Vector3 pos = new Vector3(Target.position.x, Target.position.y, this.transform.position.z);
        this.transform.position = pos;
    }

}
