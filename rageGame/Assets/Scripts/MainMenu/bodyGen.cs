using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyGen : MonoBehaviour
{

    public bodyMovement body;


    public void SpawnBody() {
        Instantiate(body, transform.position, Quaternion.identity);
    }
}
