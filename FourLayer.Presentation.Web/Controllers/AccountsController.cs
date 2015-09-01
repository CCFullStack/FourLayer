using FourLayer.Presentation.Web.Models;
using FourLayer.Services;
using FourLayer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FourLayer.Presentation.Web.Controllers
{
    public class AccountsController : Controller
    {
        private AccountService _service;

        public AccountsController(AccountService service) {
            _service = service;
        }

        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        [HttpPost]
        public ActionResult Create(AccountDTO account)
        {
            try
            {
                _service.OpenAccount(account.Username, account.AccountType, account.Balance);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }

        // GET: Accounts/Transfer
        public ActionResult Transfer(string username) {

            var myAccounts = _service.ListAccounts(username);
            var allAccounts = _service.ListAccounts();

            var vm = new TransferViewModel();
            vm.allAccounts = allAccounts;
            vm.myAccounts = myAccounts;

            return View(vm);
        }

        // POST: Accounts/Transfer
        [HttpPost]
        public ActionResult Transfer(TransferPostViewModel transfer) {

            // Do verification...
            _service.TransferBalance(transfer.FromAccount, transfer.ToAccount, transfer.Amount);

            return RedirectToAction("Index");
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Accounts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Accounts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
