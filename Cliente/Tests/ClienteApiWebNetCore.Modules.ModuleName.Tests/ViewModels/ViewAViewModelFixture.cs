﻿using ClienteApiWebNetCore.Modules.ModuleName.ViewModels;
using ClienteApiWebNetCore.Services.Interfaces;
using Moq;
using Prism.Regions;
using Xunit;

namespace ClienteApiWebNetCore.Modules.ModuleName.Tests.ViewModels
{
    public class ViewAViewModelFixture
    {
        Mock<IServicioClientes> _messageServiceMock;
        Mock<IRegionManager> _regionManagerMock;
        const string MessageServiceDefaultMessage = "Some Value";

        public ViewAViewModelFixture()
        {
            var messageService = new Mock<IServicioClientes>();
            //messageService.Setup(x => x.GetMessage()).Returns(MessageServiceDefaultMessage);
            _messageServiceMock = messageService;

            _regionManagerMock = new Mock<IRegionManager>();
        }

        [Fact]
        public void MessagePropertyValueUpdated()
        {
            var vm = new LoginViewModel(_regionManagerMock.Object, _messageServiceMock.Object);

            _messageServiceMock.Verify(x => x.GetMessage(), Times.Once);

            Assert.Equal(MessageServiceDefaultMessage, vm.Message);
        }

        [Fact]
        public void MessageINotifyPropertyChangedCalled()
        {
            var vm = new LoginViewModel(_regionManagerMock.Object, _messageServiceMock.Object);
            Assert.PropertyChanged(vm, nameof(vm.Message), () => vm.Message = "Changed");
        }
    }
}
