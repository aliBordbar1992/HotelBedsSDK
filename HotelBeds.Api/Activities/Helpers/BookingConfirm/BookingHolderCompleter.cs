using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Api.Activities.Helpers.BookingConfirm
{
    public class BookingHolderCompleter
    {
        private readonly string _title;
        private readonly string _name;
        private readonly string _surname;
        private string _country;
        private string _address;
        private string _zipcode;
        private List<string> _phones;
        private string _email;
        private bool _mailing;

        public BookingHolderCompleter(string title, string name, string surname)
        {
            _title = title;
            _name = name;
            _surname = surname;
            if (_phones == null) _phones = new List<string>();
            _mailing = false;
        }

        public BookingHolder Build()
        {
            return new BookingHolder
            {
                Name = _name,
                Surname = _surname,
                Title = _title,
                Country = _country,
                Address = _address,
                ZipCode = _zipcode,
                Telephones = _phones,
                Email = _email,
                Mailing = _mailing
            };
        }

        public BookingHolderCompleter LivesIn(string country = "", string address = "", string zipcode = "")
        {
            _country = country;
            _address = address;
            _zipcode = zipcode;
            return this;
        }

        public BookingHolderCompleter HasPhoneNumber(params string[] phones)
        {
            _phones = phones.ToList();
            return this;
        }

        public BookingHolderCompleter HasEmail(string emailAddress, bool throwIfNotValid)
        {
            try
            {
                MailAddress m = new MailAddress(emailAddress);
                _email = emailAddress;
                return this;
            }
            catch (Exception e)
            {
                if (throwIfNotValid) throw;

                _email = "";
                return this;
            }

        }

        public BookingHolderCompleter WantsToReceiveCommunicationsViaEmail()
        {
            _mailing = true;
            return this;
        }
    }
}