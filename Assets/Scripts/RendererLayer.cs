using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RendererLayer : MonoBehaviour
{
     private Renderer renderer;
     public string sortingLayer;
     public int sortingOrder;
     
     // Use this for initialization
     void Start () {
         if (renderer == null) {
             renderer = this.GetComponent<Renderer>();
         }
             
         SetLayer();
     }
 
 
     public void SetLayer() {
         if (renderer == null) {
             renderer = this.GetComponent<Renderer>();
         }
             
         renderer.sortingLayerName = sortingLayer;
         renderer.sortingOrder = sortingOrder;
        
     }
}
