using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour
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
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
