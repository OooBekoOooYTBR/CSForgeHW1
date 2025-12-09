using UnityEngine;
using UnityEngine.UI;

public class ColorChangeBlock : MonoBehaviour
{
    [SerializeField]
    private GameObject block;
    private Renderer blockRenderer;
    private Color RanColor;
    private float randomChannelOne, randomChannelTwo, randomChannelThree;
    void Start()
    {
        blockRenderer = block.GetComponent<Renderer>();
    }

    public void ChangeColor()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            randomChannelOne = Random.Range(0f, 1f);
            randomChannelTwo = Random.Range(0f, 1f);
            randomChannelThree = Random.Range(0f, 1f);
            RanColor = new Color(randomChannelOne, randomChannelTwo, randomChannelThree,1f);
            blockRenderer.material.color = RanColor;
        }
    }
    void Update()
    {

    }
}
