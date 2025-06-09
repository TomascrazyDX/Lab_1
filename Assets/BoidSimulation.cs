using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BoidSimulationControl : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject boidPrefab = null;
    public int BoidsToSpawn = 10;


    // to select and switch what mouse buttons do for Assignment1
    public enum ControlMode
    {
        seek,
        pursue,
        food,
        obstacle
    }
    //which mode are we in  (is selected with a mouse button)
    public ControlMode controlMode = ControlMode.seek;

    public List<Boid> boids = null;

    private void Start()
    {
        targetObject = GameObject.Find("target");

        Quaternion rotation = Random.rotation;
        Vector3 position = new Vector3(Random.Range(-1.4f, 1.4f), Random.Range(0f, 1.4f), Random.Range(-0.9f, 0.9f));

        //spawn the boids

        for (int i = 0; i <= BoidsToSpawn; i++)
        {
            GameObject spawnedBoid = Instantiate(boidPrefab, position, rotation);

            Boid boidComponent = spawnedBoid.GetComponent<Boid>();
            //Randomize  properties of each boid within range
            boidComponent.speedMax = Random.Range(1f, 3f);
            boidComponent.accelMax = Random.Range(1f, 5f);

            boids.Add(boidComponent); //add the new object to the list so we can use later

            Vector3 accel = boids[i].Seek(targetObject.transform.position, boids[i].accelMax);
            boids[i].rigidBody.linearVelocity += accel * Time.fixedDeltaTime; //apply the acceleration
            Debug.DrawRay(boids[i].transform.position, accel, Color.green);//draw acceleration
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            controlMode = ControlMode.seek;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            controlMode = ControlMode.pursue;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            controlMode = ControlMode.food;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            controlMode = ControlMode.obstacle;
        }
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        bool didHit = Physics.Raycast(ray, out hitInfo, 100);

        if (didHit)
        {
            targetObject.transform.position = hitInfo.point; //move the target to the mouse position
        }
    }


}
