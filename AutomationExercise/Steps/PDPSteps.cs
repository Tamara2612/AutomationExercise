using System;
using AutomationExercise.Helpers;
using AutomationExercise.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AutomationExercise.Steps
{
    [Binding]
    public class PDPSteps: Base
    {
        Utilities ut = new Utilities(Driver);
        HeaderPage hp = new HeaderPage(Driver);

        private readonly ProductData productData;
        
        public PDPSteps(ProductData productData)
        {
            this.productData = productData;
        }

        [Given(@"user opens products page")]
        public void GivenUserOpensProductsPage()
        {
            ut.ClickonElement(hp.productsLink);
        }
        
        [Given(@"searches for products")]
        public void GivenSearchesForProducts()
        {
            ProductsListPage plp = new ProductsListPage(Driver);
            ut.EnterTextinElement(plp.searchBox, TestConstants.Searchbox);
            ut.ClickonElement(plp.searchBtn);
        }
        
        [Given(@"opens first search result")]
        public void GivenOpensFirstSearchResult()
        {
            ProductsListPage plp = new ProductsListPage(Driver);
            ut.ClickonElement(plp.viewProduct);
        }
        
        [When(@"user clicks on Add to Cart button")]
        public void WhenUserClicksOnAddToCartButton()
        {
            ProductDetailsPage pdp = new ProductDetailsPage(Driver);
            productData.ProductName = ut.ReturnTextFromElement(pdp.productName);
            ut.ClickonElement(pdp.addBtn);
        }
        
        [When(@"proceeds to the cart")]
        public void WhenProceedsToTheCart()
        {
            ProductDetailsPage pdp = new ProductDetailsPage(Driver);
            ut.ClickonElement(pdp.viewCart);
        }
        
        [Then(@"shopping cart will be displayed with expected product inside")]
        public void ThenShoppingCartWillBeDisplayedWithExpectedProductInside()
        {
            Assert.True(ut.TextPresentinElement(productData.ProductName), "Expected product is not in the cart");
        }
    }
}
