using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam02 : MonoBehaviour
{
    public float speed;
    public float zRange = 10;
    public GameObject projectilePrefab;

    private float verticalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = moveAction.ReadValue<Vector2>().y;
        transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.left);

        if (transform.position.y < -zRange)
        {
            transform.position = new Vector3(transform.position.x, -zRange , transform.position.z);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, zRange , transform.position.z);
        }

        // [12] check if the player is shooting
        if (shootAction.triggered)
        {
            
            Quaternion bulletRotation = Quaternion.Euler(0, 90, 0);
            Instantiate(projectilePrefab, transform.position, bulletRotation);
        }
    }
}
