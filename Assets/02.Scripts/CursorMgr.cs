using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursurMgr : MonoBehaviour
{
    public Texture2D DeafaultCursor;
    public Texture2D OnEnemyCursor;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnMouseOver()
    {
        Cursor.SetCursor(OnEnemyCursor, new Vector2(0, 0), CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(DeafaultCursor, new Vector2(0, 0), CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
