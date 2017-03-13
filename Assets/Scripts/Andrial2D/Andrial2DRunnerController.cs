using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andrial2DRunnerController : MonoBehaviour {

    [SerializeField] private float jumpForce;
    [SerializeField] private float groundCheckDistance;

    private Andrial2DAnimationHandler anim;
    private Rigidbody2D rb;
    private Vector3 halfWidth;
    private KeyCode attackKey = KeyCode.S;
    private KeyCode jumpKey = KeyCode.W;
    

    private void Start()
    {
        anim = FindObjectOfType<Andrial2DAnimationHandler>();
        rb = GetComponent<Rigidbody2D>();
        halfWidth = Vector3.right * GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    private void Update()
    {
        if (Input.GetKeyDown(attackKey))
            anim.StartAttackAnim();
        if (Input.GetKeyDown(jumpKey))
            Jump();

        //Debug.DrawLine(transform.position - halfWidth, transform.position - halfWidth + Vector3.down * groundCheckDistance);
    }

    private void Jump()
    {
        if (IsGrounded())
            rb.AddForce(Vector2.up * jumpForce);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - halfWidth, -Vector2.up, groundCheckDistance, LayerMask.GetMask("Ground"));

        if (hit)
            return true;
        else
            return false;
    }
}
