using UnityEngine;
using System.Collections;

public class Satchel : MonoBehaviour
{

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Colpito");
                other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000 * Time.deltaTime,ForceMode.Impulse);
                Destroy(this.gameObject);
            }
        }
    }
}
