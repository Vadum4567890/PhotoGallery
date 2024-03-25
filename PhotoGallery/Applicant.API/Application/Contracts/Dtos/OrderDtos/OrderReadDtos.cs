using System;
using Applicant.API.Application.Configurations;

namespace Applicant.API.Application.Contracts.Dtos.OrderDtos
{
   public class OrderReadDto
    {
       public int Id { get; set; }
    public int UserId { get; set; }
    public int AddressId { get; set; }
    // public Address Address{get;set;}
    public int Status { get; set; }


    //  public string Products {get;set;}
   
    public List<Products> ProductsJson { get; set; }
    public Address Addresses { get; set; }
    // public List<Address> OrderAdress{get;set;}
    // public Address Address { get; set; } = new Address();
    public int TotalPrice { get; set; }
    public int DeliveryType { get; set; }
    public int PayType { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
