using LojaQuadrinhos.BLL.Interfaces;
using LojaQuadrinhos.BLL.Service;
using LojaQuadrinhos.DataAccess.Repository;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace LojaQuadrinhosValuu.BLL.Tests
{
    [TestClass]
    public class PurchaseServiceTests
    {

        //no need to initialize for now
        IPurchaseRepository _repo;
        ICustomerRepository _custRepo;
        IQuadrinhoService _quadService;

        [TestInitialize]
        public void TestInitialize()
        {
            //
        }


        [TestMethod]
        public void QuadrinhoQuantityLessThanBuyingQuantity_ReturnsFalse()
        {
            //arrange
            PurchaseService ps = new PurchaseService(_repo,_custRepo,_quadService);

            //act
            var result= ps.CheckQuadrinhoAvaiability(10,3);

            //assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void QuadrinhoQuantityIsEqualThanBuyingQuantity_ReturnsTrue()
        {
            //arrange
            PurchaseService ps = new PurchaseService(_repo,_custRepo,_quadService);
            
            //act
            var result= ps.CheckQuadrinhoAvaiability(1,1);

            //assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void QuadrinhoQuantityIsMoreThanBuyingQuantity_ReturnsTrue()
        {
            //arrange
            PurchaseService ps = new PurchaseService(_repo,_custRepo,_quadService);

            //act
            var result= ps.CheckQuadrinhoAvaiability(10,30);

            //assert
            Assert.IsTrue(result);
        }

    }
}
