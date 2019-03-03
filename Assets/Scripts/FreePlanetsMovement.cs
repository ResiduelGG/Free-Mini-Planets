using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreePlanetsMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public CircleCollider2D planetFomationColl;
    private Vector2 velocity;
    private float velocityXSmoothing;
    private float velocityYSmoothing;
    private float accelerationTime = 0.5f;
    private Vector2 clickPosition;
    private float maxLeft;
    private float maxRight;
    private float maxTop;
    private float maxBot;
    private Vector2 formationExtends;
    private bool canMove = false;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        clickPosition = new Vector2(0, 0);
        cam = Camera.main;

        Vector3 viewportEnd = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
        Vector3 viewportStart = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));

        formationExtends = planetFomationColl.bounds.extents;

        maxLeft = viewportStart.x + formationExtends.x;
        maxRight = viewportEnd.x - formationExtends.x;
        maxTop = viewportEnd.y - formationExtends.y;
        maxBot = viewportStart.y + formationExtends.y;
    }

    float Hermite(float t)
    {
        return -t*t*t*2f + t*t*3f;
    }

    public void startMoving() {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && Input.GetKeyDown(KeyCode.Mouse0)){

            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (clickPosition.x < maxLeft) {
                clickPosition.x = maxLeft;
            }

            if (clickPosition.x > maxRight) {
                clickPosition.x = maxRight;
            }

            if (clickPosition.y > maxTop) {
                clickPosition.y = maxTop;
            }

            if (clickPosition.y < maxBot) {
                clickPosition.y = maxBot;
            }
        }

        Vector2 newPosition = new Vector2(
            Mathf.SmoothDamp(transform.position.x, clickPosition.x, ref velocityXSmoothing, accelerationTime, moveSpeed),
            Mathf.SmoothDamp(transform.position.y, clickPosition.y, ref velocityYSmoothing, accelerationTime, moveSpeed)
        );

        transform.position = newPosition;
    }
}
