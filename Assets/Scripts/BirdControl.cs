using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    public float jumpSpeed;
    public float tiltSmooth;
    
    private Vector2 movement;
    private Rigidbody2D rb;
    private Quaternion downRotation;
    private Quaternion upRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -90);
        upRotation = Quaternion.Euler(0, 0, 35);
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.IsAction())
        {
            Jump();
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        transform.rotation = upRotation;
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);

        SoundManager.PlaySound((int)Constants.SoundsIndex.Jump);
    }
}
