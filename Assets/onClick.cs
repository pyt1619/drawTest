using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClick : MonoBehaviour
{
    public SpriteRenderer targetColor;

    public Transform targetParent;

    public GameObject linePrefab;
    LineRenderer tmpLine;

    public int typeDrawing;
    bool mouseFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    int tmpInt;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            mouseFlag = true;
        }

        if(Input.GetMouseButtonUp(0)){
            mouseFlag = false;
            tmpLine = null;
            tmpInt = 0;
        }

        if(mouseFlag){
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null){    
                Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);
                if(typeDrawing == 0){
                    // if(hit.collider.gameObject.name == "Square") return;
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().color = targetColor.color;
                }
                if(typeDrawing == 1){
                    if(tmpLine == null){
                        GameObject tmp = Instantiate(linePrefab, transform.position, transform.rotation);
                        tmp.GetComponent<Transform>().SetParent(targetParent);
                        tmpLine = tmp.GetComponent<LineRenderer>();
                        tmpLine.numCapVertices = 0;
                        tmp.transform.localScale= new Vector3(1,1,1);
                        tmpLine.SetColors(targetColor.color, targetColor.color);
                    }
                    tmpLine.SetVertexCount(tmpInt+1);

                    tmpLine.SetPosition (tmpInt,  Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    // Debug.Log(Input.mousePosition);
                    // hit.collider.gameObject.GetComponent<SpriteRenderer>().color = targetColor.color;
                    tmpInt++;
                }
                if(typeDrawing == 2){
                    if(tmpLine == null){
                        GameObject tmp = Instantiate(linePrefab, transform.position, transform.rotation);
                        tmp.GetComponent<Transform>().SetParent(targetParent);
                        tmpLine = tmp.GetComponent<LineRenderer>();
                        tmpLine.numCapVertices = 0;
                        tmp.transform.localScale= new Vector3(1,1,1);
                        tmpLine.SetColors(Color.white, Color.white);
                    }
                    tmpLine.SetVertexCount(tmpInt+1);

                    tmpLine.SetPosition (tmpInt,  Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    // Debug.Log(Input.mousePosition);
                    // hit.collider.gameObject.GetComponent<SpriteRenderer>().color = targetColor.color;
                    tmpInt++;
                }
            }  

        }
    }

    public void SetTypeDrawing(int type){
        typeDrawing = type;
    }
}
