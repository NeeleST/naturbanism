
/*
 * 
 */

// IMPORT ASSETS AND LIBRARIES
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// CREATE PUBLIC CLASS
public class RaycastBuildingSystem : MonoBehaviour
{
    // CREATE VARIABLES // PUBLIC VARIABLES CAN BE CONTROLLED FROM THE INSPECTOR PANEL OF UNITY EDITOR
    public Transform ObjToMove;
    public GameObject[] ObjToPlace;
    public int ObjToPlaceIndex;
    public LayerMask mask;
    int LastPosX,LastPosY,LastPosZ;
    Vector3 mousePos;

    // GRID SIZE AND GRID SNAP
    public int gridSize;

    // START FUNCTION RUNS ONLY AT THE BEGINNING OF THE GAME
    void Start () {
    }

    // UPDATE FUNCTION IS CALLED ONCE PER FRAME
    void Update ()
    {
        mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if(EventSystem.current.IsPointerOverGameObject())
            return;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            int PosX = (int)Mathf.Round(hit.point.x);
            int PosY = (int)Mathf.Round(hit.point.y);
            int PosZ = (int)Mathf.Round(hit.point.z);

            if(PosX != LastPosX || PosY != LastPosY || PosZ != LastPosZ)
            {
                LastPosX = (PosX / gridSize) * gridSize;
                LastPosY = PosY;
                LastPosZ = (PosZ / gridSize) * gridSize;
                
                ObjToMove.position = new Vector3(LastPosX,LastPosY+.5f,LastPosZ);
                                //Debug.Log("X: " + LastPosX + " & Z: " + LastPosZ);
            }

            // WHEN LEFT MOUSE BUTTON CLICKED = INSTANTIATE OBJECT AND PLACE ON POSITION OF MOUSE CURSOR
            if(Input.GetMouseButtonDown(0))
            {
                Instantiate(ObjToPlace[ObjToPlaceIndex], ObjToMove.position, Quaternion.identity);
            }
        }
    }



// DRAW GRID OF SPHERES

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / gridSize);
        int yCount = Mathf.RoundToInt(position.y / gridSize);
        int zCount = Mathf.RoundToInt(position.z / gridSize);

        Vector3 result = new Vector3(
            (float)xCount * gridSize,
            (float)yCount * gridSize,
            (float)zCount * gridSize);

        result += transform.position;

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        for (float x = 0; x < 1000; x += gridSize)
        {
            for (float z = 0; z < 1000; z += gridSize)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, 0.5f);
            }
                
        }
    }

// CREATE A BUTTON FOR EVERY OBJECT AND SET THE INDEX NUMBER OF THE OBJECT. 1st OBJECT = 0; 2nd Object = 1; 3rd Object = 2 // 


    // WHEN BUTTON IS CLICKED
    public void SetE1 (){   
        ObjToPlaceIndex = 0;
    }

    public void SetE2 (){   
        ObjToPlaceIndex = 1;
    }

    public void SetE3 (){   
        ObjToPlaceIndex = 2;
    }

    public void SetE4 (){
        ObjToPlaceIndex = 3;
    }

    public void SetE5 (){
        ObjToPlaceIndex = 4;
    }

    public void SetE6 (){
        ObjToPlaceIndex = 5;
    }

    public void SetE7 (){
        ObjToPlaceIndex = 6;
    }

    public void SetE8 (){
        ObjToPlaceIndex = 7;
    }
    public void SetE9 (){
        ObjToPlaceIndex = 8;
    }
}