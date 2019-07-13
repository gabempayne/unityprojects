using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;

    public Rigidbody2D rb;

    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f;

    public Camera cameraView;

    public GameObject bulletImpact;
    public int currentAmmo;

    void Awake() {
        instance = this;
    }


    void Update() {

        // Player Movement
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveHorizontal = transform.up * -moveInput.x;
        Vector3 moveVertical = transform.right * moveInput.y;
               

        rb.velocity = (moveHorizontal + moveVertical) * moveSpeed;

        // Player Look
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

        cameraView.transform.localRotation = Quaternion.Euler(cameraView.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y));

        // Shooting
        if(Input.GetMouseButtonDown(0)) {
            if(currentAmmo > 0) {
                Ray ray = cameraView.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    Instantiate(bulletImpact, hit.point, transform.rotation);
                } else {
                    Debug.Log("I'm looking at nothing");
                }
                currentAmmo--;
            }            
        }
    }
}
