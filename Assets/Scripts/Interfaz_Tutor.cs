using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interfaz_Tutor : MonoBehaviour {
    public GameObject panelHola;
    public GameObject panel;
    public Button openTutorButton;
    public Button closeTutorButton;
    public Button Next;
    public Button Previous;
    public Button Correct;
    public Button Incorrect;
    public Image UIImage;

    public Text messageText;
    private MessageDataController messageDataController;
    private MessageRoundData currentMessageRoundData;
    private MessageData[] messagePool;
    private bool isRoundedActive;
    private int messageIndex = 0;

    //public List<Sprite> pantallaSprites = new List<Sprite>();
    //public Sprite[] pantallaSprites;
   // int pos=0;


    public void Start () {
        closeTutorButton.onClick.AddListener(CloseTutor);
        openTutorButton.onClick.AddListener(OpenPanel);
       // UIImage = GameObject.Find("ImgNext").GetComponent<Image>();
        closeTutorButton.gameObject.SetActive(false);
        panelHola.gameObject.SetActive(false);
        Next.gameObject.SetActive(false);
        Previous.gameObject.SetActive(false);
        Correct.gameObject.SetActive(false);
        Incorrect.gameObject.SetActive(false);
        UIImage.gameObject.SetActive(false);

        messageDataController = FindObjectOfType<MessageDataController>();
        currentMessageRoundData = messageDataController.GetCurrentMessageRoundData();
        messagePool = currentMessageRoundData.messages;
        //messageIndex = 0;

        isRoundedActive = true;
        ShowMessage();
    }

    private void ShowMessage()
    {

        MessageData messageData = messagePool[messageIndex];
        messageText.text = messageData.messageText;

    }
    private void ViewImage()
    {
        Next.onClick.AddListener(NextImage);
        Previous.onClick.AddListener(PreviousImage);
        Correct.onClick.AddListener(CorrectState);
        Incorrect.onClick.AddListener(IncorrectState);
    }

    public void OpenPanel() {
        openTutorButton.gameObject.SetActive(false);
        closeTutorButton.gameObject.SetActive(true);
        UIImage.gameObject.SetActive(true);
        //Debug.Log(pantallaSprites[pos]);
        panelHola.gameObject.SetActive(true);
        Conditions();
    }

    public void CloseTutor()
    {
        openTutorButton.gameObject.SetActive(true);
        closeTutorButton.gameObject.SetActive(false);
        panelHola.gameObject.SetActive(false);
        Next.gameObject.SetActive(false);
        Previous.gameObject.SetActive(false);
        UIImage.gameObject.SetActive(false);
        Correct.gameObject.SetActive(false);
        Incorrect.gameObject.SetActive(false);
    }

    public void NextImage() {
        messageIndex = messageIndex + 1;
        // pos = pos + 1;
        // Sprite pantallaSprite = pantallaSprites[pos];
        //  UIImage.sprite = pantallaSprite;
        //Debug.Log(pantallaSprites[pos]);
        MessageData messageData = messagePool[messageIndex];
        messageText.text = messageData.messageText;
        Previous.gameObject.SetActive(true);
        
        
       if (messageIndex == messagePool.Length - 1) {
                   Next.gameObject.SetActive(false);
               }
        /*
        if (messageIndex == 2) {
            Next.gameObject.SetActive(false);
            Previous.gameObject.SetActive(false);
            Correct.gameObject.SetActive(true);
            Incorrect.gameObject.SetActive(true);
        }*/
    }

    public void PreviousImage()
    {
        messageIndex = messageIndex - 1;
        MessageData messageData = messagePool[messageIndex];
        messageText.text = messageData.messageText;
        /* pos = pos - 1;
         Sprite pantallaSprite = pantallaSprites[pos];
         UIImage.sprite = pantallaSprite;
         Debug.Log(pantallaSprites[pos]);*/
         Next.gameObject.SetActive(true);
         Conditions();
    }

   public void CorrectState() {
        NextImage();
        Next.gameObject.SetActive(false);
        Previous.gameObject.SetActive(false);
        Correct.gameObject.SetActive(false);
        Incorrect.gameObject.SetActive(false);
        closeTutorButton.onClick.AddListener(Reset);

        
    }

    public void IncorrectState(){
        messageIndex = messageIndex + 1;
        NextImage();
        Next.gameObject.SetActive(true);
        Previous.gameObject.SetActive(false);
        Correct.gameObject.SetActive(false);
        Incorrect.gameObject.SetActive(false);
    }

    private void Reset()
    {
        messageIndex = 0;
        MessageData messageData = messagePool[messageIndex];
        messageText.text = messageData.messageText;
        //Sprite pantallaSprite = pantallaSprites[pos];
        //UIImage.sprite = pantallaSprite;
    }

    private void state(MessageData m)
    {
        bool states = m.sendGoodStateButton();

        if (states == true)
        {
            Next.gameObject.SetActive(false);
            Previous.gameObject.SetActive(false);
            Correct.gameObject.SetActive(true);
            Incorrect.gameObject.SetActive(true);
            Debug.Log("el estado es true");
        }
    }

    private void Conditions()
    {
        if (messageIndex == 0 /*|| messageIndex == 4*/)
        {

            Next.gameObject.SetActive(true);
            Previous.gameObject.SetActive(false);
            Correct.gameObject.SetActive(false);
            Incorrect.gameObject.SetActive(false);
        }
        /*
        else
        {
            if (messageIndex == 2)
            {
                Next.gameObject.SetActive(false);
                Previous.gameObject.SetActive(false);
                Correct.gameObject.SetActive(true);
                Incorrect.gameObject.SetActive(true);
            }
            else
            {
                Next.gameObject.SetActive(true);
                Previous.gameObject.SetActive(true);
                Correct.gameObject.SetActive(false);
                Incorrect.gameObject.SetActive(false);
            }
        }*/
    }
}
