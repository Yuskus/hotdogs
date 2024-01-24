using UnityEngine;

public class Level_28 : MonoBehaviour //��� - 1 ������� - ��������� ����� 3
{
    private Game game;
    private readonly int levelNum = 27;
    private readonly string levelKey = "Rec_28";
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
    private void Go() => game.TheFirstFew(7, 2.8f, 3.6f, 3, levelKey, levelNum); //CHECK
}
