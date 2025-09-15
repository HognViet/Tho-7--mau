using UnityEngine;

public class ScaleTest : MonoBehaviour
{

    private int index = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (index > this.transform.parent.childCount - 1)
        {
            index = this.transform.parent.childCount - 1;
        }
        if ( index < 0 )
        {
            index = 0;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            index++;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            index--;
        }
        this.transform.SetSiblingIndex(index);
    }
}