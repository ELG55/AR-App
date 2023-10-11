using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARUIManager : MonoBehaviour
{
    public GameObject arCanvas;
    public GameObject arModelCanvas;
    public GameObject modelLocation;
    public Inventory inventory;
    private GameObject currentModelInstance = null;
    private bool showingARModelCanvas = false;
    public float arModelCanvasVerticalSeparation = 0.15f;

    public List<GameObject> canvasButtonList;

    public void ARCanvasButton(int buttonNumber)
    {
        if (buttonNumber < inventory.inventoryItems.Count)
        {
            if (inventory.inventoryItems[buttonNumber] != null)
            {
                //Spawn model
                currentModelInstance = Instantiate(inventory.inventoryItems[buttonNumber].prefab, modelLocation.transform);
                //Add control scripts
                currentModelInstance.AddComponent<Scaling>();
                currentModelInstance.AddComponent<Rotation>();
                //Set scale, position and rotation
                currentModelInstance.transform.localScale = inventory.inventoryItems[buttonNumber].defaultScale;
                currentModelInstance.transform.localPosition = modelLocation.transform.localPosition;

                Vector3 rotation = new Vector3((modelLocation.transform.localRotation.eulerAngles.x + inventory.inventoryItems[buttonNumber].defaultRotation.x),
                    (modelLocation.transform.localRotation.eulerAngles.y + inventory.inventoryItems[buttonNumber].defaultRotation.y),
                    (modelLocation.transform.localRotation.eulerAngles.z + inventory.inventoryItems[buttonNumber].defaultRotation.z));
                currentModelInstance.transform.localRotation = Quaternion.Euler(rotation);

                //Set mesh collider to be convex (this avoids holes in the mesh, which conflict with touch controls)
                currentModelInstance.GetComponent<MeshCollider>().convex = true;

                //Hide inventory canvas and show inventory button canvas
                arCanvas.SetActive(false);
                arModelCanvas.SetActive(true);
                showingARModelCanvas = true;
            }
        }
    }

    public void ARModelCanvasButton()
    {
        Destroy(currentModelInstance);
        arModelCanvas.SetActive(false);
        arCanvas.SetActive(true);
        showingARModelCanvas = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (showingARModelCanvas && (currentModelInstance != null))
        {
            Vector3 newARModelCanvasPosition = new Vector3(arModelCanvas.transform.localPosition.x, currentModelInstance.GetComponent<Renderer>().bounds.size.y + arModelCanvasVerticalSeparation, arModelCanvas.transform.localPosition.z);
            arModelCanvas.transform.localPosition = newARModelCanvasPosition;
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < canvasButtonList.Count; i++)
        {
            if (i < inventory.inventoryItems.Count)
            {
                //Spawn a smaller version of a model in the button's position
                GameObject miniModelInstance = Instantiate(inventory.inventoryItems[i].prefab, canvasButtonList[i].transform);

                //Set scale, position and rotation
                miniModelInstance.transform.localScale = inventory.inventoryItems[i].inventoryViewScale;
                float offestY = -100f;
                Vector3 miniModelNewPosition = new Vector3(miniModelInstance.transform.localPosition.x, miniModelInstance.transform.localPosition.y + offestY, miniModelInstance.transform.localPosition.z);
                miniModelInstance.transform.localPosition = miniModelNewPosition;

                Vector3 rotation = new Vector3((canvasButtonList[i].transform.localRotation.eulerAngles.x + inventory.inventoryItems[i].defaultRotation.x),
                    (canvasButtonList[i].transform.localRotation.eulerAngles.y + inventory.inventoryItems[i].defaultRotation.y),
                    (canvasButtonList[i].transform.localRotation.eulerAngles.z + inventory.inventoryItems[i].defaultRotation.z));
                miniModelInstance.transform.localRotation = Quaternion.Euler(rotation);

                //Set the name of the item currently loading in the text object of the button (child of child)
                canvasButtonList[i].transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = inventory.inventoryItems[i].itemName;
            }
        }
    }
}
