using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    [SerializeField]
    private GameObject m_SpawnEggsprefab;

    [SerializeField]
    Vector3 m_move; // �ړ���
  
    [SerializeField]
    AudioClip clip;
    private int m_Life;

    // Start is called before the first frame update
    void Start()
    {
        m_Life = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;

        pos += m_move * Time.deltaTime;

        transform.position = pos;

        m_Life--;

        if(m_Life < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider colider)
    {
        // �G���ǂ����m�F
        if (colider.gameObject.CompareTag("Player"))
        {
            // �v���C���[�����ʒu�܂ł̍X�V
            GameObject player = GameObject.FindGameObjectWithTag("Player"); // �v���C���[���擾
            GameManager gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>(); // �}�l�[�W���[���擾

            // ������
            GameObject obj = Instantiate(m_SpawnEggsprefab, transform.position, Quaternion.identity);

            Egg egg = obj.GetComponent<Egg>();
            egg.Set(player.transform.position, new Vector3(-20.12f, 0.0f, 0.0f));
            SoundManager.Instance.PlaySound(clip);
            // ���g������
            Destroy(gameObject);
        }
    }
}