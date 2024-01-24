using UnityEngine;

public class Level_46 : MonoBehaviour
{
    private Game game;
    private readonly int levelNum = 45;
    private readonly string levelKey = "Rec_46";
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
    private void Update()
    {
        game.TimerForLevel();
    }
    private void Go() => game.TheFirstFew(10, 2.3f, 3.2f,5, levelKey, levelNum);
}
