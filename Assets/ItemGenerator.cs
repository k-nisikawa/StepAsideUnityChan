using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //アイテムを生成した時の座標
    private float seisei;

    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //何メートル先にアイテムを出すか ※iの代わり
    private float saki =0;

    // Use this for initialization
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //Unityちゃんとの距離（z座標）を求める
        this.seisei = unitychan.transform.position.z;


    }

    // Update is called once per frame
    void Update()
    {
        //★新しく追加したところ、、、ここから
        if (unitychan.transform.position.z - this.seisei >= 15 && goalPos - unitychan.transform.position.z >=45)
        {
            //アイテムを出した座標を記録
            seisei = unitychan.transform.position.z;

            Debug.Log("15メートル以上になったよ");
            //★ここまで

            float saki = unitychan.transform.position.z + 45;


            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, saki);
                }
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, saki + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, saki + offsetZ);
                    }
                }


                //} ※一番最初のfor文をコメントアウト
            }
        }
    }


    
}