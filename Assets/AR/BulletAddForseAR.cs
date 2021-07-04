using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAddForseAR : MonoBehaviour
{
    /// <summary>Rayと見せかけの銃弾の始点</summary>
    GameObject m_Bullet_SpwanAR;
    
    Rigidbody m_Bullet_rbAR;
    // Start is called before the first frame update
    void Start()
    {
        m_Bullet_SpwanAR = GameObject.Find("BulletSpwanAR");
        m_Bullet_rbAR = this.gameObject.GetComponent<Rigidbody>();  
        m_Bullet_rbAR.AddForce(m_Bullet_SpwanAR.transform.forward * 10000f); //見せかけの銃弾を飛ばす
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 1f); //見せかけの銃弾を削除する
    }
}
