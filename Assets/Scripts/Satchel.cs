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
                other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 5000 * Time.deltaTime);
                Destroy(this.gameObject);
            }
        }
    }
}
