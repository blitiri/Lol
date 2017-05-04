using UnityEngine;
using System.Collections;

public class MeleeMinion : Minion {
    ///// <summary>
    ///// Distance between this minion and its target to keep during attack.
    ///// </summary>
    //public float distance;
    /// <summary>
    /// The angle of the sword animation.
    /// </summary>
    public float swordAniAngle;
    /// <summary>
    /// The weapon of the minion.
    /// </summary>
    public GameObject swordPrefab;

    //private void Update()
    //{
    //    if (target)
    //    {
    //        start
    //    }
    //}

    public override IEnumerator Attack()
    {
        myNavMeshAg.SetDestination(transform.position);
        while (Vector3.Distance(transform.position, target.transform.position) > transform.lossyScale.z + target.transform.lossyScale.z / 2)
        {
            transform.LookAt(target.transform);
            transform.Translate(Vector3.forward * movementSpeedDuringAttack * Time.deltaTime, Space.Self);
            yield return null;
        }
        Vector3 swordStartPos = new Vector3(transform.position.x + transform.lossyScale.x / 2, transform.position.y + transform.lossyScale.y / 4, transform.position.z + transform.lossyScale.z / 2);
        GameObject sword = Instantiate(swordPrefab, swordStartPos, swordPrefab.transform.rotation) as GameObject;
        sword.transform.LookAt(transform.position);
        sword.transform.SetParent(transform);
        float rotation = 0;
        while(rotation < 90)
        {
            sword.transform.RotateAround(transform.position, Vector3.up, swordAniAngle * Time.deltaTime);
            rotation += swordAniAngle * Time.deltaTime;
        }
        sword.transform.position = swordStartPos;
        sword.transform.LookAt(transform.position);
    }
}
