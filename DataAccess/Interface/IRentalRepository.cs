using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interface
{
    public interface IRentalRepository 
    {
        Task<Rental> GetPreviousRecordAsync(int custId, int carId);
        Task SaveAsync();
        Task AddRecordAsync(Rental record);
        Task<Rental> GetRentalDataAsync(int custId, int carId);
        Task<List<Rental>> GetMyRecordsAsync(int custId); 
        Task<Rental> GetRecordByIdAsync(int rentalId);
        Task<List<Rental>> GetAllAsync();
    }
}
