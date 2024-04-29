using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class GameController : MonoBehaviour
{
    [SerializeField]    // Atributo permite que esta variable privada sea visible y editable desde el inspector de Unity.
    private Sprite cbImage; //Sprite para la imagen de la carta cuando est� boca abajo.

    public Sprite[] cards;    // Array de sprites para las im�genes de las cartas.
    public List<Sprite> gameCards = new List<Sprite>();    // Lista de sprites que se usar�n en el juego.

    public List<Button> btns = new List<Button>();    // Lista de botones que representan las cartas.

    private bool firstGuess, secondGuess;    // Variables para controlar el primer y segundo intento en una ronda de adivinanza.

    public int countGuesses;    // Contador de intentos totales.
    private int countCorrectGuesses;    // Contador de intentos correctos.
    private int gameGuesses;    // N�mero total de intentos necesarios para ganar el juego.

    private int firstGuessIndex, secondGuessIndex;    // �ndices de las cartas seleccionadas en el primer y segundo intento.


    private string firstCardGuess, secondCardGuess;    // Nombres de las cartas seleccionadas en el primer y segundo intento.


    public Timer timer;    // Referencia al componente Timer para controlar el tiempo de juego.
    void Start()
    {
        GetButtons();    // Obtiene los botones de la escena.
        AddListener();    // A�ade listeners a los botones para detectar los clics.
        AddGameCards();    // A�ade las cartas al juego.
        gameGuesses = gameCards.Count / 2;    // Calcula el n�mero total de intentos necesarios para ganar el juego.
        Shuffle(gameCards);    // Mezcla las cartas.
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("btn");    // Busca todos los objetos con la etiqueta "btn".
        for (int i = 0; i < objects.Length; i++)    // Recorre todos los objetos encontrados.
        {
            btns.Add(objects[i].GetComponent<Button>());    // A�ade el componente Button del objeto a la lista de botones.
            btns[i].image.sprite = cbImage;    // Asigna la imagen de la carta boca abajo al bot�n.
        }
    }

    void AddGameCards()
    {
        int looper = btns.Count;    // N�mero de botones en la escena.
        int index = 0;
        for (int i = 0; i < looper; i++)    // Recorre todos los botones.
        {
            if(index == looper / 2)    // Si se ha recorrido la mitad de los botones, reinicia el �ndice.
            {
                index = 0;
            }

            gameCards.Add(cards[index]);    // A�ade la carta correspondiente al juego.
            index++;
        }
    }

    void AddListener()
    {
        foreach(Button btn in btns)    // Recorre todos los botones.
        {
            btn.onClick.AddListener(()=> PickACard());    // A�ade un listener al bot�n para llamar al m�todo PickACard cuando se haga clic en el bot�n.
        }
    }

    public void PickACard()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;    // Obtiene el nombre del bot�n en el que se ha hecho clic.

        if (!firstGuess)    // Si es el primer intento en una ronda de adivinanza.
        {
            firstGuess = true;    // Marca que se ha hecho el primer intento.
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);    // Obtiene el �ndice del bot�n en el que se ha hecho clic.
            firstCardGuess = gameCards[firstGuessIndex].name;    // Obtiene el nombre de la carta seleccionada.
            btns[firstGuessIndex].image.sprite = gameCards[firstGuessIndex];    // Muestra la imagen de la carta seleccionada.
        }
        else if(!secondGuess)    // Si es el segundo intento en una ronda de adivinanza.
        {
            secondGuess = true;    // Marca que se ha hecho el segundo intento.
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);    // Obtiene el �ndice del bot�n en el que se ha hecho clic.
            secondCardGuess = gameCards[secondGuessIndex].name;    // Obtiene el nombre de la carta seleccionada.
            btns[secondGuessIndex].image.sprite = gameCards[secondGuessIndex];    // Muestra la imagen de la carta seleccionada.
            countGuesses++;    // Incrementa el contador de intentos totales.

            StartCoroutine(CheckIfTheCardsMatch());  // Inicia una coroutina para comprobar si las dos cartas seleccionadas coinciden.
        }
    }

    IEnumerator CheckIfTheCardsMatch()
    {
        yield return new WaitForSeconds(0.3f);    // Espera durante 0.3 segundos.
        if (firstCardGuess == secondCardGuess)   // Si las dos cartas seleccionadas coinciden.
        {
            yield return new WaitForSeconds(0.5f);

            btns[firstGuessIndex].interactable = false;    // Desactiva el bot�n de la primera carta seleccionada.
            btns[secondGuessIndex].interactable = false;    // Desactiva el bot�n de la segunda carta seleccionada.

            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);    // Oculta la imagen de la primer carta seleccionada.
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);    // Oculta la imagen de la segunda carta seleccionada.

            CheckIfTheGameIsFinished();    // Comprueba si el juego ha terminado.
        }
        else    // Si las dos cartas seleccionadas no coinciden.
        {
            yield return new WaitForSeconds(0.5f);

            btns[firstGuessIndex].image.sprite = cbImage;    // Muestra la imagen de la carta boca abajo en la primera carta seleccionada.
            btns[secondGuessIndex].image.sprite = cbImage;    // Muestra la imagen de la carta boca abajo en la segunda carta seleccionada.
        }

        yield return new WaitForSeconds(0.2f);
        firstGuess = secondGuess = false;    // Reinicia los intentos para la pr�xima ronda de adivinanza.

    }
    
    void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;    // Incrementa el contador de intentos correctos.
        if (countCorrectGuesses == gameGuesses)    // Si todos los intentos han sido correctos.
        {
            timer.GameFinished();    // Llama al m�todo GameFinished del componente Timer.
            StartCoroutine(WaitAndLoadScene(4, 3f));    // Inicia una coroutina para esperar durante 3 segundos y luego cargar la escena con el �ndice 4.
        }
    }

    IEnumerator WaitAndLoadScene(int sceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay);   // Espera durante el tiempo especificado.
        SceneManager.LoadScene(sceneIndex);    // Carga la escena con el �ndice especificado.
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)    // Recorre todas las cartas.
        {
            Sprite temp = list[i];    // Guarda la carta actual en una variable temporal.
            int randomIndex = Random.Range(i, list.Count);    // Obtiene un �ndice aleatorio entre el �ndice actual y el n�mero total de cartas.
            list[i] = list[randomIndex];    // Asigna la carta en el �ndice aleatorio a la carta en el �ndice actual.
            list[randomIndex] = temp;    // Asigna la carta temporal a la carta en el �ndice aleatorio.
        }
    }
}