using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    public float mouseSens = 100f;
    public Transform playerBody;
    private float xRotation = 0f;
    public float rotationSpeed = 1f; // the speed at which the player turns towards the npc they're talking to
    private Coroutine LookCoroutine; 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // lock cursor in middle of screen
    }

    void Update()
    {
        // mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // prevents overrotation

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); 
        playerBody.Rotate(Vector3.up * mouseX);

        if (GameManager.Instance.fDown)
        {
            StartRotating();
        }
    }

    public void StartRotating()
    {
        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }

        //LookCoroutine = StartCoroutine(LookAt());
    }

    // Under Construction (working on making the player look at the npc they're talking to)

    /*private IEnumerator LookAt()
    {
        Transform Target = GameManager.Instance.frog;
        Quaternion lookRotation = Quaternion.LookRotation(Target.position - playerBody.transform.position);

        float time = 0;
        while (time < 1)
        {
            playerBody.transform.rotation = Quaternion.Slerp(playerBody.transform.rotation, lookRotation, time);
            time += Time.deltaTime * rotationSpeed;
            yield return null;
        }
    }*/
}
