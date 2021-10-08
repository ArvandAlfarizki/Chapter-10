using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    public float movementSpeed;
    public float moveConstraint;
    private Vector3 targetMove;

    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        moveConstraint = GameManager.Instance.areaConstraintValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x < moveConstraint && mousePos.x > -moveConstraint
                && mousePos.y < moveConstraint && mousePos.y > -moveConstraint)
            {
                targetMove = mousePos;
                targetMove.z = 0;
            }
        }

        if (transform.position != targetMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetMove, movementSpeed * Time.deltaTime);
        }
    }
}
