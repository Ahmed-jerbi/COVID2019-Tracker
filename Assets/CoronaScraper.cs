using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using AngleSharp;
using AngleSharp.Html.Parser;

public class CoronaScraper : MonoBehaviour
{
    public Text stats;
    public Text updateTime;

     void Start()
    {
        InvokeRepeating("UpdateStats", 0, 60);


    }

    async void UpdateStats()
    {
        var config = Configuration.Default.WithDefaultLoader();
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync("https://www.worldometers.info/coronavirus/country/germany/");
        var cells = document.QuerySelectorAll("div.maincounter-number");
        Debug.Log(cells.Length);
        
        stats.text = "";
        foreach (var title in cells)
        {
            Debug.Log(title.TextContent);
            stats.text += title.TextContent;
        }

        updateTime.text = "Stand: " + System.DateTime.Now.ToString("dd.MM.yyyy , HH:mm") + " Uhr";
    }
}
