using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTest : MonoBehaviour {
    private float counter;
    private bool dead;
    private Collider _collider;
    void Start()
    {
        counter = 0f;
        dead = false;
        _collider = GetComponent<Collider>();
    }

    void Update()
    {
        counter += Time.deltaTime;
          if(counter > 1 && dead == false)
          {
              StartCoroutine(Die());
              dead = true;
          }
    }

    private IEnumerator Die()
    {
        int i = 0;
        yield return new WaitForSeconds(3f);
        while (i < 45)
        {
            this.transform.Rotate(-2, 0, 0);
            this.transform.Translate(0, -0.0111f, 0, Space.World);
            i++;
            yield return new WaitForFixedUpdate();
        }

        Destroy(this.gameObject);
  
    }
}
