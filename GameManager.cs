using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject menuPrincipal;
    public GameObject menuGameOver;
    //public GameObject menuPuntuacion;
    public Text scoreCount;

    public int score = 0;
    public GameObject col;
    public Renderer fondo;
    public float velocidad = 2;
    public GameObject piedra1;
    public GameObject piedra2;
    public bool gameOver = false;
    public bool start = false;


    public List<GameObject> cols;
    public List<GameObject> obstaculos;

    // Start is called before the first frame update
    void Start()
    {
        //Aumentar puntiacio
        InvokeRepeating("addScore", 1.0f, 1.0f);
        score = 0;


        //Crear Mapa
        for (int i=0; i<21; i++)
        {
            cols.Add(Instantiate(col, new Vector2(-10 + i, -3), Quaternion.identity)); 
            
        }
        //Crear piedras
        obstaculos.Add(Instantiate(piedra1, new Vector2(-14, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra2, new Vector2(-18, -2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        print(score);
        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }

        if (start == true && gameOver == true)
        {
            menuGameOver.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (start == true && gameOver == false)
        {

            menuPrincipal.SetActive(false);

            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;

            //Moure mapa
            for (int i = 0; i < cols.Count; i++)
            {

                if (cols[i].transform.position.x <= -10)
                {
                    cols[i].transform.position = new Vector3(10f, -3, 0);
                }
                cols[i].transform.position = cols[i].transform.position + new Vector3(-1f, 0, 0) * Time.deltaTime * velocidad;

            }
            //Moure pedres
            for (int i = 0; i < obstaculos.Count; i++)
            {

                if (obstaculos[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(11, 18);
                    obstaculos[i].transform.position = new Vector3(randomObs, -2, 0);
                }
                obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1f, 0, 0) * Time.deltaTime * velocidad;
                print(Time.deltaTime);
            }

        }



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void addScore()
    {
        if (start == true && gameOver == false) {
            score = score + 1;
            scoreCount.text = score.ToString();
            velocidad = velocidad + 0.07f;
               
        }
           
    }
}

