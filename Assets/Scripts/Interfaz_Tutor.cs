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
    public MessageData[] messagePool;
    public GameData Rounds;
    private bool isRoundedActive;
    public int messageIndex = 0;
    public int nextRound = 0;
    public int LenRounds = 0;

    public void Start () {
        messageIndex = 0;
        nextRound = 0;
        closeTutorButton.onClick.AddListener(CloseTutor);
        openTutorButton.onClick.AddListener(OpenPanel);
        panel.gameObject.SetActive(true);
        closeTutorButton.gameObject.SetActive(false);
        panelHola.gameObject.SetActive(false);
       
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
        Conditions();
        openTutorButton.gameObject.SetActive(false);
        closeTutorButton.gameObject.SetActive(true);
        UIImage.gameObject.SetActive(true);
        panelHola.gameObject.SetActive(true);

        if ((messagePool[messageIndex].GoodStateButton == true) && (messagePool[messageIndex].ExitButton == true))
        {
            Incorrect.gameObject.SetActive(true);
            Correct.gameObject.SetActive(true);
            Next.gameObject.SetActive(false);
            Previous.gameObject.SetActive(false);
        }
        else if (!(Next.gameObject.activeSelf) && !(Previous.gameObject.activeSelf))
        {
            Next.gameObject.SetActive(true);
            Previous.gameObject.SetActive(true);
        }

        //Si incorrecto y correct estan activos. Dejar activo.

        

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
        ExitPanel.gameObject.SetActive(false);
        Incorrect.gameObject.SetActive(false);
        Correct.gameObject.SetActive(false);
       
    }

    public void NextImage()
    {
       
      if (messageIndex != messagePool.Length - 1)
        {
            messageIndex = messageIndex + 1;

            if ((messagePool[messageIndex].GoodStateButton == true) && (messagePool[messageIndex].ExitButton == true))
                    {
                       
                        MessageData messageData = messagePool[messageIndex];

                        messageText.text = messageData.messageText;
                        Correct.gameObject.SetActive(true);
                        Incorrect.gameObject.SetActive(true);
                        Next.gameObject.SetActive(false);
                        Previous.gameObject.SetActive(false);
                        CorrectState();
                    }
                   else if ((messagePool[messageIndex].GoodStateButton == false) && (messagePool[messageIndex].ExitButton == false))
                        {
                            
                            MessageData messageData = messagePool[messageIndex];
                            messageText.text = messageData.messageText;
                            Previous.gameObject.SetActive(true);
                        }
            }
        else
            {
                NextRound();  //Si es el ultimo, pasa al siguiente Round
            }
       
    }

    public void PreviousImage()
        {
            messageIndex = messageIndex - 1;
            MessageData messageData = messagePool[messageIndex];
            messageText.text = messageData.messageText;
            Next.gameObject.SetActive(true);
            Conditions();
            //CorrectState();
        }

   public void CorrectState()
 
        {   
            //closeTutorButton.onClick.AddListener(NextRound);
            Correct.onClick.AddListener(Exit);
            Incorrect.onClick.AddListener(IncorrectState);
        } 
        

    public void IncorrectState()
        {
            Next.gameObject.SetActive(true);
            Previous.gameObject.SetActive(false);
            Correct.gameObject.SetActive(false);
            Incorrect.gameObject.SetActive(false);

        if (messageIndex == messagePool.Length - 1)
                {
                    NextRound();
                   
                }
           
             else if (messageIndex == 5)
                {
                    NextImage();
                }
                
               
        
        }

    public void Exit()
        {
            Next.gameObject.SetActive(false);
            Previous.gameObject.SetActive(false);
            Correct.gameObject.SetActive(false);
            Incorrect.gameObject.SetActive(false);
            closeTutorButton.onClick.AddListener(Start);
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
        }
    private void Reset()
    {
        messageIndex = 0;
        currentMessageRoundData = messageDataController.GetCurrentMessageRoundData(0); //get position 0
        messagePool = currentMessageRoundData.messages;
        MessageData messageData = messagePool[0];
        messageText.text = messageData.messageText;
    }

    private void Conditions()
    {
        if (messageIndex == 0 )
        {

            Next.gameObject.SetActive(true);
            Previous.gameObject.SetActive(false);
            Correct.gameObject.SetActive(false);
            Incorrect.gameObject.SetActive(false);
        }
    }
}
