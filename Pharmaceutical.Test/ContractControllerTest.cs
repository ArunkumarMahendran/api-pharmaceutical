
using Moq;
using NUnit.Framework;

using Pharmaceutical.BLL.IContractDetails;
using ToddPharmaceutical.Controllers;
using MODEL= Pharmaceutical.Common.Models;

namespace Pharmaceutical.Test
{
    [TestFixture]
    public class ContractControllerTest
    {
        private readonly MockRepository _mockRepository = new MockRepository(MockBehavior.Strict);
        private Mock<IContractDetail> _mockContractDetails;
        private ContractController _mockContract;

        [SetUp]
        public void Setup()
        {
            _mockContractDetails = _mockRepository.Create<IContractDetail>();
            _mockContract = new ContractController(_mockContractDetails.Object);
        }

        [Test]
        public void GetContractDetails_Return_ContractDetials()
        {
            //ARANGE            
            var moqContractDetails = new AutoBogus.AutoFaker<MODEL.ContractDetail>().Generate(10);
            
            _mockContractDetails.Setup(x => x.GetContractDetails())
                                .Returns(moqContractDetails);

            //ACT
            _mockContract.Get();

            //ASSERT
            _mockRepository.VerifyAll();
        }

        [Test]
        public void CreateContractDetail_With_ContractDetail_Return_ContractDetial()
        {
            //ARANGE            
            var moqContractDetail = new AutoBogus.AutoFaker<MODEL.ContractDetail>().Generate();

            _mockContractDetails.Setup(x => x.CreateContractDetails(moqContractDetail))
                                .Returns(moqContractDetail);

            //ACT
            _mockContract.Post(moqContractDetail);

            //ASSERT
            _mockRepository.VerifyAll();
        }

        [Test]
        public void UpdateContractDetail_With_ContractDetail_Return_ContractDetial()
        {
            //ARANGE            
            var moqContractDetail = new AutoBogus.AutoFaker<MODEL.ContractDetail>().Generate();

            _mockContractDetails.Setup(x => x.UpdateContractDetail(moqContractDetail))
                                .Returns(moqContractDetail);

            //ACT
            _mockContract.Put(moqContractDetail);

            //ASSERT
            _mockRepository.VerifyAll();
        }

        [Test]
        public void DeleteContractDetail_With_ContractDetail_Return_ContractDetial()
        {
            //ARANGE            
            var moqContractDetail = new AutoBogus.AutoFaker<MODEL.ContractDetail>().Generate();
            int id = moqContractDetail.Id;
            _mockContractDetails.Setup(x => x.DeleteContractDetail(id))
                                .Returns(moqContractDetail);

            //ACT
            _mockContract.Delete(id);

            //ASSERT
            _mockRepository.VerifyAll();
        }
    }
}