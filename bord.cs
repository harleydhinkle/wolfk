using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bord : MonoBehaviour {
    public Transform prefab;
    public Vector3 vec3;
    public Camera camera;
    // Use this for initialization
    void Start() {
        vec3 = new Vector3(9, 0, 9);

        for (int i = 0; i < vec3.x; i++)
        {
            for (int j = 0; j < vec3.z; j++)
            {
                Instantiate(prefab, new Vector3(i, 0, j), Quaternion.identity);
            }
        }
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;
            GetComponent<Chessman>();
        }
    }
    void update()
    { }
}


