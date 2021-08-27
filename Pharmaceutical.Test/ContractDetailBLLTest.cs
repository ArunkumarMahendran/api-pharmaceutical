using Moq;
using NUnit.Framework;
using Pharmaceutical.Abstraction.IRepository;
using Pharmaceutical.BLL.ContractDetails;
using System.Linq;
using MODEL = Pharmaceutical.Common.Models;

namespace Pharmaceutical.Test
{
    [TestFixture]
    public class ContractDetailBLLTest
    {
        private readonly MockRepository _mockRepository = new MockRepository(MockBehavior.Strict);
        private Mock<IContractRepository> _mockContractRepository;
        private ContractDetail _mockContractDetail;

        [SetUp]
        public void Setup()
        {
            var mockHttpContxt = MockHttpContext.GetHttpContext();
            _mockContractRepository = _mockRepository.Create<IContractRepository>();
            _mockContractDetail = new ContractDetail(_mockContractRepository.Object, mockHttpContxt.Object);
        }

        [Test]
        public void CreateContractDetail_With_ContractDetail_Return_ContractDetail()
        {
            //ARANGE            
            var moqContractDetail = new AutoBogus.AutoFaker<MODEL.ContractDetail>().Generate();

            _mockContractRepository.Setup(x => x.CreateContractDetails(moqContractDetail))
                                .Returns(moqContractDetail);

            //ACT
            _mockContractDetail.CreateContractDetails(moqContractDetail);

            //ASSERT
            _mockRepository.VerifyAll();
        }

        [Test]
        public void DeleteContractDetail_With_id_Return_ContractDetail()
        {
            //ARANGE            
            var moqContractDetail = new AutoBogus.AutoFaker<MODEL.ContractDetail>().Generate();
            int id = moqContractDetail.Id;
            _mockContractRepository.Setup(x => x.DeleteContractDetail(id))
                                .Returns(moqContractDetail);

            //ACT
            _mockContractDetail.DeleteContractDetail(id);

            //ASSERT
            _mockRepository.VerifyAll();
        }

        [Test]
        public void GetContractDetail__Return_ContractDetils()
        {
            //ARANGE            
            var moqContractDetail = new AutoBogus.AutoFaker<MODEL.ContractDetail>().Generate(10);           
            _mockContractRepository.Setup(x => x.GetContractDetails())
                                .Returns(moqContractDetail.AsQueryable());

            //ACT
            _mockContractDetail.GetContractDetails();

            //ASSERT
            _mockRepository.VerifyAll();
        }

        [Test]
        public void UpdateContractDetail__Return_ContractDetils()
        {
            //ARANGE            
            var moqContractDetail = new AutoBogus.AutoFaker<MODEL.ContractDetail>().Generate();
            _mockContractRepository.Setup(x => x.UpdateContractDetail(moqContractDetail))
                                .Returns(moqContractDetail);

            //ACT
            _mockContractDetail.UpdateContractDetail(moqContractDetail);

            //ASSERT
            _mockRepository.VerifyAll();
        }
    }
}
