using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public interface IGameController {
    int turn { get; set; }
    Phase currentPhase { get; set; }
    float secondsPerDay { get; set; }
    PlayerListControl playerList { get; set; }
    void Win();
}
// used by Game object in World scene
public class GameController : NetworkBehaviour, IGameController {

    private Phase _currentPhase;
    public Phase currentPhase {
        get { return _currentPhase; }
        set { _currentPhase = value; }
    }

    private PlayerListControl _playerList;
    public PlayerListControl playerList {
        get { return _playerList; }
        set { _playerList = value; }
    }

    public Phase startingPhase;

    public Phase winPhase;
    public Phase losePhase;

    [SyncVar]
    private float _secondsPerDay;
    public float secondsPerDay {
        get { return _secondsPerDay; }
        set { _secondsPerDay = value; }
    }

    [SyncVar]
    private int _turn;
    public int turn {
        get { return _turn; }
        set { _turn = value; }
    }

    public override void OnStartServer() {
        startingPhase.Begin();
    }

    public void Awake() {
        Phase[] children = GetComponentsInChildren<Phase>();
        foreach (Phase child in children) { child.game = this; }
        playerList = GameObject.Find("PlayerList").GetComponent<PlayerListControl>();
    }

    [Server]
    public void Win() {
        currentPhase.End();
        winPhase.Begin();
    }
    
    [Server]
    public void Lose() {
        currentPhase.End();
        losePhase.Begin();
    }
}
