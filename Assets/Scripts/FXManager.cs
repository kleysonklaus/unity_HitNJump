using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static FXManager obj;
    public GameObject pop;
    // Start is called before the first frame update

    private void Awake()
    {
        obj = this;
    }

    public void showPop(Vector3 pos)
    {
        pop.gameObject.GetComponent<Pop>().show(pos);
    }

    private void OnDestroy()
    {
        obj = null;
    }
    void Start()
    {
        // no se usa
    }

    // Update is called once per frame
    void Update()
    {
        // no se usa
    }
}
