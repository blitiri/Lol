﻿using UnityEngine;
using System.Collections;

public class MinionEnemyDetector : MonoBehaviour {

    public Minion myMinion;

    private void Awake()
    {
        myMinion = GetComponentInParent<Minion>();
    }

    void OnTriggerEnter(Collider other)
    {
        switch (myMinion.tag)
        {
            case Register.enemyMinionTag:
                if (other.gameObject.tag == Register.playerTag)
                {
                    myMinion.target = other.gameObject;
                    myMinion.StartCoroutine(myMinion.Attack());
                }
                else if (other.gameObject.tag == Register.alliedMinionTag && !myMinion.target)
                {
                    myMinion.target = other.gameObject;
                    myMinion.otherMinion = other.gameObject.GetComponent<Minion>();
                    if (!myMinion.otherMinion.target)
                    {
                        myMinion.otherMinion.target = gameObject;
                        myMinion.StartCoroutine(myMinion.Attack());
                    }
                }
                break;
            case Register.alliedMinionTag:
                if (other.gameObject.tag == Register.enemyMinionTag && !myMinion.target)
                {
                    myMinion.target = other.gameObject;
                    myMinion.otherMinion = other.gameObject.GetComponent<Minion>();
                    if (!myMinion.otherMinion.target)
                    {
                        myMinion.otherMinion.target = gameObject;
                        myMinion.StartCoroutine(myMinion.Attack());
                    }
                }
                break;
        }
    }
}
