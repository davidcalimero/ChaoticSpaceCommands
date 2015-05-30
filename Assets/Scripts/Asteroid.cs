using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
    public Transform centerPoint;

    // Use this for initialization
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = RotatePointAroundPivot(transform.position, centerPoint.position, new Vector3(0.5f, -0.5f, 0f));
    }

    Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = point - pivot;
        dir = Quaternion.Euler(angles) * dir;
        point = dir + pivot;
        return point;
    }
}
