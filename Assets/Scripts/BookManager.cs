using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    [SerializeField]
    private GameObject book;
    [Header("Pages")]
    [SerializeField]
    private GameObject page1and2;
    [SerializeField]
    private GameObject page3and4;
    [SerializeField]
    private GameObject page5and6;
    [SerializeField]
    private GameObject page7and8;
    [SerializeField]
    private GameObject page9and10;
    [SerializeField]
    private GameObject page11and12;

    [SerializeField]
    private GameObject nextButton;

    private int currentPage = 1;

    private void Awake()
    {
        book.gameObject.SetActive(false);
    }

    public void OpenBook()
    {
        book.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
    }

    public void CloseBook()
    {
        nextButton.gameObject.SetActive(false);
        book.gameObject.SetActive(false);
    }

    public void NextPage()
    {
        switch(currentPage)
        {
            case 0:
                page1and2.gameObject.SetActive(true);
                page3and4.gameObject.SetActive(false);
                page5and6.gameObject.SetActive(false);
                page7and8.gameObject.SetActive(false);
                page9and10.gameObject.SetActive(false);
                page11and12.gameObject.SetActive(false);
                currentPage++;
                break;
            case 1:
                page1and2.gameObject.SetActive(false);
                page3and4.gameObject.SetActive(true);
                page5and6.gameObject.SetActive(false);
                page7and8.gameObject.SetActive(false);
                page9and10.gameObject.SetActive(false);
                page11and12.gameObject.SetActive(false);
                currentPage++;
                break;
            case 2:
                page1and2.gameObject.SetActive(false);
                page3and4.gameObject.SetActive(false);
                page5and6.gameObject.SetActive(true);
                page7and8.gameObject.SetActive(false);
                page9and10.gameObject.SetActive(false);
                page11and12.gameObject.SetActive(false);
                currentPage++;
                break;
            case 3:
                page1and2.gameObject.SetActive(false);
                page3and4.gameObject.SetActive(false);
                page5and6.gameObject.SetActive(false);
                page7and8.gameObject.SetActive(true);
                page9and10.gameObject.SetActive(false);
                page11and12.gameObject.SetActive(false);
                currentPage++;
                break;
            case 4:
                page1and2.gameObject.SetActive(false);
                page3and4.gameObject.SetActive(false);
                page5and6.gameObject.SetActive(false);
                page7and8.gameObject.SetActive(false);
                page9and10.gameObject.SetActive(true);
                page11and12.gameObject.SetActive(false);
                currentPage++;
                break;
            case 5:
                page1and2.gameObject.SetActive(false);
                page3and4.gameObject.SetActive(false);
                page5and6.gameObject.SetActive(false);
                page7and8.gameObject.SetActive(false);
                page9and10.gameObject.SetActive(false);
                page11and12.gameObject.SetActive(true);
                currentPage = 0;
                break;
        }
    }

}
