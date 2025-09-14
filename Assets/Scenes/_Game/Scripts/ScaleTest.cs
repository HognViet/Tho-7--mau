using UnityEngine;

public class ScaleTest : MonoBehaviour
{
    [SerializeField] private Transform parentTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            this.transform.SetParent(parentTransform);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.transform.SetParent(null);
            this.transform.localScale = parentTransform.transform.localScale;
        }
        
    }
}