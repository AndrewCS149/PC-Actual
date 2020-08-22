using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Services
{
    public class PaymentRepository : IPayment
    {
        private readonly IConfiguration _config;

        public PaymentRepository(IConfiguration config)
        {
            _config = config;
        }

        // TODO: summary comment
        public string Run()
        {
            // type of environment
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            // setup merchant account credentials
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new AuthorizeNet.Api.Contracts.V1.merchantAuthenticationType()
            {
                name = _config["AuthorizeLoginId"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _config["AuthorizeTransactionKey"]
            };

            // TODO: create list of pre defined credit card numbers
            // create card we want on file
            var creditCard = new creditCardType
            {
                cardNumber = "8675309867530900",
                expirationDate = "0722",
                cardCode = "123"
            };

            customerAddressType billingAddress = GetBillingAddress(3);

            var paymentType = new paymentType { Item = creditCard };

            var transRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = 150.75M,
                payment = paymentType,
                billTo = billingAddress
            };

            var request = new createTransactionRequest { transactionRequest = transRequest };

            var controller = new createTransactionController(request);
            controller.Execute();

            var response = controller.GetApiResponse();

            return "";
        }

        // TODO: summary comment
        private customerAddressType GetBillingAddress(int orderId)
        {
            customerAddressType address = new customerAddressType
            {
                firstName = "Mr",
                lastName = "test",
                address = "123 test street",
                city = "Testville",
                zip = "00000"
            };

            return address;
        }
    }
}