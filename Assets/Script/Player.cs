using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CoinColector _coinTemplate;
    private int _score;
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out CoinColector coin))
        {
            TaceCoin(coin);
        }
    }
    private void TaceCoin(CoinColector coin)
    {
        _score++;
        print($"Selected {_score} coins from 38");
        coin.gameObject.SetActive(false);
        _audioSource.Play();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_coinTemplate);
        }
    }
}
