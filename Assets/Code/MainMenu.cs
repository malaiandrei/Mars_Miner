using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {
    
	// Use this for initialization
	void Start () {


        CreateMenuButtons("MainMenu");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void MenuPlayButton()
    {
        Debug.Log("Button Play");
    }
    public void MenuExitButton()
    {
        Debug.Log("Button exit");
    }
    public void CreateMenuButtons(string canvasTxt)
    {
        //Canvas
        GameObject canvasGO = new GameObject();
        canvasGO.name = canvasTxt;
        RectTransform canvasRT = canvasGO.AddComponent<RectTransform>();
        Canvas canvasCV = canvasGO.AddComponent<Canvas>();
        canvasCV.renderMode = RenderMode.ScreenSpaceCamera;
        Vector3 pos = Camera.main.transform.position;
        pos += Camera.main.transform.forward * 10.0f;
        canvasCV.worldCamera = Camera.main;
        GraphicRaycaster canvasGR = canvasGO.AddComponent<GraphicRaycaster>();
        CanvasScaler canvasCS = canvasGO.AddComponent<CanvasScaler>();
        Vector3 positionPlayButton = new Vector3(0.0f, 100.0f,0.0f);
        Vector3 positionExitButton = new Vector3(0.0f, 0.0f,0.0f);

        CreateButton("PlayButton", "PlayText", "Play", canvasRT, MenuPlayButton, positionPlayButton);
        CreateButton("ExitButton", "ExitText", "Exit", canvasRT, MenuExitButton, positionExitButton);

    }
    public void CreateButton(string buttonTxt, string textTxt,string nameTxt,RectTransform canvasRT,UnityEngine.Events.UnityAction ButtonEvent,Vector3 vectorPosition)
    {
        //Play Button

        GameObject buttonGO = new GameObject();
        buttonGO.name = buttonTxt;

        RectTransform buttonRT = buttonGO.AddComponent<RectTransform>();
        buttonRT.SetParent(canvasRT);
        buttonRT.sizeDelta = new Vector2(200.0f, 50.0f);
        buttonRT.localScale = new Vector3(1.0f, 1.0f, 0.0f);
        buttonRT.transform.localPosition = vectorPosition;

        ColorBlock colorBlock = buttonGO.AddComponent<Button>().colors;
        colorBlock.normalColor = Color.red;
        colorBlock.pressedColor = Color.black;
        colorBlock.highlightedColor = Color.green;
        buttonGO.GetComponent<Button>().colors = colorBlock;

        Image buttonIM = buttonGO.AddComponent<Image>();
        buttonIM.sprite = Resources.Load("buttonSprite", typeof(Sprite)) as Sprite;

        Button buttonBU = buttonGO.GetComponent<Button>();
        buttonBU.onClick.AddListener(ButtonEvent);
        buttonBU.targetGraphic = buttonIM;

        //text button
        GameObject textButton = new GameObject();
        textButton.name = textTxt;
        RectTransform textRT = textButton.AddComponent<RectTransform>();
        textRT.SetParent(buttonRT);
        textRT.sizeDelta = new Vector2(0.0f, 0.0f);
        textRT.localScale = new Vector3(1.0f, 1.0f);
        textRT.anchorMin = new Vector2(0.0f, 0.0f);
        textRT.anchorMax = new Vector2(1.0f, 1.0f);
        textRT.pivot = new Vector2(0.5f, 0.5f);
        textRT.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        textRT.offsetMin = new Vector2(0.0f, 0.0f);
        textRT.offsetMax = new Vector2(0.0f, 0.0f);
        Text textPlay = textButton.AddComponent<Text>();
        textPlay.text = nameTxt;
        textPlay.color = Color.blue;
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        textPlay.font = ArialFont;
        textPlay.alignByGeometry = true;
        textPlay.alignment = TextAnchor.MiddleCenter;
    }
}
