using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public GameObject asteroid;
    // public BoxCollider2D[] colliders;
    public CircleCollider2D coll;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        //coll = GetComponent<BoxCollider2D>();
        // cam = Camera.main;
        // Vector2 randomPoint = cam.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), cam.nearClipPlane));
        // //spawnAsteroid(getSpawnPoint(randomPoint));
        //spawnAsteroidCircle(randomPoint);
       
        
    }

    public void startSpawningAsteroids() {
        InvokeRepeating("spawnAsteroid", 0.2f, 1f);
    }

    public void spawnAsteroid()
    {
        GameObject spawnedAsteroid = Instantiate(asteroid, new Vector2(0, 0), Quaternion.identity);
        
        float angle = Random.value * 360;
        spawnedAsteroid.transform.position = coll.gameObject.transform.position + new Vector3(coll.offset.x, coll.offset.y, 0) + // Center of the collider
                                        Vector3.right * coll.radius * Mathf.Cos( angle ) + // Horizontal position
                                        Vector3.up * coll.radius * Mathf.Sin( angle ) ; // Vertical position                     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Vector2 getSpawnPoint(Vector2 point) {
    //     Vector2 spawnPoint = new Vector2(0, 0);
    //     float prevDistance = 0f;

    //     for (int i = 0; i < colliders.Length; i++)
    //     {
    //         Debug.Log(i);

    //         Vector2 closestPoint = colliders[i].bounds.ClosestPoint(point);
    //         float curDistance = Vector2.Distance(point, closestPoint);

    //         if (i != 0) {
    //             if (curDistance <= prevDistance) {
    //                 prevDistance = curDistance;
    //                 spawnPoint = closestPoint;
    //             }
    //         } else {
    //             prevDistance = curDistance;
    //             spawnPoint = closestPoint;
    //         }
    //     }

    //     return spawnPoint;
    // }

    // void spawnAsteroidCircle(Vector2 point) {
    //     Vector3 closestPoint = coll.bounds.ClosestPoint(point);

    //     Instantiate(asteroid, closestPoint, Quaternion.identity);
    // }

    // void spawnAsteroid(Vector2 point) {
    //     Instantiate(asteroid, point, Quaternion.identity);
    // }


     //Drag & drop your circle from the inspector
}
