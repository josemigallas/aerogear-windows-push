﻿using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace AeroGear.Push
{
    [TestClass]
    public class RegistrationTest
    {
        [TestMethod]
        public void ShouldRegister()
        {
            //given
            var httpClient = new MockUPSHttpClient();
            Registration registration = new WnsRegistration();

            //when
            registration.Register(new PushConfig(), httpClient);

            //then
            Assert.IsTrue(httpClient.installation.deviceToken != null);
        }
    }

    public class MockUPSHttpClient: IUPSHttpClient 
    {
        public Task<HttpStatusCode> register(Installation installation)
        {
            this.installation = installation;
            return Task.Run(() => HttpStatusCode.OK);
        }

        public Installation installation { get; set; }
    }
}
