using UnityEngine;
using UnityEngine.UIElements;

public class Boid : MonoBehaviour
{
    
    public Rigidbody rigidBody;
    public float speedMax = 2;
    public float accelMax = 3;

    private void Start()
    {
     
       rigidBody = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        GetComponent<Renderer>().material.SetColor("_BaseColor", Random.ColorHSV(0, 1, 0.5f, 1, 0.5f, 1));
    }

    private void Update()
    {
      Debug.DrawRay(transform.position, rigidBody.linearVelocity, Color.red);

    }
    private void FixedUpdate()
    {
        //oeiwnt toward velocity
        transform.forward = rigidBody.linearVelocity;

        float speed = rigidBody.linearVelocity.magnitude;

        if (speed > speedMax)
        {
            //enforce  a top speed
            rigidBody.linearVelocity = rigidBody.linearVelocity.normalized * speedMax / speed;
        }
    }
    public Vector3 Seek(Vector3 target, float acceleration)
    {
        //get  displacement vector to target
        Vector3 toTarget  = target  - transform.position;

        //Normalize ti get the direction to the target
        Vector3 toTargetNormalized = toTarget.normalized;

        //ddetermine the acceleration  with given magnitude
        Vector3 accel = toTargetNormalized * acceleration;

        return accel;

    }





}
