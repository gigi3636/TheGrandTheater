using Godot;
using System;

public partial class PlayerAct2MiniGame : IPlayerAction
{
    private const float SHOT_MAX_TILT = 2000f;
    private const float SHOT_MIN_TILT = -500f;
    private const float SHOT_INCREASE_ANGLE = 2000f;

    private PlayerController playerControllerRef;

    public event Action<float> OnPlayerShot;
    public event Action<float> OnPlayerAiming;
    public event Action OnPlayerStopAiming;

    private float shoteTiltAmount ;

    private bool isPlayerBowing;
    private bool isPlayerJustShot;
    private bool isAimingInReverse;

    public PlayerAct2MiniGame(PlayerController pPlayerControllerRef)
    {
        playerControllerRef = pPlayerControllerRef;
    }

    public void OnButtonPressed()
    {
        if (!isPlayerBowing  )
        {
            isPlayerBowing = true;
        }
    }

    public void OnButtonReleased()
    {
        if (isPlayerBowing)
        {
            isPlayerBowing = false;
            isPlayerJustShot = true;
            OnPlayerShot?.Invoke(shoteTiltAmount);
            OnPlayerStopAiming?.Invoke();
        }
    }

    public void OnButtonIdle() { }

    public void Update(float pDelta)
    {
        if (isPlayerBowing)
        {
            float lStep = SHOT_INCREASE_ANGLE * pDelta;
            shoteTiltAmount += isAimingInReverse ? -lStep : lStep; // Increase or decrease the angle of shot

            // Switch if its increasing or decreasing
            if (shoteTiltAmount >= SHOT_MAX_TILT)
            {
                shoteTiltAmount = SHOT_MAX_TILT; 
                isAimingInReverse = true;
            }
            else if (shoteTiltAmount <= SHOT_MIN_TILT)
            {
                shoteTiltAmount = SHOT_MIN_TILT;
                isAimingInReverse = false;
            }

            OnPlayerAiming?.Invoke(shoteTiltAmount);
        }
        else if (isPlayerJustShot)
        {
            isPlayerJustShot = false;
            shoteTiltAmount = SHOT_MIN_TILT;
            isAimingInReverse = false;
        }
    }
}
