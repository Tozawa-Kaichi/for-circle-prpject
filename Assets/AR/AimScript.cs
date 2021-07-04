using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimScript : MonoBehaviour
{
    [SerializeField] Image m_ReticleUI; //Reticleを取得
    [SerializeField] Transform m_AimPos; //AIMした時の銃の位置
                     Transform m_NoaimPos; //自身の位置を保存しておく

    Animator m_anim;
    // Start is called before the first frame update
    void Start()
    {
        m_NoaimPos = this.gameObject.transform;
        m_anim = GetComponent<Animator>();
        m_anim.SetBool("IsAim", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) //右クリックでエイム
        {
            //float present_Location = (Time.deltaTime * m_Speed) / m_distanceTwo; //Lerpで使う自身の位置を求める
            //transform.position = Vector3.Lerp(this.gameObject.transform.position, m_AimPos.position, present_Location); Lerpを使い銃を滑らかに動かす
            m_anim.SetBool("IsAim", true);
            m_ReticleUI.gameObject.SetActive(false); //Reticleを消す
        }

        if (Input.GetMouseButtonUp(1)) //右クリックを話すと腰うちになる
        {
            m_ReticleUI.gameObject.SetActive(true); //Reticleを表示させる
            m_anim.SetBool("IsAim", false);
            //this.gameObject.transform.Translate(0.5f, -0.4f, 0.5f);
        }

    }

}
