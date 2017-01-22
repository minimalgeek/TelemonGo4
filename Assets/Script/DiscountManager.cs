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
    private const string WIN_TEXT_RIGHT = "% discount for your next purchase!";

    public GameObject congratulationsPanel;
    public Text congratulationsMessage;

	public ParticleSystem winParticle;

    public List<Discount> discounts;

    public void PlayCongrats(GameObject item)
    {
        Discount found = discounts.Find(x => x.item == item);
        if (found != null)
        {
            Destroy(item);
            congratulationsMessage.text = WIN_TEXT_LEFT + found.discountPercentage + WIN_TEXT_RIGHT;
            StartCoroutine(PlayPS());
        }
    }

    private IEnumerator PlayPS() {
        winParticle.Play();
        congratulationsPanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        congratulationsPanel.SetActive(false);
        
    }

}
