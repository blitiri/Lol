using UnityEngine;
using System.Collections;

public class MegaBomb : MonoBehaviour
{
    public Transform endPos;
    public float timeJourney = 0.01f;

    // Update is called once per frame
    void Update ()
    {
        transform.position = Vector3.Slerp(transform.position, endPos.position, timeJourney);
    }
}
