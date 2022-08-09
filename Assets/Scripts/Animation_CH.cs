using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_CH : MonoBehaviour
{
    // Variables.
    public Transform Character;
    float speed = 2;
    Animator anim;
    float constnt = 0.5f;
    

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        bool isWalking = anim.GetBool("isWalking");
        bool moving = Input.GetKey("w");

        // Movement.
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(direction * speed * Time.deltaTime);

        // Animation.
        if (!isWalking && moving)
        {
            anim.SetBool("isWalking", true);
        }

        if (isWalking && !moving)
        {
            anim.SetBool("isWalking", false);
        }

        // Mouse Rotation.
        Vector3 mousePos = Input.mousePosition;

        Vector3 objectPos = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x * constnt;
        mousePos.y = mousePos.y - objectPos.y * constnt;

        float angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle - 90, 0));
    }
}
