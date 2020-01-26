using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitOneSecond());
        //WaitSecond();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Wating For 2 Second");
    }

    /*
    public void WaitSecond()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Wating For 2 Second");
    }
    */
}
