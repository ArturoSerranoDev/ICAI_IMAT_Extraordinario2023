using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//SOLO ES NECESARIO DESCOMENTAR, NO MODIFICAR EL CÓDIGO
public class Analysis : MonoBehaviour
{
    List<TextMeshPro> textResults;
    List<Sale> sales;
    string typeSale;
    int threshold;

    //SalesAnalysis salesAnalysis = SalesAnalysis.Instance;

    private void Awake()
    {
        textResults = GetComponent<Results>().GetTextResults();
    }

    public void AnalyzeTest1()
    {
        sales = new List<Sale>
        {
            new Sale { ID = 1, ProductName = "Laptop", Quantity = 10, UnitPrice = 800 },
            new Sale { ID = 2, ProductName = "Smartphone", Quantity = 15, UnitPrice = 500 },
            new Sale { ID = 3, ProductName = "Laptop", Quantity = 20, UnitPrice = 1200 },
            new Sale { ID = 4, ProductName = "Tablet", Quantity = 8, UnitPrice = 300 },
            new Sale { ID = 5, ProductName = "Smartphone", Quantity = 12, UnitPrice = 700 }
        };
        typeSale = "Laptop";
        threshold = 20000;

        ShowResults();
    }

    /*
    public void AnalyzeTest2()
    {
        sales = new List<Sale>
        {
            new OnlineSale { ID = 1, ProductName = "Laptop", Quantity = 5, UnitPrice = 1000, Website = "www.techstore.com" },
            new OfflineSale { ID = 2, ProductName = "Laptop", Quantity = 3, UnitPrice = 1000, StoreLocation = "Downtown" },
            new OnlineSale { ID = 3, ProductName = "Smartphone", Quantity = 10, UnitPrice = 500, Website = "www.techstore.com" },
            new OfflineSale { ID = 4, ProductName = "Tablet", Quantity = 2, UnitPrice = 300, StoreLocation = "Uptown" },
            new OnlineSale { ID = 5, ProductName = "Smartphone", Quantity = 7, UnitPrice = 500, Website = "www.gadgetworld.com" },
            new OfflineSale { ID = 6, ProductName = "Laptop", Quantity = 1, UnitPrice = 1000, StoreLocation = "Suburban" },
            new OnlineSale { ID = 7, ProductName = "Tablet", Quantity = 5, UnitPrice = 300, Website = "www.techstore.com" }
        };
        typeSale = "Tablet";
        threshold = 5000;

        ShowResults();
    }
    */

    void ShowResults()
    {
        //textResults[0].text = $"Total sales of {typeSale}s: <b>{salesAnalysis.CalculateTotalSales(sales, typeSale)}</b>";
        //textResults[1].text = $"Best selling product: <b>{salesAnalysis.GetBestSellingProduct(sales)}</b>";
        //textResults[2].text = $"Products exceeding a sales threshold of {threshold} €: <b>{string.Join(", ", salesAnalysis.GetProductsExceedingSalesThreshold(sales, threshold))}</b>";
        //textResults[3].text = $"Most profitable product: <b>{salesAnalysis.GetMostProfitableProduct(sales)}</b>";
        //textResults[4].text = $"Comparison of online and offline sales: <b>{salesAnalysis.GetSaleTypeWithMoreSales(sales)}</b>";
    }
}
