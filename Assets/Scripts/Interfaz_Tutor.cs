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
    public Image ExitPanel;

    public Text messageText;
    private MessageDataController messageDataController;
    private MessageRoundData currentMessageRoundData;
    private MessageData Datas;
    public MessageData[] messagePool;

    private bool isRoundedActive;
    public int messageIndex = 0;
    private int nextRound = 0;

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
        ExitPanel.gameObject.SetActive(false);

        messageDataController = FindObjectOfType<MessageDataController>();
        currentMessageRoundData = messageDataController.GetCurrentMessageRoundData(0);
        messagePool = currentMessageRoundData.messages;
       
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
        ExitPanel.gameObject.SetActive(false);
    }

    public void NextImage()
    {
       
      if (messageIndex != messagePool.Length - 1)
        {
            messageIndex = messageIndex + 1;
            int n = messagePool.Length;
            Debug.Log("mi piscina es de posiciones " + n);
            Debug.Log("estoy en la posicion" + messageIndex);
            if ((messagePool[messageIndex].GoodStateButton == true) && (messagePool[messageIndex].ExitButton == true))
                    {
                       

                        bool good = messagePool[messageIndex].GoodStateButton;
                        bool bad = messagePool[messageIndex].ExitButton;
                        string men = messagePool[messageIndex].messageText;

                        Debug.Log("el estado bueno es " + good + " el estado malo es " + bad + " y el mensaje es :" + men);

                        MessageData messageData = messagePool[messageIndex];

                        messageText.text = messageData.messageText;
                        Correct.gameObject.SetActive(true);
                        Incorrect.gameObject.SetActive(true);
                        Next.gameObject.SetActive(false);
                        Previous.gameObject.SetActive(false);
                        Debug.Log(messageIndex + "mensaje index");
                        Debug.Log("estoy en el primer else");
                        CorrectState();
                    }
                   else if ((messagePool[messageIndex].GoodStateButton == false) && (messagePool[messageIndex].ExitButton == false))
                        {
                            
                            //Debug.Log("el estado bueno es " + good + " el estado malo es " + bad + " y el mensaje es :" + men);
                            MessageData messageData = messagePool[messageIndex];
                            messageText.text = messageData.messageText;
                            Previous.gameObject.SetActive(true);
                            Debug.Log(messageIndex + "mensaje index");
                            Debug.Log("estoy en el segundo else");
                        }
            }
        else
            {
               // NextRound();
            }
       
    }
    /*
    else if (messageIndex == messagePool.Length - 1)

    if (messageIndex == 2) {
        Next.gameObject.SetActive(false);
        Previous.gameObject.SetActive(false);
        Correct.gameObject.SetActive(true);
        Incorrect.gameObject.SetActive(true);
    }*/


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
            //CorrectState();
        }

   public void CorrectState()
 
        {         
          
           
            closeTutorButton.onClick.AddListener(NextRound);
            Correct.onClick.AddListener(Exit);
            Incorrect.onClick.AddListener(IncorrectState);
        } 
        

    public void IncorrectState()
        {
        //------------- SI ESTA EN LA ULTIMA POS, NEXT ROUND..
        if (messageIndex == messagePool.Length - 1)
            {
                messageIndex = 0;
            }
        else
            {
            // messageIndex = messageIndex + 1;
            
            NextRound();
            Next.gameObject.SetActive(true);
                Previous.gameObject.SetActive(false);
                Correct.gameObject.SetActive(false);
                Incorrect.gameObject.SetActive(false);
            }
        }

    public void Exit()
        {
            Next.gameObject.SetActive(false);
            Previous.gameObject.SetActive(false);
            Correct.gameObject.SetActive(false);
            Incorrect.gameObject.SetActive(false);
            closeTutorButton.onClick.AddListener(NextRound);
            ExitPanel.gameObject.SetActive(true);
        }

    private void NextRound()
        {


            messageIndex = 0;
            nextRound = nextRound + 1;
            currentMessageRoundData = messageDataController.GetCurrentMessageRoundData(nextRound); //get position n
            messagePool = currentMessageRoundData.messages;
           
            MessageData messageData = messagePool[messageIndex];
            messageText.text = messageData.messageText;
            //Sprite pantallaSprite = pantallaSprites[pos];
            //UIImage.sprite = pantallaSprite;
        }


   
    /*
    private void state(MessageData m)
    {
        if (states == true)
        {
            Next.gameObject.SetActive(false);
            Previous.gameObject.SetActive(false);
            Correct.gameObject.SetActive(true);
            Incorrect.gameObject.SetActive(true);
            Debug.Log("el estado es true");
        }
    }*/

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
