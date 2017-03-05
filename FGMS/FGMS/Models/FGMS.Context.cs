﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FGMS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class petermanEntities : DbContext
    {
        public petermanEntities()
            : base("name=petermanEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<CharacteristicsScore> CharacteristicsScores { get; set; }
        public virtual DbSet<DairyProductivity> DairyProductivities { get; set; }
        public virtual DbSet<Health> Healths { get; set; }
        public virtual DbSet<ImunizationRecord> ImunizationRecords { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<TestRecord> TestRecords { get; set; }
        public virtual DbSet<farm_Subscription> farm_Subscription { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Farm> Farms { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
    
        public virtual int Usp_CreateFarm_Address_Payment_Subscription(Nullable<int> addressId, string lastName, string firstName, string street, string city, string state, string zip, Nullable<int> farmId, string farmName, Nullable<double> acerage, string scrapieFlockId, Nullable<int> paymentId, string cardHolderName, string cardType, string cardNumber, string cvn, string pStreet, string pCity, string pState, string pZip, string operatorId, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var addressIdParameter = addressId.HasValue ?
                new ObjectParameter("AddressId", addressId) :
                new ObjectParameter("AddressId", typeof(int));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var streetParameter = street != null ?
                new ObjectParameter("Street", street) :
                new ObjectParameter("Street", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var stateParameter = state != null ?
                new ObjectParameter("State", state) :
                new ObjectParameter("State", typeof(string));
    
            var zipParameter = zip != null ?
                new ObjectParameter("Zip", zip) :
                new ObjectParameter("Zip", typeof(string));
    
            var farmIdParameter = farmId.HasValue ?
                new ObjectParameter("FarmId", farmId) :
                new ObjectParameter("FarmId", typeof(int));
    
            var farmNameParameter = farmName != null ?
                new ObjectParameter("FarmName", farmName) :
                new ObjectParameter("FarmName", typeof(string));
    
            var acerageParameter = acerage.HasValue ?
                new ObjectParameter("acerage", acerage) :
                new ObjectParameter("acerage", typeof(double));
    
            var scrapieFlockIdParameter = scrapieFlockId != null ?
                new ObjectParameter("scrapieFlockId", scrapieFlockId) :
                new ObjectParameter("scrapieFlockId", typeof(string));
    
            var paymentIdParameter = paymentId.HasValue ?
                new ObjectParameter("paymentId", paymentId) :
                new ObjectParameter("paymentId", typeof(int));
    
            var cardHolderNameParameter = cardHolderName != null ?
                new ObjectParameter("CardHolderName", cardHolderName) :
                new ObjectParameter("CardHolderName", typeof(string));
    
            var cardTypeParameter = cardType != null ?
                new ObjectParameter("CardType", cardType) :
                new ObjectParameter("CardType", typeof(string));
    
            var cardNumberParameter = cardNumber != null ?
                new ObjectParameter("cardNumber", cardNumber) :
                new ObjectParameter("cardNumber", typeof(string));
    
            var cvnParameter = cvn != null ?
                new ObjectParameter("cvn", cvn) :
                new ObjectParameter("cvn", typeof(string));
    
            var pStreetParameter = pStreet != null ?
                new ObjectParameter("pStreet", pStreet) :
                new ObjectParameter("pStreet", typeof(string));
    
            var pCityParameter = pCity != null ?
                new ObjectParameter("pCity", pCity) :
                new ObjectParameter("pCity", typeof(string));
    
            var pStateParameter = pState != null ?
                new ObjectParameter("pState", pState) :
                new ObjectParameter("pState", typeof(string));
    
            var pZipParameter = pZip != null ?
                new ObjectParameter("pZip", pZip) :
                new ObjectParameter("pZip", typeof(string));
    
            var operatorIdParameter = operatorId != null ?
                new ObjectParameter("OperatorId", operatorId) :
                new ObjectParameter("OperatorId", typeof(string));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Usp_CreateFarm_Address_Payment_Subscription", addressIdParameter, lastNameParameter, firstNameParameter, streetParameter, cityParameter, stateParameter, zipParameter, farmIdParameter, farmNameParameter, acerageParameter, scrapieFlockIdParameter, paymentIdParameter, cardHolderNameParameter, cardTypeParameter, cardNumberParameter, cvnParameter, pStreetParameter, pCityParameter, pStateParameter, pZipParameter, operatorIdParameter, startDateParameter, endDateParameter);
        }
    
        public virtual int usp_CreateFarmAdddress(Nullable<int> farmId, Nullable<int> addressId)
        {
            var farmIdParameter = farmId.HasValue ?
                new ObjectParameter("farmId", farmId) :
                new ObjectParameter("farmId", typeof(int));
    
            var addressIdParameter = addressId.HasValue ?
                new ObjectParameter("AddressId", addressId) :
                new ObjectParameter("AddressId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_CreateFarmAdddress", farmIdParameter, addressIdParameter);
        }
    
        public virtual int usp_CreateFarmPayment(Nullable<int> farmId, Nullable<int> paymentId)
        {
            var farmIdParameter = farmId.HasValue ?
                new ObjectParameter("farmId", farmId) :
                new ObjectParameter("farmId", typeof(int));
    
            var paymentIdParameter = paymentId.HasValue ?
                new ObjectParameter("PaymentId", paymentId) :
                new ObjectParameter("PaymentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_CreateFarmPayment", farmIdParameter, paymentIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> getFarmIdByFarmName(string farmname)
        {
            var farmnameParameter = farmname != null ?
                new ObjectParameter("Farmname", farmname) :
                new ObjectParameter("Farmname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("getFarmIdByFarmName", farmnameParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> usp_GetFarmIdByFarmName(string farmName)
        {
            var farmNameParameter = farmName != null ?
                new ObjectParameter("FarmName", farmName) :
                new ObjectParameter("FarmName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("usp_GetFarmIdByFarmName", farmNameParameter);
        }
    }
}
