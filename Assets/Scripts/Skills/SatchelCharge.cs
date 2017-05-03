using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu]
public class SatchelCharge :Abilities
{
    public GameObject satchelPrefab;
    public Transform satchelChargePos;
    public Camera mainCamera;
    private Vector3 mousePosition;

    public override void OnAbilityActivation()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 7.8f;
        GameObject satchel = Instantiate(satchelPrefab, mainCamera.ScreenToWorldPoint(mousePosition),Quaternion.identity) as GameObject;
        //satchel.transform.position = satchelChargePos.position;
    }
}
