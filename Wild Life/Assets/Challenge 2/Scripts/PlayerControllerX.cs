using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    float fireRange = 1;
    float timeSinceLatsFire = 0;



    private void Start()
    {

    }

    void Update()
    {
        timeSinceLatsFire += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && timeSinceLatsFire > fireRange)
        {
            timeSinceLatsFire = 0;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }

}   
