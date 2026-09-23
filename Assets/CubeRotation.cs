using UnityEditor;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private int cubeCount;
    [SerializeField] private float radius;
    [SerializeField] private bool isAround;

    void Awake()
    {
        if (cube == null)
        {
            Debug.LogError("No cube prefab");
            return;
        }
        if (isAround)
        {
            var angle = (Mathf.PI * 2) / (cubeCount);
            var currAngle = 0f;
            for (int i = 0; i < cubeCount; i++)
            {
                var x = radius * Mathf.Cos(currAngle);
                var z = radius * Mathf.Sin(currAngle);
                currAngle += angle;

                var newCube = Instantiate(cube);
                newCube.transform.SetParent(transform);
                newCube.transform.localPosition = new Vector3(x, 0, z);

            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
