using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;

    buildManager buildManager;


    private GameObject turret;
    private Renderer rend;
    private Color startColor;
    public Vector3 buildOffset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = buildManager.instance;
    }

    private void OnMouseDown()
    {
        // exit if over a UI element
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;


        if(turret != null)
        {
            //TODO: Display on screen
            Debug.Log("Can't build here");
            return;
        }

        //Build a turret
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + buildOffset, transform.rotation);
        buildManager.SetTurretToBuild(null);
    }

    void OnMouseEnter()
    {
        // exit if over a UI element
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;
        rend.material.color = hoverColor;
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
