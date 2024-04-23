using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite cbImage;

    public Sprite[] cards;
    public List<Sprite> gameCards = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    private bool firstGuess, secondGuess;
    
    public int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstCardGuess, secondCardGuess;

    public Timer timer;
    void Start()
    {
        GetButtons();
        AddListener();
        AddGameCards();
        gameGuesses = gameCards.Count / 2;
        Shuffle(gameCards);
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("btn");
        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = cbImage;
        }
    }

    void AddGameCards()
    {
        int looper = btns.Count;
        int index = 0; 
        for (int i = 0; i < looper; i++)
        {
            if(index == looper / 2)
            {
                index = 0;
            }

            gameCards.Add(cards[index]);
            index++;
        }
    }

    void AddListener()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(()=> PickACard());   
        }
    }

    public void PickACard()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        
        if(!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstCardGuess = gameCards[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gameCards[firstGuessIndex];
        }
        else if(!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondCardGuess = gameCards[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = gameCards[secondGuessIndex];
            countGuesses++;

            StartCoroutine(CheckIfTheCardsMatch());
        }
    }

    IEnumerator CheckIfTheCardsMatch()
    {
        yield return new WaitForSeconds(0.3f);
        if(firstCardGuess == secondCardGuess)
        {
            yield return new WaitForSeconds(0.5f);

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            btns[firstGuessIndex].image.sprite = cbImage;
            btns[secondGuessIndex].image.sprite = cbImage;
        }

        yield return new WaitForSeconds(0.2f);
        firstGuess = secondGuess = false;

    }
    
    void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;
        if (countCorrectGuesses == gameGuesses)
        {
            timer.GameFinished();
            StartCoroutine(WaitAndLoadScene(4, 3f));
        }
    }

    IEnumerator WaitAndLoadScene(int sceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}