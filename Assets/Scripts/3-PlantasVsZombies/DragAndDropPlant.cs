using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropPlant : MonoBehaviour//, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject plantToUse;

    public void MousePressed()
    {
        Instantiate(plantToUse);
        Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        plantToUse.transform.position = Camera.main.ScreenToWorldPoint(currentScreenSpace);
    }

    //----------------DRAG-AND-DROP-----------------

    public void OnMouseDown()
    {
        Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(currentScreenSpace);
        //gameObject.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.x);
    }

    public void OnMouseDrag()
    {
        Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(currentScreenSpace);
    }

    public void OnMouseUp()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

}
