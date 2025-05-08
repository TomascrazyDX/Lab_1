using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BoidSimulationControl : MonoBehaviour
{
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
        Vector3 position = new Vector3(Random.Range(-1.4f, 1.4f), Random.Range(0f, 1.4f), Random.Range(-0.9f, 0.9f));
        Quaternion rotation = Random.rotation;

        for (int i = 0; i <= BoidsToSpawn; i++)
        {
            GameObject newBoid = Instantiate(boidPrefab, new Vector3(Random.Range(-0.7f, 0.7f), Random.Range(0, 0.7f), Random.Range(-0.4f, 0.4f)), Random.rotation);
            boids.Add(newBoid.GetComponent<Boid>());
        }

        //spawn the boids
        GameObject spawnedBoid = Instantiate(boidPrefab, position, rotation);

        spawnedBoid.transform.localScale *= Random.Range(0.9f, 3f);
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
    private void Awake()
    {
        //GetComponent<Renderer>().material.SetColor("_BaseColor", Random.ColorHSV(0, 1, 0.5f, 1, 0.5f, 1));
    }
}
