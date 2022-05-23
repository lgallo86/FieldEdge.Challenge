using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FieldEdge.Challenge.ApplicationCore.Models
{
    public class CustomerModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("salutation")]
        public string Salutation { get; set; }

        [JsonProperty("initials")]
        public string Initials { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("firstname_ascii")]
        public string FirstnameAscii { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("firstname_country_rank")]
        public string FirstnameCountryRank { get; set; }

        [JsonProperty("firstname_country_frequency")]
        public string FirstnameCountryFrequency { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("lastname_ascii")]
        public string LastnameAscii { get; set; }

        [JsonProperty("lastname_country_rank")]
        public string LastnameCountryRank { get; set; }

        [JsonProperty("lastname_country_frequency")]
        public string LastnameCountryFrequency { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("country_code_alpha")]
        public string CountryCodeAlpha { get; set; }

        [JsonProperty("country_name")]
        public string CountryName { get; set; }

        [JsonProperty("primary_language_code")]
        public string PrimaryLanguageCode { get; set; }

        [JsonProperty("primary_language")]
        public string PrimaryLanguage { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("phone_Number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
