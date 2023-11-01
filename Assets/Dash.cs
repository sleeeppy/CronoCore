using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    public float dashDistance = 5.0f;
    public float dashSpeed = 10.0f;

    private bool isDashing = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isDashing)
        {
            StartCoroutine(Dashing());
        }
    }

    IEnumerator Dashing()
    {
        isDashing = true;

        Vector3 dashDirection = transform.forward;
        Vector3 targetPosition = transform.position + dashDirection * dashDistance;

        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * dashSpeed);
        }
        isDashing = false;

        yield return null;
    }
}
