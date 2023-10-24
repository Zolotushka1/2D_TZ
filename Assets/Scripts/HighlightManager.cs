using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _objToHighlight;
    [SerializeField] private Material _material;
    private int _materialIndex=0;
    private bool _defaultMaterial=true;
    public GameObject HelpWindowUI;
    private void Start() 
    {
        MaterialSwitch();
    }
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E) )    
        {
            _defaultMaterial=!_defaultMaterial;
            MaterialSwitch();
        }
    }

    private void MaterialSwitch()
    {
        
        if (_defaultMaterial==true)
            {
                HelpWindowUI.SetActive(false);
                _materialIndex=0;
            }
            else 
            {
                HelpWindowUI.SetActive(true);
                _materialIndex=1;
            }
            foreach(GameObject ob in _objToHighlight)
            {
                ob.GetComponent<Renderer>().material = ob.GetComponent<ItemToHL>().BaseMaterial[_materialIndex];
            }    

    }
}
