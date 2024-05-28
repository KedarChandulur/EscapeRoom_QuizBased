public class LivesManager
{
    public static System.Action AllLivesEndEvent;
    private ushort lives = 0;
    private const ushort numberOfLives = 5;
    private UIManager uiManager;

    public void Initialize(UIManager _uiManager)
    {
        this.uiManager = _uiManager;
        Reset();
    }

    public ushort GetLives()
    {
        return lives;
    }

    public void DecrementLives()
    {
        if(--lives == 0)
        {
            AllLivesEndEvent?.Invoke();
        }

        uiManager.UpdateTriesText(lives);
    }

    private void Reset()
    {
        lives = numberOfLives;
        uiManager.UpdateTriesText(lives);
    }
}
