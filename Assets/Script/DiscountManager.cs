using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Discount
{
    public GameObject item;
    public int discountPercentage;
}
public class DiscountManager : Singleton<DiscountManager>
{

    private const string WIN_TEXT_LEFT = "You earned ";
    private const string WIN_TEXT_RIGHT = " discount for your next purchase!";

    public GameObject congratulationsPanel;
    public Text congratulationsMessage;

	public ParticleSystem winParticle;

    public List<Discount> discounts;

    public void PlayCongrats(GameObject item)
    {
        Discount found = discounts.Find(x => x.item == item);
        if (found != null)
        {
            congratulationsPanel.SetActive(true);
            congratulationsMessage.text = WIN_TEXT_LEFT + found.discountPercentage + WIN_TEXT_RIGHT;
            congratulationsPanel.GetComponent<Image>().CrossFadeAlpha(0.0f, 2.0f, false);
			congratulationsMessage.GetComponent<Text>().CrossFadeAlpha(0.0f, 2.0f, false);

			Destroy(item);
            StartCoroutine(PlayPS());
        }
    }

    private IEnumerator PlayPS() {
        winParticle.Play();
        yield return new WaitForSeconds(2f);
        congratulationsPanel.SetActive(false);
    }

}
