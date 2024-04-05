using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(killMe());
    }

    void Update()
    {

    }

    private IEnumerator killMe()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
