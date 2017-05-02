using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu]
public class SatchelCharge :Abilities
{
    public GameObject satchelPrefab;
    public Transform satchelChargePos;

    public override void OnAbilityActivation()
    {
        GameObject satchel = Instantiate(satchelPrefab) as GameObject;
        satchel.transform.position = satchelChargePos.position;
    }
}
