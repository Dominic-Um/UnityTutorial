using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public CheckpointController next;
    public MeshRenderer left;
    public MeshRenderer right;

    private void OnTriggerEnter(Collider other)
    {
        VehicleController vehicle = other.gameObject.GetComponent<VehicleController>();
        Debug.Log("Hit checkpoint. Vehicle found: " + (vehicle != null) + " | Is target: " + (vehicle != null && vehicle.target == this));

        if (vehicle != null)
        {
            if (vehicle.target == this)
            {
                vehicle.target = next;

                next.left.materials[0].color = Color.red;
                next.right.materials[0].color = Color.red;
                left.materials[0].color = Color.white;
                right.materials[0].color = Color.white;
            }
        }
    }
}