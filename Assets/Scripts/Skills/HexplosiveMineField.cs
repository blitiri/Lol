using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu]
public class HexplosiveMineField : Abilities
{
    public GameObject minePrefab;
    public Transform[] mineField;

    public override void OnAbilityActivation()
    {
        for(int i=0;i<mineField.Length;i++)
        {
            GameObject mines = Instantiate(minePrefab) as GameObject;
            mines.transform.position = mineField[i].position;

        }
    }
}
