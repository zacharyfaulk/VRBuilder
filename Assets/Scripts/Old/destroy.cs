using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {

    private Collider _collider;
    void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private IEnumerator Die() {
 
        int i = 0;
        while (i < 45)
        {
            this.transform.Rotate(-2, 0, 0);
            this.transform.Translate(0, -0.0111f, 0, Space.World);
            i++;
            yield return new WaitForFixedUpdate();
        }

        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            _collider.enabled = false;
            StartCoroutine(Die());
        }
    }

}
