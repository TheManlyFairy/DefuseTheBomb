using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class ArrayWrapper<T> { public T[] data; }

public class MazePuzzleManager : MonoBehaviour {

    public static MazePuzzleManager instance;

    [SerializeField]
    GameObject player_prefab;
    [SerializeField]
    GameObject tile_prefab;
    [SerializeField]
    Material mat1, mat2;
    [SerializeField]
    AudioClip fail, win;
    [SerializeField]
    TextAsset txt;

    Board board;
    GameObject player;
    Vector3 start_pos;
    AudioSource audio;
    Vector3 location;
    Bounds bounds;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        location = transform.position;
        audio = gameObject.GetComponent<AudioSource>();        
    }

    private void Start()
    {
        transform.position = Vector3.zero;
        ArrayWrapper<Board> array = FileManager.instance.Load<ArrayWrapper<Board>>(txt);  
        board = array.data[UnityEngine.Random.Range(0, array.data.Length )];
        InitBoard();
        transform.position = location;
        bounds = new Bounds();
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
            bounds.Encapsulate(renderer.bounds);
    }


    private void OnDisable()
    {
        if (player != null)
            player.GetComponent<PlayerMovement>().enabled = false;
    }

    private void OnEnable()
    {
        if (player != null)
            player.GetComponent<PlayerMovement>().enabled = true;
    }

    public void InitBoard()
    {
        Vector3 tile_size = tile_prefab.GetComponent<Renderer>().bounds.size;
        Vector2 origin = new Vector2(-(board.Size.y-1)* tile_size.z/2, -(board.Size.x-1) * tile_size.x/2);
        for (int r = 0; r < board.Size.x; r++)
        {
            for (int c = 0; c < board.Size.y; c++)
            {
                GameObject tile = Instantiate(tile_prefab, new Vector3(origin.x+c* tile_size.x, 0, origin.y+r*tile_size.z), tile_prefab.transform.rotation);
                tile.transform.parent = gameObject.transform;
                if ((c + r * board.Size.y) % 2 == 0)
                    tile.GetComponent<Renderer>().material = mat1;
                else
                    tile.GetComponent<Renderer>().material = mat2;
                if (board.isTrap(new Vector2(c, r)))
                {
                    tile.AddComponent<TrapTileScript>();
                }
                if (board.StartPos.x==c && board.StartPos.y==r)
                {
                    player=Instantiate(player_prefab,new Vector3(tile.transform.position.x,0.5f, tile.transform.position.z), Quaternion.identity);
                    player.transform.parent = gameObject.transform;
                    start_pos = player.transform.position;
                }
                else if(board.EndPos.x==c && board.EndPos.y==r)
                {
                    tile.AddComponent<EndTileScript>();
                }
            }
        }
    }

    public void Fail()
    {
        audio.clip = fail;
        audio.Play();
        player.transform.position = start_pos;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        StartCoroutine(PlayerSleep());
    }

    IEnumerator PlayerSleep()
    {
        PlayerMovement script = player.GetComponent<PlayerMovement>();
        script.enabled = false;
        yield return new WaitForSeconds(2f);
        script.enabled = true;
    }

    public void Win()
    {
        audio.clip = win;
        audio.Play();
    }
}
