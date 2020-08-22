using UnityEngine;
using System.Collections;

public class WoDController : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //UnityちゃんとWallofDsetroyの距離
    private float difference;

    // Use this for initialization
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //UnityちゃんとWall of Destoryの位置（z座標）の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの位置に合わせてWallofDestroyの位置を移動
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);


    }

    void OnTriggerEnter(Collider other)
    {
        //障害物に衝突した場合→破壊
        if (other.gameObject.tag == "CarTag")
        {
            Destroy(other.gameObject);
            //Debug.Log("車を破壊したよ！");
        }

         if (other.gameObject.tag == "TrafficConeTag")
        {
            Destroy(other.gameObject);
            //Debug.Log("コーンを破壊したよ！");
        }

        if (other.gameObject.tag == "CoinTag")
        {
            Destroy(other.gameObject);
            //Debug.Log("コインを破壊したよ！");
        }
    }
}