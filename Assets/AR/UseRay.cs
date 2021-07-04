using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseRay : MonoBehaviour
{
    /// <summary>Rayを飛ばす始点</summary>
    [SerializeField] GameObject m_bulletSpwan;　
    [SerializeField] GameObject m_muzzleFlash;
    /// <summary> 見せかけの銃弾 </summary>
    [SerializeField] GameObject m_BulletFake;
    [SerializeField] GameObject m_AR;
    /// <summary>  Reticleの取得 </summary>
    [SerializeField] Image m_ReticleUI;
    /// <summary> MuzzleFlashを消すため時間</summary>
    private float m_time = 0f;
    /// <summary>Scriptを参照する </summary>
    BulletCount BulletCount;
    /// <summary>発砲音を出すリソース</summary>
    private AudioSource Audio;
    public AudioClip Shooting_Sound;

    [SerializeField] LayerMask m_mask;

    [SerializeField] GameObject m_target;

    //target m_tagetScript;
    // Start is called before the first frame update
    void Start()
    {
        BulletCount = m_AR.GetComponent<BulletCount>();
        Audio = gameObject.AddComponent<AudioSource>();
        //m_tagetScript = m_target.GetComponent<target>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        m_time += Time.deltaTime;
        Fire();

        if (Input.GetKeyDown(KeyCode.Escape)) //カーソルを表示させる
        {
            Cursor.visible = true;
        }
    }

    private void Fire()
    {
        //Ray ray = new Ray(m_bulletSpwan.transform.position, m_bulletSpwan.transform.forward); //BulletSpwanからRayを飛ばす
        Ray ray = Camera.main.ScreenPointToRay(m_ReticleUI.rectTransform.position);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 10.0f, Color.red, 5); //Scene内でRayをみれるようにする
        //if (Physics.Raycast(ray, out hit, 20.0f)) //Ray当たり判定を使い腰うち時のReticleUIの色を変える
        //{
        //    m_ReticleUI.color = Color.red; //Rayが当たっていたら色を赤にする
        //}
        //else
        //{
        //    m_ReticleUI.color = Color.white; //Rayが当たってなかったら色を白にする
        //}

        if (Input.GetMouseButtonDown(0) && BulletCount.m_count != 0 && !BulletCount.m_reloadFlag) //左クリックしたら発砲する
        {
            Audio.PlayOneShot(Shooting_Sound);
            m_muzzleFlash.SetActive(true);
            GameObject newBullet = Instantiate(m_BulletFake, this.gameObject.transform.position, this.gameObject.transform.rotation); //見せかけの銃弾をつくる
            newBullet.name = m_BulletFake.name;

            if (Physics.Raycast(ray, out hit, 100.0f)) //当たり判定の処理を行う
            {
                //Destroy(hit.collider.gameObject);
                //Destroy(newBullet, 0.1f);
                //m_tagetScript.Hit();
            }
            BulletCount.m_count--;
        }

        if (m_time > 0.3f) // MuzzleFlashを見えなくする
        {
            m_muzzleFlash.SetActive(false);
            m_time = 0f;
        }

        if (m_time > 0.3f)
        {
            m_time = 0f;
        }
    }
}
