using UnityEditor;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private int cubeCount;
    [SerializeField] private float radius;
    [SerializeField] private bool isAround;
    [SerializeField] private float angleStep;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool isClockwise;

    void Awake()
    {
        if (cube == null)
        {
            Debug.LogError("No cube prefab");
            return;
        }
        var angle = 0f;
        if (isAround)
            angle = (Mathf.PI * 2f) / cubeCount;
        else
            angle = angleStep;

        for (int i = 0; i < cubeCount; i++)
        {
            var x = radius * Mathf.Cos(angle * i);
            var z = radius * Mathf.Sin(angle * i);

            var newCube = Instantiate(cube);
            newCube.transform.SetParent(transform);
            newCube.transform.position = new Vector3(x, 0, z);
            newCube.transform.LookAt(transform);

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isClockwise)
            transform.Rotate(new Vector3(0, rotationSpeed, 0));
        else
            transform.Rotate(new Vector3(0, -rotationSpeed, 0));
    }
}
