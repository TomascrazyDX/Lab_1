using System.Runtime.CompilerServices;
using UnityEngine;

public class BoidSimulationControl : MonoBehaviour
{
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
    public int GameObject boidPrefab = null;

    public int numBoidsToSpawn = 10;



    private void Start()
    {
        Vector3 position = new Vector3(Random.Range(-1.4f, 01.4f ),  Random.Range(-0f, 1.4f), Random.Range(-0.9f, 0.9f));
        Instantiate(boidPrefab, position, rotation);
    }

    public int controlModeInt = 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            controlMode = ControlMode.seek;
            controlModeInt = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            controlMode = ControlMode.pursue;
            controlModeInt = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            controlMode = ControlMode.food;
            controlModeInt = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            controlMode = ControlMode.obstacle;
            controlModeInt = 3;
        }
    }

}
