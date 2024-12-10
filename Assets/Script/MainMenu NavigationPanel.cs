using System.Collections.Generic;
using UnityEngine;

public class MainMenuNavigationPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] Panels;
    
    private Dictionary<string, GameObject> PanelsDictionary = new Dictionary<string, GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialise();
        OpenPanel("Menu Panel");
    }

    void Initialise()
    {
        foreach (var panel in Panels)
        {
            PanelsDictionary[panel.name] = panel;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenAccount()
    {
        OpenPanel("Account Panel");

    }

    public void CloseAccount()
    {
        OpenPanel("Menu Panel");
    }

    private void OpenPanel(string panelName)
    {
        // iterate through every panel
       foreach(var panel in PanelsDictionary)
       {
            if(panel.Key == panelName)
            {
                panel.Value.SetActive(true);
            }
            else
            {
                panel.Value.SetActive(false);
            }

       }

    }

}
