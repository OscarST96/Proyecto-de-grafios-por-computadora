using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Camera UICamera;
    [SerializeField] private GameObject PanelMenu;
    void Start()
    {
        PanelMenu.SetActive(true);
        UICamera.depth = 2;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            DesactiveMenu(0);
        }    
    }
    public void DesactiveMenu(int priority)
    {
        if(UICamera == null)
            return;

        UICamera.depth = priority;
        PanelMenu.SetActive(false);
    }
}
