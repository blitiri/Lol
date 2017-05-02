using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour
{
    public float damage = 10.0f;
    public float timerDeath = 4.0f;

    void Start()
    {
        Destroy(this.gameObject, timerDeath);
    }

    void OnTriggerEnter(Collider other)
    {
        if(/*other.gameObject.tag=="EnemyMinion" ||*/ other.gameObject.tag=="Player")
        {
            Debug.Log("Colpito");
            //aggiungere danno 
            Destroy(this.gameObject);
        }
    }
}
