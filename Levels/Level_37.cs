using UnityEngine;

public class Level_37 : MonoBehaviour //������,�������,����� - 3 ������� - ��������� ����� 0
{
    private Game game;
    private readonly int levelNum = 36;
    private readonly string levelKey = "Rec_37";
    private void Awake()
    {
        game = Camera.main.GetComponent<Game>();
        game.AwakeAnyLevel();
    }
    private void Start()
    {
        game.StartAnyLevel();
        game.TabloOn();
        Invoke(nameof(Go), 5f);
    }
    private void Update()
    {
        game.TimerForLevel();
    }
    public void Go() => game.TheFirstFew(8, 2.6f, 3.5f, 4, levelKey, levelNum);
}
