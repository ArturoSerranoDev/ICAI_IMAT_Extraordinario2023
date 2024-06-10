using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Results : MonoBehaviour
{
    [SerializeField] List<TextMeshPro> textResults;
    
    public List<TextMeshPro> GetTextResults()
    {
        return textResults;
    }
}
