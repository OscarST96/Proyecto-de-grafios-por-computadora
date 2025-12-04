using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Propities")]
    [SerializeField, Min(0.1f)] private float speed = 1;
    [SerializeField, Min(0.1f)] private float sencibilidad = 1;
    [SerializeField] private Transform TFCamera;

    private Rigidbody rb;

    private float keyX;
    private float keyZ;
    private Vector3 mov;
    //Mouse
    private float MouseX;
    private float MouseY;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        keyX = Input.GetAxisRaw("Horizontal");
        keyZ = Input.GetAxisRaw("Vertical");

        Vector3 f = TFCamera.forward;
        Vector3 r = TFCamera.right;

        f.y = 0;
        r.y = 0;

        f.Normalize();
        r.Normalize();

        mov = (f * keyZ + r * keyX).normalized;

        MouseX = Input.GetAxis("Mouse X") * sencibilidad;
        MouseY = Input.GetAxis("Mouse Y") * sencibilidad;

        transform.Rotate(0, MouseX, 0);
        
        TFCamera.Rotate(-MouseY, 0, 0);
    }
    void FixedUpdate()
    {
        Vector3 dir = new Vector3 (mov.x * speed, rb.linearVelocity.y, mov.z * speed);
        rb.linearVelocity = dir;
    }
}
