using StockAssignment.ServiceContracts;
using StockAssignment.Service;
using StockAssignment.ServiceContracts.DTO;
using System;
namespace StockAssignment.UnitTesting;

public class StocksServiceTest
{
    private readonly IStocksService _stocksService;
    public StocksServiceTest()
    {
        _stocksService = new StocksService();
    }
    #region StocksService.CreateBuyOrder():
    [Fact]
    //When you supply BuyOrderRequest as null, it should throw ArgumentNullException.
    public async Task CreateBuyOrder_BuyOrderRequestIsNull()
    {
        //arrange
        BuyOrderRequest? buyOrderRequest = null;

        //assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            //actions
            BuyOrderResponse buyOrderResponse = await _stocksService.CreateBuyOrder(buyOrderRequest);
        });
    }
    [Fact]
    //When you supply buyOrderQuantity as 0 (as per the specification, minimum is 1), it should throw ArgumentException.
    public async Task CreateBuyOrder_BuyOrderQuantityIsZero()
    {
        BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
        {
            StockName = "Appple Inc.",
            StockSymbol = "AAPL",
            Price = 226.37,
            Quantity = 0,
            DateAndTimeOfOrder = DateTime.Parse("2000-12-31"),
        };

        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            BuyOrderResponse buyOrderResponse = await _stocksService.CreateBuyOrder(buyOrderRequest);
        });
    }
    [Fact]
    // When you supply buyOrderQuantity as 100001 (as per the specification, maximum is 100000), it should throw ArgumentException.
    public async Task CreateBuyOrder_BuyOrderQuantityIsExceed()
    {
        BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
        {
            StockName = "Appple Inc.",
            StockSymbol = "AAPL",
            Price = 226.37,
            Quantity = 100001,
            DateAndTimeOfOrder = DateTime.Parse("2000-12-31"),
        };

        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            BuyOrderResponse buyOrderResponse = await _stocksService.CreateBuyOrder(buyOrderRequest);
        });
    }

    [Fact]
    // When you supply buyOrderPrice as 0 (as per the specification, minimum is 1), it should throw ArgumentException.
    public async Task CreateBuyOrder_buyOrderPriceIsZero()
    {
        BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
        {
            StockName = "Appple Inc.",
            StockSymbol = "AAPL",
            Price = 0,
            Quantity = 200,
            DateAndTimeOfOrder = DateTime.Parse("2000-12-31"),
        };

        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            BuyOrderResponse buyOrderResponse = await _stocksService.CreateBuyOrder(buyOrderRequest);
        });
    }

    [Fact]
    //  When you supply buyOrderPrice as 10001 (as per the specification, maximum is 10000), it should throw ArgumentException.
    public async Task CreateBuyOrder_buyOrderPriceIsExceed()
    {
        BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
        {
            StockName = "Appple Inc.",
            StockSymbol = "AAPL",
            Price = 100001,
            Quantity = 200,
            DateAndTimeOfOrder = DateTime.Parse("2000-12-31"),
        };

        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            BuyOrderResponse buyOrderResponse = await _stocksService.CreateBuyOrder(buyOrderRequest);
        });
    }

    [Fact]
    //  When you supply stock symbol=null (as per the specification, stock symbol can't be null), it should throw ArgumentException.
    public async Task CreateBuyOrder_StockSymbolIsNull()
    {
        BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
        {
            StockName = "Appple Inc.",
            StockSymbol = null,
            Price = 200,
            Quantity = 200,
            DateAndTimeOfOrder = DateTime.Parse("2000-12-31"),
        };

        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            BuyOrderResponse buyOrderResponse = await _stocksService.CreateBuyOrder(buyOrderRequest);
        });
    }

    [Fact]
    // When you supply dateAndTimeOfOrder as "1999-12-31" (YYYY-MM-DD) - (as per the specification, it should be equal or newer date than 2000-01-01), it should throw ArgumentException.
    public async Task CreateBuyOrder_DateAndTimeOfOrderNotValid()
    {
        BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
        {
            StockName = "Appple Inc.",
            StockSymbol = "AAPL",
            Price = 200,
            Quantity = 200,
            DateAndTimeOfOrder = DateTime.Parse("1999-12-31"),

        };

        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            BuyOrderResponse buyOrderResponse = await _stocksService.CreateBuyOrder(buyOrderRequest);
        });
    }
    [Fact]
    //If you supply all valid values, it should be successful and return an object of BuyOrderResponse type with auto-generated BuyOrderID(guid).
    public async Task CreateBuyOrder_ProperBuyOrderDetails()
    {
        BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
        {
            StockName = "Appple Inc.",
            StockSymbol = "AAPL",
            Price = 200,
            Quantity = 200,
            DateAndTimeOfOrder = DateTime.Parse("2000-12-31"),

        };
        BuyOrderResponse buyOrderResponse = await _stocksService.CreateBuyOrder(buyOrderRequest);
        Assert.True(buyOrderResponse.BuyOrderID != Guid.Empty);
    }


    #endregion

    #region StockService.CreateSellOrder():
    [Fact]
    //When you supply SellOrderRequest as null, it should throw ArgumentNullExceiption.
    public async Task CreateSellOrder_SellOrderRequestIsNull()
    {
        //arrange
        SellOrderRequest? sellOrderRequest = null;

        //assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            //actions
            SellOrderResponse sellOrderResponse = await _stocksService.CreateSellOrder(sellOrderRequest);
        });
    }
    [Fact]
    //When you supply sellOrderQuantity as 0 (as per the specification, minimum is 1), it should throw ArgumentException
    public async Task CreateSellOrder_sellOrderQuantityisZero()
    {
        SellOrderRequest sellOrderRequest = new SellOrderRequest()
        {
            StockName = "Appple Inc.",
            StockSymbol = "AAPL",
            Price = 226.37,
            Quantity = 0,
            DateAndTimeOfOrder = DateTime.Parse("2000-12-31"),
        };

        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            SellOrderResponse sellOrderResponse = await _stocksService.CreateSellOrder(sellOrderRequest);
        });
    }
    [Fact]
    //When you supply sellOrderQuantity as 100001 (as per the specification, maximum is 100000), it should throw ArgumentException.
    public async Task CreateSellOrder_sellOrderQuantityisExceed()
    {
        SellOrderRequest sellOrderRequest = new SellOrderRequest()
        {
            StockName = "Appple Inc.",
            StockSymbol = "AAPL",
            Price = 226.37,
            Quantity = 100001,
            DateAndTimeOfOrder = DateTime.Parse("2000-12-31"),
        };

        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            SellOrderResponse sellOrderResponse = await _stocksService.CreateSellOrder(sellOrderRequest);
        });
    }
    [Fact]
    //When you supply sellOrderPrice as 0 (as per the specification, minimum is 1), it should throw ArgumentException.
    public async Task CreateSellOrder_sellOrderPriceIsZero()
    {
        SellOrderRequest sellOrderRequest = new SellOrderRequest()
        {
            StockName = "Appple Inc.",
            StockSymbol = "AAPL",
            Price = 0,
            Quantity = 1000,
            DateAndTimeOfOrder = DateTime.Parse("2000-12-31"),
        };

        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            SellOrderResponse sellOrderResponse = await _stocksService.CreateSellOrder(sellOrderRequest);
        });
    }
    [Fact]
    //When you supply sellOrdderPrice as 100001 (as per the specification, maximum is 10000), it should trhow ArgumentException.
    public async Task CreateSellOrder_sellOrderPrideExceed()
    {
        SellOrderRequest sellOrderRequest = new SellOrderRequest()
        {
            StockName = "Appple Inc.",
            StockSymbol = "AAPL",
            Price = 100001,
            Quantity = 1000,
            DateAndTimeOfOrder = DateTime.Parse("1999-12-31"),
        };

        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            SellOrderResponse sellOrderResponse = await _stocksService.CreateSellOrder(sellOrderRequest);
        });
    }
    //When you supply dateAndTimeOfOrder as "1999-12-31" (YYYY-MM-DD) - (as per the specification, it should be equal or newer date than 2000-01-01), it should throw ArgumentException.
    [Fact]
    public async Task CreateSellOrder_DateAndTimeOfOrderIsNotValid()
    {
        SellOrderRequest sellOrderRequest = new SellOrderRequest()
        {
            StockName = "Appple Inc.",
            StockSymbol = "AAPL",
            Price = 2323,
            Quantity = 1000,
            DateAndTimeOfOrder = DateTime.Parse("1999-12-1"),
        };
        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            SellOrderResponse sellOrderResponse = await _stocksService.CreateSellOrder(sellOrderRequest);
        });
    }

    [Fact]
    //If you supply all valid values, it should be successful and return an object of SellOrderResponse type with auto-generated SellOrderID(guid).
    public async Task CreateSellOrder_Valid()
    {
        SellOrderRequest sellOrderRequest = new SellOrderRequest()
        {
            StockName = "Appple Inc.",
            StockSymbol = "AAPL",
            Price = 2323,
            Quantity = 1000,
            DateAndTimeOfOrder = DateTime.Parse("2000-12-31"),
        };

        SellOrderResponse sellOrderResponse = await _stocksService.CreateSellOrder(sellOrderRequest);
        Assert.True(sellOrderResponse.SellOrderID != Guid.Empty);
    }
    #endregion

    #region StocsService.GetAllBuyOrders():
    [Fact]
    //When you invoke the method, by default,the return list should be empty
    public async Task GetAllBuyOrders_IsEmpty()
    {
        //action
        List<BuyOrderResponse> buyOrderResponses = await _stocksService.GetBuyOrders();

        Assert.Empty(buyOrderResponses);
    }
    [Fact]
    //When you first add few buy orders using CreateBuyOrder() method and  then invoke GetAllBuyOrders() method, the returned list should contain all the same buy orders.
    public async Task GetAllBuyOrders_AddFewBuyOrders()
    {
        List<BuyOrderRequest> buyOrderRequests = new List<BuyOrderRequest>()
        {
            new BuyOrderRequest()
            {
                StockName = "Appple Inc.",
                StockSymbol = "AAPL",
                Price = 226.37,
                Quantity = 232,
                DateAndTimeOfOrder = DateTime.Parse("2000-12-31"),
            },
            new BuyOrderRequest()
            {
                StockName = "Microsoft Inc.",
                StockSymbol = "MSFT",
                Price = 226.37,
                Quantity = 232,
                DateAndTimeOfOrder = DateTime.Parse("2000-12-31"),
            }
        };
        List<BuyOrderResponse> buyOrderResponses = new List<BuyOrderResponse>();

        foreach (var buyOrderRequest in buyOrderRequests)
        {
            BuyOrderResponse buyOrderResponse = await _stocksService.CreateBuyOrder(buyOrderRequest);
            buyOrderResponses.Add(buyOrderResponse);
            List<BuyOrderResponse> getAllOrderResponses = await _stocksService.GetBuyOrders();
            Assert.Contains(buyOrderResponse, getAllOrderResponses);
        }

    }

    #endregion

    #region StocksService.GetAllSellOrders():
    [Fact]
    //When you invoke the method, by default,the return list should be empty
    public async Task GetAllSellOrders_IsEmpty()
    {
        List<SellOrderResponse> sellOrderResponses =  await _stocksService.GetSellOrders();
        Assert.Empty(sellOrderResponses);
    }
    [Fact]
    //When you first add few sell orders using CreateSellOrder() method and  then invoke GetAllSellOrders() method, the returned list should contain all the same buy orders.
    public async Task GetAllSellOrders_AddFewSellOrders()
    {
        List<SellOrderRequest> sellOrderRequests = new List<SellOrderRequest>()
        {
            new SellOrderRequest()
            {
                StockName = "Appple Inc.",
                StockSymbol = "AAPL",
                Price = 226.37,
                Quantity = 232,
                DateAndTimeOfOrder = DateTime.Parse("2000-12-31"),
            },
            new SellOrderRequest()
            {
                StockName = "Microsoft Inc.",
                StockSymbol = "MSFT",
                Price = 226.37,
                Quantity = 232,
                DateAndTimeOfOrder = DateTime.Parse("2000-12-31"),
            }
        };
        List<SellOrderResponse> sellOrderResponses = new List<SellOrderResponse>();

        foreach (var sellOrderRequest in sellOrderRequests)
        {
            SellOrderResponse sellOrderResponse = await _stocksService.CreateSellOrder(sellOrderRequest);
            sellOrderResponses.Add(sellOrderResponse);
            List<SellOrderResponse> getAllOrderResponses = await _stocksService.GetSellOrders();
            Assert.Contains(sellOrderResponse, getAllOrderResponses);
        }
    }
    #endregion
}