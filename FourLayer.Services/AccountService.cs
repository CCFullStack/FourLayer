using AutoMapper;
using FourLayer.Domain.Models;
using FourLayer.Infrastructure.Models;
using FourLayer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourLayer.Services {
    public class AccountService {

        private IRepository _repo;

        /*
        Open a new account
        Transfer money between accounts
        Get my balance
        Close an account
        */

        public AccountService(IRepository repo) {
            _repo = repo;
        }

        private string GenerateAccountNumber() {
            Random rand = new Random();
            long accountNumber = (long)(rand.NextDouble() * 9000000000L + 1000000000L);
            return accountNumber.ToString();
        }

        public IList<AccountDTO> ListAccounts() {

            var dtoList = new List<AccountDTO>();
            var accounts = _repo.Query<Account>().ToList();
            foreach (Account a in accounts) {
                dtoList.Add(Mapper.Map<AccountDTO>(a));
            }

            return dtoList;
        }

        public IList<AccountDTO> ListAccounts(string username) {

            var dtoList = new List<AccountDTO>();
            var accounts = (from account in _repo.Query<Account>()
                            where account.Username == username
                            select account).ToList();
            foreach (Account a in accounts) {
                dtoList.Add(Mapper.Map<AccountDTO>(a));
            }

            return dtoList;
        }

        public AccountDTO OpenAccount(string username, string accountType, decimal startingBalance) {
            Account account = new Account {
                Username = username,
                AccountType = accountType,
                Balance = startingBalance,
                AccountNumber = GenerateAccountNumber()
            };

            _repo.Add<Account>(account);
            _repo.SaveChanges();

            return Mapper.Map<AccountDTO>(account);
        }

        public void TransferBalance(string accountNumberFrom, string accountNumberTo, decimal balance) {

        }
    }
}
