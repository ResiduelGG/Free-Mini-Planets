using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreePlanetsRotation : MonoBehaviour
{

    public float planetSpread = 5f;
    public float planetRotationSpeed = 10f;
    public GameObject[] freePlanets;
    private float planetRadius;
    private float planetWidth;

    // Start is called before the first frame update
    void Start()
    {
        CircleCollider2D p1Collider = freePlanets[0].GetComponent<CircleCollider2D>();
        planetWidth = p1Collider.bounds.size.x * p1Collider.transform.localScale.x;
        planetRadius = p1Collider.radius * p1Collider.transform.localScale.y;

        spreadPlanets();
    }

    void spreadPlanets() {
        for(int i = 0; i < freePlanets.Length; i++) {
            if (freePlanets[i] != null) {
                float angle = ((Mathf.PI * 2f) / freePlanets.Length) * i;
                Vector2 offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                offset *= planetRadius;
                offset.x *= freePlanets[i].transform.localScale.x;
                offset.y *= freePlanets[i].transform.localScale.y;
                // Vector3 bodyPosition = offset * (1.0f - ((planetRadius * planetWidth) / (freePlanets[i].transform.localScale.x * offset.magnitude))) * planetSpread;
                Vector3 bodyPosition = offset * (1.0f - ((planetRadius * planetWidth) / (freePlanets[i].transform.localScale.x * offset.magnitude))) * planetSpread;
                //Debug.Log(bodyPosition);
                // freePlanets[i].transform.localPosition = new Vector2(freePlanets[i].transform.localPosition.x + bodyPosition.x / 10f, freePlanets[i].transform.localPosition.y + bodyPosition.y / 10f);
                //freePlanets[i].transform.localPosition = bodyPosition;
                
                //freePlanets[i].transform.RotateAround(transform.position + bodyPosition * 5f, Vector3.forward, Time.deltaTime * planetRotationSpeed * 10f);

                // Vector3 desiredPosition = (freePlanets[i].transform.position - transform.position).normalized * planetSpread + transform.position;
                // freePlanets[i].transform.position = Vector3.MoveTowards(freePlanets[i].transform.position, desiredPosition, Time.deltaTime * planetRotationSpeed);
                freePlanets[i].transform.localPosition = bodyPosition;
            }
        }
            
    }

    float Hermite(float t)
    {
        return -t*t*t*2f + t*t*3f;
    }

    // Update is called once per frame
    void Update()
    {
        // planetSpread = Mathf.PingPong(Time.time * 5f, 7.5f) + 3f;
        // planetSpread = (Mathf.Sin(Mathf.PingPong(Time.time*Mathf.PI, Mathf.PI))+1)*0.5f*10f;
        
        //planetSpread = Hermite(Mathf.PingPong(Time.time * 1f, 1f))*10f + 3f;
        
        spreadPlanets();
        transform.Rotate(Vector3.forward * Time.deltaTime * planetRotationSpeed * 10f, Space.Self);
        // Vector2 mousePosInworld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // transform.position = mousePosInworld;

    }
}
