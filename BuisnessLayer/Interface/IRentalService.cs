using DataAccess.Entities;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLayer.Interface
{
    public interface IRentalService
    {
        Task<string> AddRecordAsync(int userId, int carId, DateTime startDate, DateTime endDate);
        Task<List<MyRentalDetailsDto>> GetRentalsByCustIdAsync(int userId);
        Task<string> CancelRecordAsync(int rentalId);
        Task<List<Rental>> GetAllRecords();
    }
}
