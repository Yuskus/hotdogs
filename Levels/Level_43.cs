using UnityEngine;

public class Level_43 : MonoBehaviour
{
    private Game game;
    private readonly int levelNum = 42;
    private readonly string levelKey = "Rec_43";
    private void Awake()
    {
        game = Camera.main.GetComponent<Game>();
        game.AwakeAnyLevel();
    }
    private void Start()
    {
        game.StartAnyLevel();
        game.TabloOn();
        Invoke(nameof(Go), 5f); //CHECK
    }
    private void Update() //CHECK
    {
        game.TimerForLevel();
    }
    private void Go() => game.TheFirstFew(9, 2.4f, 3.3f, 4, levelKey, levelNum); //CHECK
}
