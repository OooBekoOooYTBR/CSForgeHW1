using UnityEngine;
using TMPro;

public class RayCast : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DoorTxt;
    [SerializeField] private TextMeshProUGUI InteractTxt;
    [SerializeField] private Transform lookPoint;
    [SerializeField] private LayerMask hitLayer;
    [SerializeField] private LayerMask blockLM;
    private RaycastHit hit;

    private ColorChangeBlock currentColorBlock;
    private DoorSm currentDoor;

    void Update()
    {
        currentColorBlock = null;
        currentDoor = null;
        if (InteractTxt != null) InteractTxt.gameObject.SetActive(false);

        int combinedMask = hitLayer | blockLM;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f, combinedMask))
        {
            GameObject hitObj = hit.collider.gameObject;

            if ((blockLM.value & (1 << hitObj.layer)) != 0)
            {
                if (hitObj.TryGetComponent<ColorChangeBlock>(out ColorChangeBlock colorBlock))
                {
                    colorBlock.ChangeColor(); 
                    if (InteractTxt != null)
                    {
                        InteractTxt.text = "Renk değiştirmek için E'ye basın";
                        InteractTxt.gameObject.SetActive(true);
                    }
                }
                return;
            }

            if (hit.collider.TryGetComponent<DoorSm>(out DoorSm door))
            {
                currentDoor = door;
                if (InteractTxt != null)
                {
                    InteractTxt.text = door.IsOpen ? "Kapıyı kapatmak için E'ye basın" : "Kapıyı açmak için E'ye basın";
                    InteractTxt.gameObject.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (currentDoor.IsOpen) currentDoor.Close();
                    else currentDoor.Open(lookPoint.position);

                    if (DoorTxt != null)
                    {
                        DoorTxt.text = currentDoor.IsOpen ? "Door Opened" : "Door Closed";
                        DoorTxt.gameObject.SetActive(true);
                        DoorTxt.transform.position = hit.point - (hit.point - lookPoint.position).normalized * 0.02f;
                        DoorTxt.transform.rotation = Quaternion.LookRotation((hit.point - lookPoint.position).normalized);
                    }
                }
            }
        }
    }
}
