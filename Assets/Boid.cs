using UnityEngine;
using UnityEngine.UIElements;

public class Boid : MonoBehaviour
{
    public Rigidbody rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.linearVelocity = Random.insideUnitSphere;
    }
    public void Update()
    {
        AlignToVelocity();
    }
    public void AlignToVelocity()
    {
    //transform.forward = new Vector3.RotateTowards(transform.forward, rigidbody.linearVelocity.normalized, Mathf.Deg2Rad * 1800 *  Time.deltaTime * 100);
    }
}
