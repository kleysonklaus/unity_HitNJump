using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour
{
    public static Pop obj;
    // Start is called before the first frame update

    private void Awake()
    {
        obj = this;
    }

    void Start()
    {
        // no se usara
    }

    // Update is called once per frame
    void Update()
    {
        // no se usara
    }

    public void show(Vector3 pos)
    {
        transform.position = pos;
        gameObject.SetActive(true);
    }

    public void dissapear()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        obj = null;
    }

}
