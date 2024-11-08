using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    void Update() {
        transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
    }
}
