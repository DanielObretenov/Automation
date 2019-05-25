﻿using NUnit.Framework;
using PracticalTaskSeleniumProject.Helpers;
using PracticalTaskSeleniumProject.PracticalTaskSelenium.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticalTaskSeleniumProject.PracticalTaskSelenium.Tests
{
    [TestFixture]
    class AdminCategoryTests :BaseTest
    {
        string titleForProduct = "iPhone 6";
        string textForDescription = "This is a full description";
        string textForShortDescription = "This is a short description";
        string MultiActionDropDownDeactivate = "Deactivate";
        string MultiActionDropDownDelete = "Delete";

        [Test, Order(1)]
        [Category("Practice")]
        public void CreateProduct()
        {

            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();
            AdminLoginPage adminLoginPage = homePage.NavigateToAdminLogInPage();
            // driver.Navigate().GoToUrl("http://demo.vamshop.com/users/admin_login");
            //AdminLoginPage adminLoginPage = new AdminLoginPage(driver);
            AdminDashboardPage adminDashboardPage = adminLoginPage.LogInAsAdmin();
            AdminAllCategoriesPage adminAllCategoriesPage = adminDashboardPage.NavigateToAllCategoriesPage();
            AdminCreateOrEditProductPage adminCreateProductPage =  adminAllCategoriesPage.clickOnCreateNewButton();
            adminCreateProductPage.SelectOptionFromParentDropdown();
            adminCreateProductPage.AddTitle(titleForProduct);
            adminCreateProductPage.WriteDescription(textForDescription);
            adminCreateProductPage.WriteShortDescription(textForShortDescription);
            adminCreateProductPage.NavigateToDataTab();
            adminCreateProductPage.CheckNewProductInTheDataTab();
            adminCreateProductPage.SelectProductLabel();
            AdminCategoryPage adminCategoryPage = adminCreateProductPage.SubmitProduct();
            Assert.IsTrue(adminCategoryPage.IsNewProductCreated());
        }

        [Test, Order(2)]
        [Category("Practice")]
        public void EditProduct()
        {
            ProductTable table = new ProductTable(driver);
            AdminCreateOrEditProductPage adminEditProductPage = table.GetRowByTitle(titleForProduct).ClickOnTitle();
            adminEditProductPage.OpenAttributesTab();
            adminEditProductPage.SetAttributesValueToStorage16();
            //AdminCreateOrEditProductPage adminEditProductPage1 = new AdminCreateOrEditProductPage(driver);
            AdminCategoryPage adminCategoryPageAtribute = adminEditProductPage.SubmitProduct();
            Assert.IsTrue(adminCategoryPageAtribute.IsAlertForAttributesDisplayed());
        }
        [Test, Order(3)]
        [Category("Practice")]
        public void DeactivateProduct()
        {
            ProductTable table = new ProductTable(driver);
            AdminCategoryPage adminCategoryPage = new AdminCategoryPage(driver);
            table.GetRowByTitle(titleForProduct).ClickOnCheckbox();
            adminCategoryPage.DeactivateFromMultiActionDropDown(MultiActionDropDownDeactivate);
            table = adminCategoryPage.AgreeToDisableProductAlert();
            Thread.Sleep(2000);
            Assert.IsTrue(adminCategoryPage.IsProductDeactivated());
           
        }
 
        
    }
}
