using UnityEngine;

public class Pinchos : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float delay = 2f;
    [SerializeField] private float moveHeight = 0.5f;

    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingUp = true;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + new Vector3(0, moveHeight, 0); // Sube los pinchos un poco
        InvokeRepeating("ToggleMovement", delay, delay);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, movingUp ? endPos : startPos, Time.deltaTime * speed);
    }

    void ToggleMovement()
    {
        movingUp = !movingUp;
    }
}
