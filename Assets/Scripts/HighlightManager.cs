using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _objToHighlight;
    [SerializeField] private GameObject[] _objectsToView;
    [SerializeField] private Material _material;
    public GameObject HelpWindowUI;
    private int _materialIndex=0;
    private bool _defaultMaterial=true;

    private void Start() 
    {
        MaterialSwitch();
    }

    public void OnBtnClick()
    {
        _defaultMaterial=!_defaultMaterial;
        MaterialSwitch();
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
        
        foreach(GameObject ob in _objectsToView)
        {
            if (ob.activeSelf == true)
            {
                ob.SetActive(false);
            }
            else
            {
                ob.SetActive(true);
            }
        }
    }
}
