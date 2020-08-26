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

        /// <summary>
        /// Runs the credit card transaction request
        /// </summary>
        /// <returns>Empty string</returns>
        public string Run(Order input)
        {
            // type of environment
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            // setup merchant account credentials
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = _config["ApiLoginId"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _config["AuthorizeTransactionKey"]
            };

            // create card we want on file
            // visa
            var creditCard = new creditCardType
            {
                cardNumber = "4007000000027",
                expirationDate = "1222",
                cardCode = "123"
            };

            var americanExpress = new creditCardType
            {
                cardNumber = "370000000000002",
                expirationDate = "1222",
                cardCode = "123"
            };

            var discover = new creditCardType
            {
                cardNumber = "6011000000000012",
                expirationDate = "1222",
                cardCode = "123"
            };

            var mastercard = new creditCardType
            {
                cardNumber = "5424000000000015",
                expirationDate = "1222",
                cardCode = "123"
            };

            customerAddressType billingAddress = GetBillingAddress(input);

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

            return response.messages.message[0].text;
        }

        /// <summary>
        /// Gets the billing address of the user
        /// </summary>
        /// <param name="orderId">The id of the current order</param>
        /// <returns>Billing address</returns>
        private customerAddressType GetBillingAddress(Order input)
        {
            customerAddressType address = new customerAddressType
            {
                firstName = input.FirstName,
                lastName = input.LastName,
                address = input.Address,
                city = input.City,
                state = input.State,
                zip = input.Zip
            };

            return address;
        }
    }
}