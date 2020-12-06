using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rbody;
    [SerializeField] Transform gun;

    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        rbody.velocity = moveInput * moveSpeed;

        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.localPosition);

        if (mousePos.x < screenPos.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            gun.localScale = new Vector3(-1f, -1f, 1f);
        } else
        {
            transform.localScale = Vector3.one;
            gun.localScale = Vector3.one;
        }

        Vector2 offset = new Vector2(mousePos.x - screenPos.x, mousePos.y - screenPos.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        gun.rotation = Quaternion.Euler(0, 0, angle);
    }
}
