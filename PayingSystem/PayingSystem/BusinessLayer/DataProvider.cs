// <copyright file="DataProvider.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.BusinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using PayingSystem.BusinessLayer.DTO_s;
    using PayingSystem.BusinessLayer.RegistrationData;
    using PayingSystem.DataAccessLayer.Implementations;
    using PayingSystem.DataAccessLayer.Models;

    /// <summary>
    /// A class that provides a connection between DAL-BL-PL.
    /// </summary>
    public class DataProvider
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly MD5 _md5hash;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataProvider"/> class.
        /// </summary>
        /// <param name="unitOfWork">unit of work.</param>
        public DataProvider(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _md5hash = MD5.Create();
        }

    #region ConvertToDTO

        /// <summary>
        /// Convert Account into AccountDTO.
        /// </summary>
        /// <param name="account">Account object.</param>
        /// <returns>AccountDTO object.</returns>
        public AccountDTO ConvertToDTO(Account account)
        {
            return new AccountDTO
            {
                CardNumber = account.CardNumber,
                HashPassword = account.HashPassword,
                Expire = account.Expire,
                Balance = account.Balance,
                Client = ConvertToDTO(account.Client),
                ClientId = account.ClientId,
            };
        }

        /// <summary>
        /// Convert Address into AddressDTO.
        /// </summary>
        /// <param name="address">Address object.</param>
        /// <returns>AddressDTO.</returns>
        public AddressDTO ConvertToDTO(Address address)
        {
            return new AddressDTO
            {
                Country = address.Country,
                City = address.City,
                Street = address.Street,
                House = address.House,
                Flat = address.Flat,
            };
        }

        /// <summary>
        /// Convert Client into ClientDTO.
        /// </summary>
        /// <param name="client">Client object.</param>
        /// <returns>ClientDTO object.</returns>
        public ClientDTO ConvertToDTO(Client client)
        {
            return new ClientDTO
            {
                ClientId = client.ClientId,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,
                Address = ConvertToDTO(client.Address),
                AddressId = client.AddressId,
            };
        }

        /// <summary>
        /// Convert Shop into ShopDTO.
        /// </summary>
        /// <param name="shop">Shop object.</param>
        /// <returns>ShopDTO object.</returns>
        public ShopDTO ConvertToDTO(Shop shop)
        {
            var i = new ShopDTO
            {
                ShopName = shop.ShopName,
                CardNumber = shop.CardNumber,
                ProductLists = ConvertToDTO(shop.ProductLists),
                AddressId = shop.AddressId,
                Address = ConvertToDTO(shop.Address),
            };

            return i;
        }

        /// <summary>
        /// Convert ProductList into ProductListDTO.
        /// </summary>
        /// <param name="productList">Productlist object.</param>
        /// <returns>ProductListDTO object.</returns>
        public ProductListDTO ConvertToDTO(ProductList productList)
        {
            return new ProductListDTO
            {
                ProductListId = productList.ProductListId,
                ShopName = productList.ShopName,
                AddressId = productList.AddressId,
                Products = ConvertToDTO(productList.Products),
            };
        }

        /// <summary>
        /// Convert Product into ProductDTO.
        /// </summary>
        /// <param name="product">Product object.</param>
        /// <returns>ProductDTO object.</returns>
        public ProductDTO ConvertToDTO(Product product)
        {
            return new ProductDTO
            {
                ProductName = product.ProductName,
                Price = product.Price,
                ProductId = product.ProductId,
                ProductListId = product.ProductListId,
            };
        }

        /// <summary>
        /// Convert list of products into list of ProductDTO's.
        /// </summary>
        /// <param name="products">list of products.</param>
        /// <returns>list of productDTO.</returns>
        public List<ProductDTO> ConvertToDTO(ICollection<Product> products)
        {
            List<ProductDTO> productsDTO = new List<ProductDTO>();
            foreach (Product p in products)
            {
                productsDTO.Add(ConvertToDTO(p));
            }

            return productsDTO;
        }

        /// <summary>
        /// Convert list of ProductList's into list of ProductListDTO's.
        /// </summary>
        /// <param name="products">List of ProductList's.</param>
        /// <returns>List of ProductListDTO.</returns>
        public List<ProductListDTO> ConvertToDTO(ICollection<ProductList> products)
        {
            List<ProductListDTO> productsDTO = new List<ProductListDTO>();
            foreach (ProductList p in products)
            {
                productsDTO.Add(ConvertToDTO(p));
            }

            return productsDTO;
        }
        #endregion

    #region Create

        /// <summary>
        /// Creates product.
        /// </summary>
        /// <param name="productListId">ProductList id.</param>
        /// <returns>ProductDTO.</returns>
        public ProductDTO CreateProduct(int productListId)
        {
            Console.Clear();
            Console.Write("Product Name:");
            string productName = Console.ReadLine();
            Console.Write("Product Price:");
            double productPrice = TryDoubleParse("price");
            return new ProductDTO
            {
                ProductName = productName,
                Price = productPrice,
                ProductListId = productListId,
            };
        }

        /// <summary>
        /// CreateAddress.
        /// </summary>
        /// <returns>AddressDTO.</returns>
        public AddressDTO CreateAddress()
        {
            Address address = new AddressRegistrationData().Register();
            _unitOfWork.AddressRepository.Add(address);
            _unitOfWork.SaveChanges();
            return new AddressDTO
            {
                Country = address.Country,
                City = address.City,
                Street = address.Street,
                House = address.House,
                Flat = address.Flat,
                Id = address.Id,
            };
        }
        #endregion

    #region Add Functions

        /// <summary>
        /// Add Address to database.
        /// </summary>
        /// <param name="addressDTO">AddressDTO.</param>
        /// <param name="addressId">AddressId.</param>
        public void AddNewAddress(AddressDTO addressDTO, out int addressId)
        {
            Address address = new Address
            {
                Country = addressDTO.Country,
                City = addressDTO.City,
                Street = addressDTO.Street,
                House = addressDTO.House,
                Flat = addressDTO.Flat,
            };
            _unitOfWork.AddressRepository.Add(address);
            _unitOfWork.SaveChanges();
            addressId = address.Id;
        }

        /// <summary>
        /// Add Client to database.
        /// </summary>
        /// <param name="clientDTO">ClientDTO.</param>
        /// <param name="addressId">AddressId.</param>
        /// <param name="clientId">ClientId.</param>
        public void AddNewClient(ClientDTO clientDTO, int addressId, out int clientId)
        {
            Client client = new Client
            {
                FirstName = clientDTO.FirstName,
                LastName = clientDTO.LastName,
                Email = clientDTO.Email,
                PhoneNumber = clientDTO.PhoneNumber,
                AddressId = addressId,
            };

            _unitOfWork.ClientRepository.Add(client);
            _unitOfWork.SaveChanges();
            clientId = client.ClientId;
        }

        /// <summary>
        /// Add Account to database.
        /// </summary>
        /// <param name="accountDTO">AccountDTO.</param>
        /// <param name="clientId">ClientId.</param>
        public void AddNewAccount(AccountDTO accountDTO, int clientId)
        {
            Account account = new Account
            {
                CardNumber = accountDTO.CardNumber,
                ClientId = clientId,
                Expire = accountDTO.Expire,
                Balance = accountDTO.Balance,
                HashPassword = accountDTO.HashPassword,
            };

            _unitOfWork.AccountRepository.Add(account);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Add Product to database.
        /// </summary>
        /// <param name="productDTO">ProductDTO.</param>
        /// <param name="shopDTO">ShopDTO.</param>
        public void AddNewProduct(ProductDTO productDTO, ShopDTO shopDTO)
        {
            Product product = new Product
            {
                ProductName = productDTO.ProductName,
                Price = productDTO.Price,
                ProductListId = productDTO.ProductListId,
            };

            _unitOfWork.ProductRepository.Add(product);
            _unitOfWork.SaveChanges();
            productDTO.ProductId = product.ProductId;
            shopDTO.ProductLists.First().Products.Add(productDTO);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Add Shop to database.
        /// </summary>
        /// <param name="shopDTO">ShopDTO.</param>
        public void AddNewShop(ShopDTO shopDTO)
        {
            Shop shop = new Shop
            {
                ShopName = shopDTO.ShopName,
                CardNumber = shopDTO.CardNumber,
                AddressId = shopDTO.AddressId,
            };

            _unitOfWork.ShopRepository.Add(shop);
            _unitOfWork.SaveChanges();

            ProductList productList = new ProductList
            {
                ShopName = shopDTO.ShopName,
                AddressId = shopDTO.AddressId,
            };

            _unitOfWork.ProductListRepository.Add(productList);
            _unitOfWork.SaveChanges();
        }
        #endregion

    #region Delete

        /// <summary>
        /// Delete choosed product from database.
        /// </summary>
        /// <param name="shopDTO">ShopDTO.</param>
        public void DeleteProduct(ShopDTO shopDTO)
        {
            Console.Clear();
            Console.WriteLine("Choose product to delete");
            var entity = shopDTO.ProductLists.First().Products.ToList()[Convert.ToInt16(Console.ReadKey().KeyChar) - 49];
            int productId = entity.ProductId;
            _unitOfWork.ProductRepository.Delete(productId);
            shopDTO.ProductLists.First().Products.Remove(entity);
            _unitOfWork.SaveChanges();
        }
        #endregion

    #region Update/Send Money

        /// <summary>
        /// Change balance by value in specified account.
        /// </summary>
        /// <param name="accountDTO">AccountDTO.</param>
        /// <param name="value">value.</param>
        public void UpdateBalance(AccountDTO accountDTO, double value)
        {
            Account account = GetAccount(accountDTO.CardNumber);
            if (account != null)
            {
                account.Balance += value;
                accountDTO.Balance += value;
                _unitOfWork.AccountRepository.Update(account);
                _unitOfWork.SaveChanges();
            }
        }

        /// <summary>
        /// Send money to account by card number.
        /// </summary>
        /// <param name="accountDTO1">AccountDTO sender.</param>
        /// <param name="value">value.</param>
        public void SendMoney(AccountDTO accountDTO1, double value)
        {
            int recepientCard = TryParseCard("recepient");
            UpdateBalance(accountDTO1, -value);
            Account recepientAccount = GetAccount(recepientCard);
            recepientAccount.Balance += value;
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Send money to account by cardnumber.
        /// </summary>
        /// <param name="accountDTO1">AccountDTO sender.</param>
        /// <param name="shopCardNumber">Card number.</param>
        /// <param name="value">value.</param>
        public void SendMoney(AccountDTO accountDTO1, int shopCardNumber, double value)
        {
            int recepientCard = shopCardNumber;
            UpdateBalance(accountDTO1, -value);
            Account recepientAccount = GetAccount(recepientCard);
            recepientAccount.Balance += value;
            _unitOfWork.SaveChanges();
        }

        #endregion

    #region Getters

        /// <summary>
        /// Get Account by card number.
        /// </summary>
        /// <param name="cardnumber">card number.</param>
        /// <returns>Account.</returns>
        private Account GetAccount(int cardnumber) => _unitOfWork.AccountRepository.Get(cardnumber);

        /// <summary>
        /// Get shops whith such cardnumber.
        /// </summary>
        /// <param name="cardnumber">Cardnumber.</param>
        /// <returns>List of shops DTO.</returns>
        public List<ShopDTO> GetShopsForAccount(int cardnumber)
        {
            List<ShopDTO> shopDTOs = new List<ShopDTO>();
            foreach (var i in _unitOfWork.ShopRepository.Get(p => p.CardNumber == cardnumber))
            {
                shopDTOs.Add(ConvertToDTO(i));
            }

            return shopDTOs;
        }

        /// <summary>
        /// Choose Shop from list.
        /// </summary>
        /// <returns>ShopDTO.</returns>
        public ShopDTO ChooseShopByUser()
        {
            Console.Clear();
            int count = 1;
            IEnumerable<Shop> shops = _unitOfWork.ShopRepository.Get();
            foreach (var i in shops)
            {
                Console.WriteLine($"{count++}){i.PrintBase()}");
            }

            Console.WriteLine("Choose Shop");
            List<ShopDTO> shopsDTO = new List<ShopDTO>();
            foreach (var i in shops)
            {
                shopsDTO.Add(ConvertToDTO(i));
            }

            int index = TryIntParse();
            if (index == -1)
            {
                return ChooseShopByUser();
            }
            else
            {
                return shopsDTO[index-1];
            }
        }

        /// <summary>
        /// Choose from list of your shops.
        /// </summary>
        /// <param name="cardnumber">cardnumber.</param>
        /// <returns>ShopDTO.</returns>
        public ShopDTO ChooseShopByOwner(int cardnumber)
        {
            Console.Clear();
            int count = 1;
            List<ShopDTO> shopsDTO = GetShopsForAccount(cardnumber);
            foreach (var i in shopsDTO)
            {
                Console.WriteLine($"{count++}){i.PrintBase()}");
            }

            int index = TryIntParse();
            if (index == -1)
            {
                return ChooseShopByOwner(cardnumber);
            }
            else
            {
                return shopsDTO[index-1];
            }
        }
        #endregion

    #region IsBoolFunctions

        /// <summary>
        /// Check if there is shop with such cardnumber in database.
        /// </summary>
        /// <param name="cardnumber">Cardnumber.</param>
        /// <returns>true/false.</returns>
        public bool IsHaveShop(int cardnumber)
        {
            return _unitOfWork.ShopRepository.IsHaveShop(cardnumber);
        }

        /// <summary>
        /// Check if there is acoount wiith such cardnumber.
        /// </summary>
        /// <param name="cardnumber">Cardnumber.</param>
        /// <returns>true/false.</returns>
        public bool IsInBase(int cardnumber) => GetAccount(cardnumber) != null;
        #endregion

    #region Login/Registration

        /// <summary>
        /// Log into account.
        /// </summary>
        /// <returns>AccountDTO.</returns>
        public AccountDTO Login()
        {
            int card = TryParseCard("your");
            if (!IsInBase(card))
            {
                Console.WriteLine("There is no account with such cardnumber,press Enter and try again or press 0 to register");

                if (Console.ReadKey().KeyChar == '0')
                {
                    AccountRegistrationData registrationData = new AccountRegistrationData(this);
                    registrationData.Register();
                    return Login();
                }

                Console.Clear();
                return Login();
            }
            else
            {
                Account account = GetAccount(card);
                Console.Write("Password:");
                string password = TryIntParse("password").ToString();
                using (MD5 md5Hash = MD5.Create())
                {
                    if (VerifyHash(password, account.HashPassword))
                    {
                        return ConvertToDTO(account);
                    }
                    else
                    {
                        Console.WriteLine("Wrong Password :(");
                        Console.ReadKey();
                        return Login();
                    }
                }
            }
        }

        /// <summary>
        /// Start registration process.
        /// </summary>
        public void AccountRegistration()
        {
            AccountRegistrationData data = new AccountRegistrationData(this);
            data.Register();
        }

        /// <summary>
        /// Strat registration process.
        /// </summary>
        /// <param name="cardnumber">cardnumber.</param>
        public void ShopRegistration(int cardnumber)
        {
            ShopRegistrationData data = new ShopRegistrationData(this);
            AddNewShop(data.Register(cardnumber));
        }
        #endregion

    #region Hashing

        /// <summary>
        /// Get hased password.
        /// </summary>
        /// <param name="input">user password.</param>
        /// <returns>Heshed password.</returns>
        public string GetHash(string input)
        {
            byte[] data = _md5hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        /// <summary>
        /// Check if password input equals to password in database.
        /// </summary>
        /// <param name="input">user password.</param>
        /// <param name="hash">hash from database.</param>
        /// <returns>true/false.</returns>
        public bool VerifyHash(string input, string hash)
        {
            string hashOfInput = GetHash(input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (comparer.Compare(hashOfInput, hash) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    #region Parsing

        /// <summary>
        /// Parse input int.
        /// </summary>
        /// <param name="details">what this value mean.</param>
        /// <returns>value.</returns>
        public int TryIntParse(string details)
        {
            Console.Clear();
            Console.Write($"Enter {details}:");
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine($"Write {details} in correct form please");
                Console.ReadKey();
                return TryIntParse(details);
            }
        }

        /// <summary>
        /// Parse int in menu's.
        /// </summary>
        /// <returns>number in menu.</returns>
        public int TryIntParse()
        {
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine($"Choose from the list");
                Console.ReadKey();
                return -1;
            }
        }

        /// <summary>
        /// Parse input double.
        /// </summary>
        /// <param name="details">what this value mean.</param>
        /// <returns>value.</returns>
        public double TryDoubleParse(string details)
        {
            Console.Clear();
            Console.Write($"Enter {details}:");
            try
            {
                return Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine($"Write {details} in correct form please");
                Console.ReadKey();
                return TryDoubleParse(details);
            }
        }

        /// <summary>
        /// Parse input card number.
        /// </summary>
        /// <param name="details">whoom card it is.</param>
        /// <returns>cardnumber.</returns>
        public int TryParseCard(string details)
        {
            Console.Clear();
            Console.Write($"Enter {details} card number:");
            try
            {
                int card = Convert.ToInt32(Console.ReadLine());
                if (card < 100000000 || card > 1000000000)
                {
                    Console.WriteLine("Write card in correct form please");
                    Console.ReadKey();
                    return TryParseCard(details);
                }
                else
                {
                    return card;
                }
            }
            catch
            {
                Console.WriteLine("Write card in correct form please");
                Console.ReadKey();
                return TryParseCard(details);
            }
        }

        #endregion
    }
}
