using Moq;
//using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinApp.Pages.MVVM.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XamarinApp.Tests
{
    //[TestFixture()]
    [TestClass]
    public class ContactViewModelTests
    {
        private ContactsPageViewModel _viewModel;
        private Mock<IPageService> _pageService;
        private Mock<IContactStore> _contactStore;

        //[SetUp]
        [TestInitialize]
        public void Setup()
        {
            _pageService = new Mock<IPageService>();
            _contactStore = new Mock<IContactStore>();
            _viewModel = new ContactsPageViewModel(_contactStore.Object, _pageService.Object);
        }

        [TestMethod]
        public void AddContact_WhenCalled_The()
        {
            _viewModel.AddContactCommand.Execute(null);
            Assert.AreEqual(1, _viewModel.Contacts.Count);
        }

        [TestMethod]
        public void SelectPlaylist_WhenCalled_TheSelectedItemShouldBeDeselected()
        {
            var contact = new ContactViewModel();
            _viewModel.Contacts.Add(contact);

            _viewModel.SelectContactCommand.Execute(contact);

            Assert.IsNull(_viewModel.SelectedContact);
        }

    }
}
