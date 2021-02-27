using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    [SerializeField] Canvas oldCanvas;
    [SerializeField] Canvas newCanvas;
    [SerializeField] int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void switchCanvas()
    {
        newCanvas.enabled = true;
        oldCanvas.enabled = false;
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void switchScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
