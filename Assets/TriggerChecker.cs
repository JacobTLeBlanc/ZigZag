using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when object exits trigger
    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Ball") {
            
            // Delay by 0.5s
            Invoke("FallDown", 0.5f);
        }
    }

    void FallDown() {
        GetComponentInParent<Rigidbody>().useGravity = true;

        // Destroy after 2 seconds
        Destroy(transform.parent.gameObject, 2f);
    }
}
