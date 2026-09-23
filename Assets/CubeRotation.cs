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

    private GameObject[] cubesArray;
    void Awake()
    {
        if (cube == null)
        {
            Debug.LogError("No cube prefab");
            return;
        }
        cubesArray=new GameObject[cubeCount];
        for (int i = 0; i < cubeCount; i++) 
        {
            cubesArray[i] = Instantiate(cube);
        }
        SetCubes();
    }

    private void SetCubes()
    {
        var angle = 0f;
        if (isAround)
            angle = (Mathf.PI * 2f) / cubeCount;
        else
            angle = angleStep;

        for (int i = 0; i < cubeCount; i++)
        {
            var x = radius * Mathf.Cos(angle * i);
            var z = radius * Mathf.Sin(angle * i);

            cubesArray[i].transform.SetParent(transform);
            cubesArray[i].transform.localPosition = new Vector3(x, 0, z);
            cubesArray[i].transform.LookAt(transform);
        }
    }


    private float prevRadius;
    private bool prevIsAround;
    private float prevAngleStep;
    void Update()
    {
        if (isClockwise)
            transform.Rotate(new Vector3(0, rotationSpeed, 0));
        else
            transform.Rotate(new Vector3(0, -rotationSpeed, 0));
        if (radius != prevRadius || isAround != prevIsAround || angleStep != prevAngleStep )
            SetCubes();
        prevRadius = radius;
        prevIsAround = isAround;
        prevAngleStep = angleStep;
    }
}
