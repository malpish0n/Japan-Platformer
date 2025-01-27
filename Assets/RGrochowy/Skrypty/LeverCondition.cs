using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverCondition : MonoBehaviour
{
    int leversActivated, requiredLevers;

    public GameObject doorP;
    private float smooth = 10f;
    private Quaternion target = Quaternion.Euler(0f, -90f, 0f);

    private bool openDoor=false;
    // Start is called before the first frame update
    void Start()
    {
        leversActivated = 0;
        requiredLevers = GameObject.FindGameObjectsWithTag("Lever").Length;
        Debug.Log("Requaired: " + requiredLevers);
    }

    private void Update()
    {
        if (openDoor)
        {
            doorP.transform.rotation = Quaternion.Slerp(doorP.transform.rotation, target, Time.deltaTime * smooth);
        }
    }

    public void LeverActivated()
    {
        leversActivated++;
        Debug.Log("Activated: " + leversActivated);
        if (leversActivated >= requiredLevers)
        {
            Debug.Log("Open");
            openDoor = true;
        }
    }
}
