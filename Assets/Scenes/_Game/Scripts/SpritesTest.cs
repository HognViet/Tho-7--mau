using UnityEngine;

public class SpritesTest : MonoBehaviour
{
    private int index = 0;
    private Vector3 kc = new Vector3(2.5f, 0, 0);
    private Vector3 _kc = new Vector3(2.5f, 0, 0);
    private Color color = new Color(1, 1, 1,0.8f);
    private Color _color = new Color(1, 1,1, 0.2f);
    private Vector3 scale = new Vector3(1, 1, 0);
    private float khoangCach_scale = 0f;
    private float khoangCach_coban = 1.5f;
    private SpriteRenderer[] childRenderers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int count = this.transform.childCount;
        childRenderers = new SpriteRenderer[count]; 

        for (int i = 0; i < count; i++)
        {
            childRenderers[i] = this.transform.GetChild(i).GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.transform.childCount);
        if (index > this.transform.childCount - 1)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
                this.transform.GetChild(index).localScale += scale;
                if (index > 0)
                {
                    this.transform.GetChild(index).localScale = this.transform.GetChild(index - 1).localScale + scale;
                }
            

                for (int i = 0; i <= index; i++)
                {
                    khoangCach_scale += khoangCach_coban + this.transform.GetChild(i).localScale.x;
                }
                this.transform.GetChild(index).localPosition = new Vector3(khoangCach_scale, 0, 0);
                //kc += _kc;
                childRenderers[index].color = color;
                color -= _color;
                //Debug.Log(childRenderers[index].color);

                index++;
            
        }
    }
}
