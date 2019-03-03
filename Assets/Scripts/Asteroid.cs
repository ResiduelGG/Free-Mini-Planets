using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Camera cam;
    private Vector3 movementDirection;
    private float speed;
    private int rotationDirection;
    private bool suckedByBlackHole = false;
    private Vector3 blackHolePosition;
    private GameObject GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GM");
        cam = Camera.main;
        Vector2 randomPoint = cam.ViewportToWorldPoint(new Vector3(Random.Range(.1f, .9f), Random.Range(.1f, .9f), cam.nearClipPlane));
        Vector2 trans = transform.position;
        speed = Random.Range(.5f, 3f);
        movementDirection = (randomPoint - trans).normalized;
        rotationDirection = Random.Range(0,2)*2-1;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "GM") {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Planet") {
            GM.GetComponent<GM>().GameOver();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "BlackHole") {
            suckedByBlackHole = true;
            blackHolePosition = other.gameObject.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!suckedByBlackHole) {
            transform.Rotate(Vector3.forward * rotationDirection * speed * 100f * Time.deltaTime, Space.World);
            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        }

        if (suckedByBlackHole) {
            float step = speed * 10f * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, blackHolePosition, step);

            transform.localScale = new Vector2(transform.localScale.x / speed, transform.localScale.y / speed);

            transform.Rotate(Vector3.forward * rotationDirection * speed * 1000f * Time.deltaTime, Space.World);
        }
        
        if (suckedByBlackHole && transform.position == blackHolePosition) {
            GM.GetComponent<GM>().IncreaseScore();
            Destroy(this.gameObject);
        }
    }
}
